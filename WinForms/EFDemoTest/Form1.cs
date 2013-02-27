using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EFDemoTest
{
    public partial class Form1 : Form
    {
        EFDemoTest.Entities ctEntity;
        CHRONOTRACK_USER selectedUser;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ctEntity = new Entities();
            cmbUsers.DataSource = ctEntity.CHRONOTRACK_USER;
            cmbUsers.DisplayMember = "USER_ID";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ctEntity.Dispose();
            ctEntity = null;
        }

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedUser = (CHRONOTRACK_USER)cmbUsers.SelectedItem;
            txtAddr1.Text = selectedUser.ADDR1;
            txtAddr2.Text = selectedUser.ADDR2;
            txtAddr3.Text = selectedUser.ADDR3;
            txtCity.Text = selectedUser.ADDR4;
            txtState.Text = selectedUser.STATE;
            txtZip.Text = selectedUser.ZIP;
            btnPrev.Enabled = (cmbUsers.SelectedIndex != 0);
            btnNext.Enabled = (cmbUsers.SelectedIndex < cmbUsers.Items.Count - 1);

            // If it's a consultant, show the datagrid and populate with projects
            if (selectedUser.IS_CONSULTANT == 0)
            {
                dgvProjects.DataSource = null;
            }
            else
            {
                string tmpUserId = selectedUser.USER_ID;
                IQueryable<PROJECT> projectList =
                    from p in ctEntity.PROJECT
                    where p.LEAD_CONSULTANT == tmpUserId
                    select p;
                dgvProjects.DataSource = projectList;
            }

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            cmbUsers.SelectedIndex--;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            cmbUsers.SelectedIndex++;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtAddr1.Text.Length > 0 && txtAddr1.Text != selectedUser.ADDR1)
            {
                selectedUser.ADDR1 = txtAddr1.Text;
                int changesMade = ctEntity.SaveChanges();
                MessageBox.Show("Made " + changesMade.ToString() + " changes.");
            }
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            txtAddr1.Text = selectedUser.ADDR1;
            txtAddr2.Text = selectedUser.ADDR2;
            txtAddr3.Text = selectedUser.ADDR3;
            txtCity.Text = selectedUser.ADDR4;
            txtState.Text = selectedUser.STATE;
            txtZip.Text = selectedUser.ZIP;
        }

    }
}
