using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using FlightTracker.UserControls;

namespace FlightTracker
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnClickMe_Click(object sender, EventArgs e)
        {
            FlightTrackerService.FlightTrackerServiceSoapClient s = new FlightTracker.FlightTrackerService.FlightTrackerServiceSoapClient();
            MessageBox.Show(s.HelloWorld());
        }

        private ucAirports airportsControl;

        private void btnAirports_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (airportsControl == null)
                airportsControl = new ucAirports();
            clientPanel.Controls.Clear();
            clientPanel.Controls.Add(airportsControl);
        }

        private ucAirlines airlinesControl;

        private void btnAirlines_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (airlinesControl == null)
                airlinesControl = new ucAirlines();
            clientPanel.Controls.Clear();
            clientPanel.Controls.Add(airlinesControl);
        }

        private ucCountries countriesControl;

        private void btnCountries_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (countriesControl == null)
                countriesControl = new ucCountries();
            clientPanel.Controls.Clear();
            clientPanel.Controls.Add(countriesControl);
        }
    }
}