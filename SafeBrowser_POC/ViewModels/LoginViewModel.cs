using System.Threading.Tasks;
using Caliburn.Micro;
using SafeBrowser_POC.Core;

namespace SafeBrowser_POC.ViewModels
{
    public class LoginViewModel: Screen
    {
        private IEventAggregator _eventAggregator;
        
        public LoginViewModel(IEventAggregator eventAgg)
        {            
            _eventAggregator = eventAgg;
        }

        public void SignInWithGoogle()
        {
            Task.Run(async () =>
            {
                await _eventAggregator.PublishOnUIThreadAsync(new ChangePageMessage(typeof(MainViewModel)));
            });
            
        }

        public void Login ()
        {
            Task.Run(async () =>
            {
                await _eventAggregator.PublishOnUIThreadAsync(new OpenWindowMessage(typeof(NotificationViewModel)));
            });
        }
    }
}
