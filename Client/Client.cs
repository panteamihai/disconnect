using Microsoft.AspNet.SignalR.Client;
using System;
using System.Drawing;
using System.Net;
using System.Net.Cache;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Web.Security;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Client
{
    public partial class Client : Form
    {
        private  IHubProxy _hub;
        private CompositeDisposable _disposables;
        private HubConnection _hubConnection;
        private static string _bearerToken;
        private readonly SynchronizationContextScheduler _uiScheduler;

        public Client()
        {
            InitializeComponent();

          _uiScheduler = new SynchronizationContextScheduler(SynchronizationContext.Current);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
                _disposables?.Dispose();
            }

            base.Dispose(disposing);
        }

        private void Log(string message)
        {
            lstStatus.Items.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
        }

        private void AttachBehaviors()
        {
            _hub.On(nameof(Shared.IClient.HandleMessageFromServer),
                x => { txtOutput.BeginInvoke((Action)(() => txtOutput.Text = x)); });
        }

        private void SetControls(StateChange sc)
        {
            var enabled = sc.NewState == ConnectionState.Connected;
            var visible = sc.NewState == ConnectionState.Connected;

           // grpLogin.Visible = visible;
            grpInput.Visible = visible;
            grpOutput.Visible = visible;

            btnSend.Enabled = enabled;
            txtInput.Enabled = enabled;

            lstStatus.BackColor = enabled ? Color.MediumSeaGreen : Color.Firebrick;
        }

        private void btnSendClick(object sender, EventArgs e)
        {
            _hub.Invoke(nameof(Shared.IHub.HandleMessageFromCaller), txtInput.Text);
            _hub.Invoke<string>("AuthorizedString");

        }

        private void btnLoginClick(object sender, EventArgs e)
        {
            //_hub.Invoke(nameof(Shared.IHub.HandleLoginFromCaller), txtUser.Text, txtPass.Text);


            if (AuthenticateUser(txtUser.Text, txtPass.Text))
            {
                _hubConnection = new HubConnection(Shared.Hub.Url);
                _hubConnection.Headers.Add("Authorization", $"Bearer {_bearerToken}");
                _hub = _hubConnection.CreateHubProxy(Shared.Hub.Name);


                var startConnectionDisposable = Observable.FromAsync(() => _hubConnection.Start())
                                                          .ObserveOn(_uiScheduler)
                                                          .Subscribe(_ => { }, ex => Log(ex.Message));

                var stateChangesObservable = Observable.FromEvent<StateChange>(
                        h => _hubConnection.StateChanged += h,
                        h => _hubConnection.StateChanged -= h)
                    .StartWith(new StateChange(ConnectionState.Disconnected, ConnectionState.Connecting))
                    .ObserveOn(_uiScheduler)
                    .Do(sc => Log($"Went from {sc.OldState} to {sc.NewState}"))
                    .Publish();

                var controlSignalingDisposable = stateChangesObservable
                    .Subscribe(sc =>
                    {
                        AttachBehaviors();
                        SetControls(sc);
                    });

                var disconnectionDisposable = stateChangesObservable
                    .Where(sc => sc.NewState == ConnectionState.Disconnected)
                    .Sample(TimeSpan.FromSeconds(10))
                    .Subscribe(_ => _hubConnection.Start());

                var hotDisposable = stateChangesObservable.Connect();

                _disposables = new CompositeDisposable
                {
                    startConnectionDisposable,
                    controlSignalingDisposable,
                    disconnectionDisposable,
                    hotDisposable
                };
            }
        }

        private static bool AuthenticateUser(string user, string password)
        {
            var client = new RestClient($"{Shared.Hub.Url}/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded",$"grant_type=password&username={user}&password={password}", ParameterType.RequestBody);

            var restResponse = client.Execute(request);
            var success = restResponse.StatusCode == HttpStatusCode.OK;

            if(success)
                _bearerToken = JObject.Parse(restResponse.Content).GetValue("access_token").Value<string>();

            return success;
        }
    }
}
