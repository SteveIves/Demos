using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClientApp.TestService;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBasic_Click(object sender, EventArgs e)
        {
            CallService(getMethod(), "Basic");
        }

        private void btnWsPlain_Click(object sender, EventArgs e)
        {
            CallService(getMethod(), "WsPlain");
        }

        private void btnWsSecure_Click(object sender, EventArgs e)
        {
            CallService(getMethod(), "WsSecure");
        }

        private void btnNetTcp_Click(object sender, EventArgs e)
        {
            CallService(getMethod(), "NetTcp");
        }

        private void CallService(string method, string endPoint)
        {
            MessageInspector inspector = null;

            this.Cursor = Cursors.WaitCursor;

            //Clear the UI
            txtElapsedTimeMs.Text = "";
            txtRequestData.Text = "";
            txtResponseData.Text = "";

            //Create an instance for the service proxy
            TestServiceClient proxy = new TestServiceClient(endPoint);

            //If we're displaling messages, hook up a message inspector
            if (chkShowMessages.Checked)
            {
                inspector = new MessageInspector();
                proxy.Endpoint.Behaviors.Add(inspector);
            }

            //Grab the start time
            var startTime = DateTime.Now;

            //Call the method
            for (int i = 0; i < iterations.Value; i++)
            {
                if (method.Equals("AddTwoNumbers"))
                {
                    proxy.AddTwoNumbers(12332, 12323);
                }
                else if (method == "GetPeople")
                {
                    List<Person> people = proxy.GetPeople(Decimal.ToInt32(howManyPeople.Value));
                }
                else if (method == "GetUserName")
                {
                    string username = proxy.GetUserName();
                }
            }

            //Grab the end time
            var endTime = DateTime.Now;

            //Close the service proxy
            proxy.Close();

            //Calculate and display the elapsed time
            var elapsedTime = endTime.Subtract(startTime);
            txtElapsedTimeMs.Text = Convert.ToInt32(elapsedTime.TotalMilliseconds).ToString();
            txtElapsedTimeSec.Text = String.Format("{0:n2}", elapsedTime.TotalMilliseconds/1000);

            //Display the messages
            if (inspector != null)
            {
                txtRequestData.Text = inspector.RequestMessage;
                txtResponseData.Text = inspector.ResponseMessage;
            }

            this.Cursor = Cursors.Default;
        }

        private string getMethod()
        {
            if (rbAddTwoNumbers.Checked)
                return "AddTwoNumbers";
            else if (rbGetPeople.Checked)
                return "GetPeople";
            else if (rbGetUsername.Checked)
                return "GetUserName";
            return "";
        }

        private void rbGetPeople_CheckedChanged(object sender, EventArgs e)
        {
            howManyPeople.Enabled = rbGetPeople.Checked;
        }

    }
}
