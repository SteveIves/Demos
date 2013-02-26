using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using webServiceClientApp.spc2010;

namespace webServiceClientApp
{
    public partial class Form1 : Form
    {
        SPC2010WebService svr = null;
        Contact savedContact;
        byte[] savedGrfa;
        string msg;

        public Form1()
        {
            InitializeComponent();
            gridCustomers.AutoGenerateColumns = false;
            gridContacts.AutoGenerateColumns = false;
            savedGrfa = new byte[10];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                svr = new SPC2010WebService();
                Customer[] customers = svr.GetCustomers();
                gridCustomers.DataSource = customers;

                //If we have customers then load the contacts for the one that is now selected
                if (gridCustomers.SelectedRows.Count > 0)
                {
                    Customer tmpCustomer = (Customer)gridCustomers.Rows[gridCustomers.SelectedRows[0].Index].DataBoundItem;
                    loadContacts(tmpCustomer.CustomerId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            finally
            {
                svr.Dispose();
            }
        }

        private void gridCustomers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridCustomers.SelectedRows.Count > 0)
            {
                displayBlankContact();
                Customer[] customers = (Customer[])gridCustomers.DataSource;
                Customer c = (Customer)customers[gridCustomers.SelectedRows[0].Index];
                loadContacts(c.CustomerId);
            }
        }


        private void loadContacts(int customer_id)
        {
            try
            {
                svr = new SPC2010WebService();
                Contact[] contacts = svr.GetCustomerContacts(customer_id);
                gridContacts.DataSource = contacts;

                //If we have a selected contact then display it
                if (gridContacts.SelectedRows.Count > 0)
                {
                    savedContact = (Contact)gridContacts.Rows[gridContacts.SelectedRows[0].Index].DataBoundItem;
                    try
                    {
                        svr.GetContactForUpdate(savedContact.CustomerId, savedContact.ContactId, out savedContact, out savedGrfa, out msg);
                        displaySavedContact();
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                svr.Dispose();
            }
        }

        private void gridContacts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridContacts.SelectedRows.Count > 0)
            {
                savedContact = (Contact)gridContacts.Rows[e.RowIndex].DataBoundItem;

                //Get the latest version of the contact, and it's current GRFA
                Contact currentContact = new Contact();

                try
                {
                    svr = new SPC2010WebService();
                    svr.GetContactForUpdate(savedContact.CustomerId, savedContact.ContactId, out currentContact, out savedGrfa, out msg);
                    savedContact = currentContact;

                    //Update the contact in the grids datasource
                    Contact[] contacts = (Contact[])gridContacts.DataSource;
                    contacts[e.RowIndex] = currentContact;
                    displaySavedContact();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
                finally
                {
                    svr.Dispose();
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            saveContact();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            displaySavedContact();
            allowSave = false;
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void displaySavedContact()
        {
            if (savedContact.FirstName!=null)
                txtFirstName.Text = savedContact.FirstName.Trim();
            if (savedContact.LastName != null)
                txtLastName.Text = savedContact.LastName.Trim();
            if (savedContact.FriendlyName != null)
                txtFullName.Text = savedContact.FriendlyName.Trim();
            if (savedContact.Salutation != null)
                txtPrefix.Text = savedContact.Salutation.Trim();
            if (savedContact.Title != null)
                txtTitle.Text = savedContact.Title.Trim();
            if (savedContact.Department != null)
                txtDepartment.Text = savedContact.Department.Trim();
            if (savedContact.WorkPhone != null)
                txtWorkPhone.Text = savedContact.WorkPhone.Trim();
            if (savedContact.HomePhone != null)
                txtHomePhone.Text = savedContact.HomePhone.Trim();
            if (savedContact.Email != null)
                txtEmail.Text = savedContact.Email.Trim();
            allowSave = false;
        }

        private void saveContact()
        {
            if (!validateFormData())
                return;

            //Save the new contact info locally
            savedContact.FirstName = txtFirstName.Text;
            savedContact.LastName = txtLastName.Text;
            savedContact.FriendlyName = txtFullName.Text;
            savedContact.Salutation = txtPrefix.Text;
            savedContact.Title = txtTitle.Text;
            savedContact.Department = txtDepartment.Text;
            savedContact.WorkPhone = txtWorkPhone.Text;
            savedContact.HomePhone = txtHomePhone.Text;
            savedContact.Email = txtEmail.Text;

            //Save the new data to the server
            try
            {
                svr = new SPC2010WebService();
                svr.UpdateContact(ref savedContact, ref savedGrfa, out msg);

                //Update the contact in the grids datasource
                Contact[] contacts = (Contact[])gridContacts.DataSource;
                contacts[gridContacts.SelectedRows[0].Index] = savedContact;
                gridContacts.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            finally
            {
                svr.Dispose();
            }

            allowSave = false;
        }

        private bool validateFormData()
        {
            bool retval = true;

            string errorMessage = "";

            if (txtFirstName.Text.Length == 0)
            {
                errorMessage = String.Format("{0}/nFirst name cannot be blank", errorMessage);
                retval = false;
            }

            if (txtLastName.Text.Length == 0)
            {
                errorMessage = String.Format("{0}/nLast name cannot be blank", errorMessage);
                retval = false;
            }

            if (!retval)
                MessageBox.Show(errorMessage, "Invalid data", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return retval;
        }

        private void displayBlankContact()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtFullName.Text = "";
            txtPrefix.Text = "";
            txtTitle.Text = "";
            txtDepartment.Text = "";
            txtWorkPhone.Text = "";
            txtMobilePhone.Text = "";
            txtHomePhone.Text = "";
            txtFax.Text = "";
            txtWebSite.Text = "";
            txtEmail.Text = "";
            chkManagementContact.Checked = false;
            chkBillingContact.Checked = false;
            chkSalesContact.Checked = false;
            chkTechnicalContact.Checked = false;
            chkGeneralContact.Checked = false;
        }

        private bool _allowSave;
        private bool allowSave
        {
            get
            {
                return _allowSave;
            }
            set
            {
                _allowSave = value;
                btnOK.Enabled = _allowSave;
                btnCancel.Enabled = _allowSave;
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            txtFullName.Text = String.Format("{0} {1}", txtFirstName.Text, txtLastName.Text);
            allowSave = true;
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            txtFullName.Text = String.Format("{0} {1}", txtFirstName.Text, txtLastName.Text);
            allowSave = true;
        }

        private void fieldChanged(object sender, EventArgs e)
        {
            allowSave = true;
        }
    }
}
