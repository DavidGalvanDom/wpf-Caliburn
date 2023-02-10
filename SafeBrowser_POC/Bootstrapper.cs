using System;
using System.Collections.Generic;
using Caliburn.Micro;
using System.Windows;
using SafeBrowser_POC.ViewModels;

namespace SafeBrowser_POC
{
    public class Bootstrapper: BootstrapperBase
    {
        private SimpleContainer container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            
            container.Singleton<LoginViewModel, LoginViewModel>();
            container.Singleton<MainViewModel, MainViewModel>();
            container.Singleton<SendLogViewModel, SendLogViewModel>();
            container.Singleton<NotificationViewModel, NotificationViewModel>();

            container.PerRequest<ShellViewModel>();
        }

        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            await DisplayRootViewForAsync<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}
