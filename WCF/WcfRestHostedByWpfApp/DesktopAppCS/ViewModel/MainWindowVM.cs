using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

using DesktopAppCS.Services;

namespace DesktopAppCS.ViewModel
{
    class MainWindowVM : ViewModelBase
    {
        const string baseTitle = "Desktop App Hosting WCF REST Service";
        private string mAppTitle = baseTitle;
        private ObservableCollection<string> mMessages = new ObservableCollection<string>();
        Window mainWindow;
        LocalServicesHost svchost;

        public MainWindowVM(Window w)
        {
            mainWindow = w;
            mainWindow.Closing += mainWindow_Closing;
            startLocalServices();
        }

        public string AppTitle
        {
            get
            {
                return mAppTitle;
            }
            set
            {
                mAppTitle = value;
                NotifyPropertyChanged("AppTitle");
            }
        }

        private Brush mBackgroundColor = Brushes.White;

        public Brush BackgroundColor
        {
            get
            {
                return mBackgroundColor;
            }
            set
            {
                mBackgroundColor = value;
                NotifyPropertyChanged("BackgroundColor");
            }
        }

        private Brush mForegroundColor = Brushes.Black;

        public Brush ForegroundColor
        {
            get
            {
                return mForegroundColor;
            }
            set
            {
                mForegroundColor = value;
                NotifyPropertyChanged("ForegroundColor");
            }
        }


        public ObservableCollection<string> Messages
        {
            get
            {
                return mMessages;
            }
            set
            {
                mMessages = value;
                NotifyPropertyChanged("Messages");
            }
        }

        private void startLocalServices()
        {
            try
            {
                svchost = new LocalServicesHost();
                svchost.StartServices();
                svchost.NewMessage += svchost_NewMessage;
                AppTitle = string.Format("{0} [{1}]", baseTitle, svchost.LocalServicesUrl);
            }
            catch (Exception ex)
            {
                //Services failed to start
                MessageBox.Show(ex.Message);
                svchost = null;
            }
        }

        void svchost_NewMessage(string id, string data)
        {
            //Log the messages that we receive
            Messages.Add(String.Format("{0}:{1}", id, data));

            //Message IDs all come out of the service in uppercase
            switch (id)
            {
                case "COLOR":
                    switch (data.ToUpper())
                    {
                        case "RED":
                            BackgroundColor = Brushes.Red;
                            ForegroundColor = Brushes.White;
                            break;
                        case "WHITE":
                            BackgroundColor = Brushes.White;
                            ForegroundColor = Brushes.Black;
                            break;
                        case "BLUE":
                            BackgroundColor = Brushes.Blue;
                            ForegroundColor = Brushes.Yellow;
                            break;
                    }
                    break;
                case "EXIT":
                    Application.Current.Shutdown();
                    break;
                default:
                    break;
            }
        }

        void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            svchost.StopServices();
        }

    }
}
