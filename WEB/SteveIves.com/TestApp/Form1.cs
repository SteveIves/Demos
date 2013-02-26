using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            saveGridLayoutToolStripMenuItem.Enabled = System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed;
            resetGridToolStripMenuItem.Enabled = System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed;

            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                if (System.Deployment.Application.ApplicationDeployment.CurrentDeployment.IsFirstRun)
                {
                    Properties.Settings.Default.DefaultGridLayout = Util.GetGridViewState(view);
                    Properties.Settings.Default.Save();
                }
                else
                    Util.SetGridViewState(view, Properties.Settings.Default.GridLayout);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SteveIvesComDbDataContext db = new SteveIvesComDbDataContext();

            //Get a single airline and display it
            //Airline a = db.Airlines.Single(p => p.IcaoCode == "UAL");

            grid.DataSource = from p in db.Airlines orderby p.Name select p;
        }

        private void saveGridLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.GridLayout = Util.GetGridViewState(view);
            Properties.Settings.Default.Save();
        }

        private void resetGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.GridLayout = Properties.Settings.Default.DefaultGridLayout;
            Properties.Settings.Default.Save();
            Util.SetGridViewState(view, Properties.Settings.Default.GridLayout);
        }

    }
}
