using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Caliburn.Micro;

namespace SafeBrowser_POC.ViewModels
{
    public class NotificationViewModel : Screen
    {
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

        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                NotifyOfPropertyChange("Message");
            }
        }

        public NotificationViewModel ()
        {
            Message = "You should fix your DNS settings to have stable internet connection, click to fix";
            Title = "Notification";
        }

        public void FixNotification()
        {
            Application.Current.Shutdown();
        }
    }
}
