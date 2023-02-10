using System.Windows;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using SafeBrowser_POC.Core;

namespace SafeBrowser_POC.ViewModels
{
    class ShellViewModel : Conductor<IScreen>.Collection.OneActive, 
                           IHandle<ChangePageMessage>,
                           IHandle<OpenWindowMessage>
    {
        public IWindowManager _windowManager { get; private set; }

        private WindowState _windowState;
        public WindowState WinState
        {
            get => _windowState;
            set
            {
                _windowState = value;
                NotifyOfPropertyChange("WinState");
            }
        }

        private IEventAggregator _eventAggregator;
        public ShellViewModel(IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.SubscribeOnUIThread(this);
            WinState = WindowState.Normal;

            Task.Run(async () =>
            {
                await ActivateItemAsync(new LoginViewModel(_eventAggregator));
            });
        }


        public Task HandleAsync(ChangePageMessage message, CancellationToken cancellationToken)
        {            
            var instance = (IScreen) IoC.GetInstance(message.ViewModelType, null);
            Task.Run(async () =>
            {
                await ActivateItemAsync(instance);
            });
            return Task.CompletedTask;
        }

        public Task HandleAsync(OpenWindowMessage message, CancellationToken cancellationToken)
        {
            var instance = (IScreen)IoC.GetInstance(message.ViewModelType, null);

            _windowManager.ShowWindowAsync(instance);

            return Task.CompletedTask;
        }


        public void Close()
        {
            Application.Current.Shutdown();
        }

        public void MaximizeWindows()
        {
            if(WinState == WindowState.Normal)
                WinState = WindowState.Maximized;
            else
                WinState = WindowState.Normal;
        }

        public void MinimizeWindows()
        {
            WinState = WindowState.Minimized;
        }
    }
}
