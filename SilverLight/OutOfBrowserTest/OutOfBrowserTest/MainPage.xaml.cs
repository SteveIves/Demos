using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace OutOfBrowserTest
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            if (App.Current.HasElevatedPermissions)
                oob.Visibility = Visibility.Visible;
            else
                inBrowser.Visibility = Visibility.Visible;
        }

        private void installOutOfBrowser_Click(object sender, RoutedEventArgs e)
        {
            if (App.Current.InstallState == InstallState.NotInstalled)
            {
                App.Current.Install();
            }
        }

    }
}
