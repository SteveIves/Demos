using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CsTestClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        MyService.MyServiceClient svc;

        private void button1_Click(object sender, EventArgs e)
        {
            svc = new MyService.MyServiceClient();
            svc.AddTwoNumbersCompleted += new EventHandler<MyService.AddTwoNumbersCompletedEventArgs>(svc_AddTwoNumbersCompleted);
            svc.AddTwoNumbersAsync(4, 5);
        }

        void svc_AddTwoNumbersCompleted(object sender, MyService.AddTwoNumbersCompletedEventArgs e)
        {
            svc.AddTwoNumbersCompleted -= new EventHandler<MyService.AddTwoNumbersCompletedEventArgs>(svc_AddTwoNumbersCompleted);
            MessageBox.Show(e.Result.ToString());
            svc.Close();
        }
    }
}
