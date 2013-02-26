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
    public partial class ucAirlines : DevExpress.XtraEditors.XtraUserControl
    {
        public ucAirlines()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void ucAirlines_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                FlightTrackerService.FlightTrackerServiceSoapClient server = new FlightTracker.FlightTrackerService.FlightTrackerServiceSoapClient();
                grid.DataSource = server.GetAirlines();
            }
            else
            {
                grid.DataSource = null;
            }
        }
    }
}
