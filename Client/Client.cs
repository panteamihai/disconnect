using Microsoft.AspNet.SignalR.Client;
using System;
using System.Drawing;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        private readonly IHubProxy _hub;
        private readonly CompositeDisposable _disposables;

        public Client()
        {
            InitializeComponent();

            var uiScheduler = new SynchronizationContextScheduler(SynchronizationContext.Current);

            var hubConnection = new HubConnection(Shared.Hub.Url);
            _hub = hubConnection.CreateHubProxy(Shared.Hub.Name);

            var startConnectionDisposable = Observable.FromAsync(() => hubConnection.Start())
                                                      .ObserveOn(uiScheduler)
                                                      .Subscribe(_ => { }, ex => Log(ex.Message));

            var stateChangesObservable = Observable.FromEvent<StateChange>(
                                                        h => hubConnection.StateChanged += h,
                                                        h => hubConnection.StateChanged -= h)
                                                    .StartWith(new StateChange(ConnectionState.Disconnected, ConnectionState.Connecting))
                                                    .ObserveOn(uiScheduler)
                                                    .Do(sc => Log($"Went from {sc.OldState} to {sc.NewState}"))
                                                    .Publish();

            var controlSignalingDisposable = stateChangesObservable   
                                                .Subscribe(SetControls);

            var disconnectionDisposable = stateChangesObservable
                                            .Where(sc => sc.NewState == ConnectionState.Disconnected)
                                            .Sample(TimeSpan.FromSeconds(10))
                                            .Subscribe(_ => hubConnection.Start());

            var hotDisposable = stateChangesObservable.Connect();

            _disposables = new CompositeDisposable
            {
                startConnectionDisposable,
                controlSignalingDisposable,
                disconnectionDisposable,
                hotDisposable
            };
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

            AttachBehaviors();

            grpInput.Visible = visible;
            grpOutput.Visible = visible;

            btnSend.Enabled = enabled;
            txtInput.Enabled = enabled;

            lstStatus.BackColor = enabled ? Color.MediumSeaGreen : Color.Firebrick;
        }

        private void btnSendClick(object sender, EventArgs e)
        {
            _hub.Invoke(nameof(Shared.IHub.HandleMessageFromCaller), txtInput.Text);
        }

        private void btnLoginClick(object sender, EventArgs e)
        {
            _hub.Invoke(nameof(Shared.IHub.HandleLoginFromCaller), txtUser.Text, txtPass.Text);
        }
    }
}
