using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace MyReports
{
    public partial class ReportViewer : UserControl
    {
        public ReportViewer()
        {
            InitializeComponent();
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.ShowLogo = false;
        }

        public void ShowReport(String reportName)
        {
            ReportClass rpt = null;

            switch (reportName)
            {
                case "CustomerList":
                   rpt = new CustomerList();
                    break;

                case "ProductList":
                    rpt = new ProductList();
                    break;
            }
            if (rpt != null)
            {
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Zoom(1);
                rpt.Refresh();
            }
            else
                MessageBox.Show(String.Format("Unknown report name {0}.",reportName));
        }

    }
}
