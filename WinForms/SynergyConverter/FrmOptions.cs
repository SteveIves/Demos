using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SynergyConverter
{
    public partial class FrmOptions : Form
    {
        public FrmOptions()
        {
            InitializeComponent();
        }

        private void FrmOptions_Load(object sender, EventArgs e)
        {
            chkAutoCopy.Checked = Properties.Settings.Default.AutoCopyToClipboard;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.AutoCopyToClipboard = chkAutoCopy.Checked;
            Properties.Settings.Default.Save();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
