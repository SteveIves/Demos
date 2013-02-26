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
    public partial class ucAirports : DevExpress.XtraEditors.XtraUserControl
    {
        public ucAirports()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        private void ucAirports_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                FlightTrackerService.FlightTrackerServiceSoapClient server = new FlightTracker.FlightTrackerService.FlightTrackerServiceSoapClient();
                grid.DataSource = server.GetAirports();
            }
            else
            {
                grid.DataSource = null;
            }
        }
    }
}
