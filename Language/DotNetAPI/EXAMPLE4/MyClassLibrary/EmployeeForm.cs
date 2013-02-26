using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyClassLibrary
{
    public partial class EmployeeForm : Form
    {

        public EmployeeForm(ref Employee data)
        {
            InitializeComponent();
            employeeBindingSource.DataSource = data;
        }

        public Employee Data
        {
            get
            {
                return (Employee)employeeBindingSource.DataSource;
}
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            SetReviewLabel();
        }
        private void TrkReview_ValueChanged(object sender, EventArgs e)
        {
            SetReviewLabel();
        }

        private void SetReviewLabel()
        {
            switch ((ReviewFrequency)TrkReview.Value)
            {
                case ReviewFrequency.Never:
                    LblReviewDisplay.Text = "Never";
                    break;
                case ReviewFrequency.Monthly:
                    LblReviewDisplay.Text = "Monthly";
                    break;
                case ReviewFrequency.Quarterly:
                    LblReviewDisplay.Text = "Quarterly";
                    break;
                case ReviewFrequency.Biannually:
                    LblReviewDisplay.Text = "Bi-annually";
                    break;
                case ReviewFrequency.Annually:
                    LblReviewDisplay.Text = "Annually";
                    break;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
