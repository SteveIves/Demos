using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TestApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                if (System.Deployment.Application.ApplicationDeployment.CurrentDeployment.IsFirstRun)
                {
                    //Remove any previous grid customizations
                    Properties.Settings.Default.GridLayout = "";
                    Properties.Settings.Default.DefaultGridLayout = "";
                    Properties.Settings.Default.Save();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
