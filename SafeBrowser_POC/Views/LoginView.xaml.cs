using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SafeBrowser_POC.Views
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        //private void btnLogin_Click(object sender, RoutedEventArgs e)
        //{
        //    ShowNotificationExecute();
        //}

        //private void ShowNotificationExecute()
        //{
        //    App.Current.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(
        //        () =>
        //        {
        //            var notify = new NotificationWindow();
        //            notify.Show();
        //        }));
        //}
    }
}
