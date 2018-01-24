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
                                                      .Subscribe(_ => AttachBehaviors(),
                                                                 ex => Log(ex.Message));

            var stateChanges = Observable.FromEvent<StateChange>(
                                            h => hubConnection.StateChanged += h,
                                            h => hubConnection.StateChanged -= h)
                                        .StartWith(new StateChange(ConnectionState.Disconnected, ConnectionState.Connecting))
                                        .ObserveOn(uiScheduler);
                                        

            var controlSignalingDisposable = stateChanges.Do(sc => Log($"Went from {sc.OldState} to {sc.NewState}")).Subscribe(SetControls);
            var disconnectionDisposable = stateChanges
                    .Where(sc => sc.NewState == ConnectionState.Disconnected)
                    .Sample(TimeSpan.FromSeconds(10))
                    .Subscribe(_ => hubConnection.Start());

            _disposables = new CompositeDisposable
                           {
                               startConnectionDisposable,
                               controlSignalingDisposable,
                               disconnectionDisposable
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

            txtInput.Enabled = enabled;
            btnSend.Enabled = enabled;
            grpOutput.Visible = enabled;

            lstStatus.BackColor = enabled ? Color.MediumSeaGreen : Color.Firebrick;
        }

        private void btnSendClick(object sender, EventArgs e)
        {
            _hub.Invoke(nameof(Shared.IHub.HandleMessageFromCaller), txtInput.Text);
        }
    }
}
