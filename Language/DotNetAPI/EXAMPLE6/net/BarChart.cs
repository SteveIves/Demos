using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNetClasses
{
    public partial class BarChart : Form
    {
        public BarChart()
        {
            InitializeComponent();
        }

        public string Title
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }

        public bool ShowLegend
        {
            get
            {
                return chartControl1.Series[0].ShowInLegend;
            }
            set
            {
                chartControl1.Series[0].ShowInLegend = value;
            }
        }

        public String LegendText
        {
            get
            {
                return chartControl1.Series[0].LegendText;
            }
            set
            {
                chartControl1.Series[0].LegendText = value;
                chartControl1.Series[0].ShowInLegend = (value.Length > 0);
            }
        }

        public bool SetChartData(string[] labels, int[] values)
        {
            bool ok = true;

            if (labels.GetUpperBound(0) != values.GetUpperBound(0))
                return false;

            DevExpress.XtraCharts.SeriesPoint point;

            for (int ix = 0; ix <= labels.GetUpperBound(0); ix++)
            {
                point = new DevExpress.XtraCharts.SeriesPoint(labels[ix], values[ix]);
                chartControl1.Series[0].Points.Add(point);
            }


            return ok;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
