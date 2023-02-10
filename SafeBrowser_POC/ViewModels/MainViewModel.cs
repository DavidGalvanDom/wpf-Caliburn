using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using SafeBrowser_POC.Core;

namespace SafeBrowser_POC.ViewModels
{
    class MainViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<ChangePageMessage>
    {
           
        private IEventAggregator _eventAggregator;
        private IEventAggregator _eventAggregatorMain;

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                NotifyOfPropertyChange("Title");
            }
        }

        public MainViewModel(IEventAggregator eventAgg)
        { 
            //Title = "Welcome to Caliburn Micro in WPF";
            _eventAggregator = eventAgg;
            _eventAggregatorMain = new EventAggregator();
            _eventAggregatorMain.SubscribeOnUIThread(this);
            LoadHome();
        }

        public Task HandleAsync(ChangePageMessage message, CancellationToken cancellationToken)
        {
            IScreen instance = (IScreen)IoC.GetInstance(message.ViewModelType, null);
            Task.Run(async () =>
            {
                await ActivateItemAsync(instance);
            });
            return Task.CompletedTask;

        }


        public void BackLogin()
        {
            Task.Run(async () =>
            {
                await _eventAggregator.PublishOnUIThreadAsync(new ChangePageMessage(typeof(LoginViewModel)));
            });
        }

        public void LoadHome()
        {
            Task.Run(async () =>
            {
                await ActivateItemAsync(new HomeViewModel());
            });
        }

        public void LoadAbout()
        {
            Task.Run(async () =>
            {
                await ActivateItemAsync(new AboutViewModel());
            });
        }

        public void LoadConfig()
        {
            Task.Run(async () =>
            {
                await ActivateItemAsync(new ConfigViewModel(_eventAggregatorMain));
            });
        }
    }
}
