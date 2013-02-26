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

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            

        }
        
        MyService.MyServiceClient svc;

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            svc = new MyService.MyServiceClient();
            svc.AddTwoNumbersCompleted+=new EventHandler<MyService.AddTwoNumbersCompletedEventArgs>(svc_AddTwoNumbersCompleted);
            svc.AddTwoNumbersAsync(3, 6);
        }

        void svc_AddTwoNumbersCompleted(object sender, MyService.AddTwoNumbersCompletedEventArgs e)
        {
            svc.CloseAsync();
            svc.AddTwoNumbersCompleted -= new EventHandler<MyService.AddTwoNumbersCompletedEventArgs>(svc_AddTwoNumbersCompleted);
            textBox1.Text = e.Result.ToString();
        }
    }
}
