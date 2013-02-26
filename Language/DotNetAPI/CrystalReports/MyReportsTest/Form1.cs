using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyReportsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customerListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            MyReports.ReportViewer v = new MyReports.ReportViewer();
            //v.Dock = DockStyle.Fill;
            v.ShowReport("CustomerList");
            panel1.Controls.Add(v);
        }

        private void productListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            MyReports.ReportViewer v = new MyReports.ReportViewer();
            //v.Dock = DockStyle.Fill;
            v.ShowReport("ProductList");
            panel1.Controls.Add(v);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
