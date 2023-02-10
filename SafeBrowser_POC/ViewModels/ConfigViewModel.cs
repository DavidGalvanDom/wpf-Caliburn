using System.Threading.Tasks;
using Caliburn.Micro;
using SafeBrowser_POC.Core;

namespace SafeBrowser_POC.ViewModels
{
    class ConfigViewModel : Screen
    {
        private IEventAggregator _eventAggregator;

        public ConfigViewModel(IEventAggregator eventAgg)
        {
            _eventAggregator = eventAgg;
        }
       
        public void Save ()
        {

        }


        public void LoadLog()
        {
            Task.Run(async () =>
            {
                await _eventAggregator.PublishOnUIThreadAsync(new ChangePageMessage(typeof(SendLogViewModel)));
            });
        }
    }
}
