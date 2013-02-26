using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FlightTracker
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themeController = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            //themeController.LookAndFeel.SkinName = "Money Twins";
            themeController.LookAndFeel.SkinName = "Black";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
