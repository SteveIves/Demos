using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace FlightTracker.UserControls
{
    public partial class ucCountries : DevExpress.XtraEditors.XtraUserControl
    {
        public ucCountries()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void ucCountries_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                FlightTrackerService.FlightTrackerServiceSoapClient server = new FlightTracker.FlightTrackerService.FlightTrackerServiceSoapClient();
                grid.DataSource = server.GetCountries();
            }
            else
            {
                grid.DataSource = null;
            }

        }
    }
}
