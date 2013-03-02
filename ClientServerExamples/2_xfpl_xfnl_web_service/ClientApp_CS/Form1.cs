using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClientApp.spc2011;

namespace ClientApp
{
    public partial class Form1 : Form
    {
        WebServiceSoapClient svr = null;
        Contact savedContact;
        byte[] savedGrfa;
        string msg;

        public Form1()
        {
            InitializeComponent();
            gridCustomers.AutoGenerateColumns = false;
            gridContacts.AutoGenerateColumns = false;
            svr = new WebServiceSoapClient();
            savedGrfa = new byte[10];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Customer> c = new List<Customer>();
            try
            {
                c = svr.GetAllCustomers();
                gridCustomers.DataSource = c;

                //If we have customers then load the contacts for the one that is now selected
                if (gridCustomers.SelectedRows.Count > 0)
                {
                    Customer tmpCustomer = (Customer)gridCustomers.Rows[gridCustomers.SelectedRows[0].Index].DataBoundItem;
                    loadContacts(tmpCustomer.Customer_id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void gridCustomers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridCustomers.SelectedRows.Count > 0)
            {
                displayBlankContact();
                List<Customer> customers = (List<Customer>)gridCustomers.DataSource;
                Customer c = (Customer)customers[gridCustomers.SelectedRows[0].Index];
                loadContacts(c.Customer_id);
            }
        }


        private void loadContacts(int customer_id)
        {
            List<Contact> c = new List<Contact>();
            try
            {
                c = svr.GetCustomerContacts(customer_id);
                gridContacts.DataSource = c;

                //If we have a selected contact then display it
                if (gridContacts.SelectedRows.Count > 0)
                {
                    savedContact = (Contact)gridContacts.Rows[gridContacts.SelectedRows[0].Index].DataBoundItem;
                    try
                    {
                        svr.GetContactForUpdate(savedContact.Customer_id, savedContact.Contact_id, out savedContact, out savedGrfa, out msg);
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
                    svr.GetContactForUpdate(savedContact.Customer_id, savedContact.Contact_id, out currentContact, out savedGrfa, out msg);
                    savedContact = currentContact;

                    //Update the contact in the grids datasource
                    List<Contact> contacts = (List<Contact>)gridContacts.DataSource;
                    contacts[e.RowIndex] = currentContact;

                    displaySavedContact();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
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
            txtFirstName.Text = savedContact.First_name;
            txtLastName.Text = savedContact.Last_name;
            txtFullName.Text = savedContact.Friendly_name;
            txtPrefix.Text = savedContact.Salutation;
            txtTitle.Text = savedContact.Title;
            txtDepartment.Text = savedContact.Department;
            if (savedContact.Work_phone != 0)
                txtWorkPhone.Text = savedContact.Work_phone.ToString();
            else
                txtWorkPhone.Text = "";
            if (savedContact.Mobile_phone != 0)
                txtMobilePhone.Text = savedContact.Mobile_phone.ToString();
            else
                txtMobilePhone.Text = "";
            if (savedContact.Home_phone != 0)
                txtHomePhone.Text = savedContact.Home_phone.ToString();
            else
                txtHomePhone.Text = "";
            if (savedContact.Fax != 0)
                txtFax.Text = savedContact.Fax.ToString();
            else
                txtFax.Text = "";
            txtWebSite.Text = savedContact.Web_site;
            txtEmail.Text = savedContact.Email;
            chkManagementContact.Checked = savedContact.Management_contact;
            chkBillingContact.Checked = savedContact.Billing_contact;
            chkSalesContact.Checked = savedContact.Sales_contact;
            chkTechnicalContact.Checked = savedContact.Technical_contact;
            chkGeneralContact.Checked = savedContact.General_contact;
            allowSave = false;
        }

        private void saveContact()
        {
            if (!validateFormData())
                return;

            //Save the new contact info locally
            savedContact.First_name = txtFirstName.Text;
            savedContact.Last_name = txtLastName.Text;
            savedContact.Friendly_name = txtFullName.Text;
            savedContact.Salutation = txtPrefix.Text;
            savedContact.Title = txtTitle.Text;
            savedContact.Department = txtDepartment.Text;
            if (txtWorkPhone.Text.Length > 0)
                savedContact.Work_phone = long.Parse(txtWorkPhone.Text);
            else
                savedContact.Work_phone = 0;
            if (txtMobilePhone.Text.Length > 0)
                savedContact.Mobile_phone = long.Parse(txtMobilePhone.Text);
            else
                savedContact.Mobile_phone = 0;
            if (txtHomePhone.Text.Length > 0)
                savedContact.Home_phone = long.Parse(txtHomePhone.Text);
            else
                savedContact.Home_phone = 0;
            if (txtFax.Text.Length > 0)
                savedContact.Fax = long.Parse(txtFax.Text);
            else
                savedContact.Fax = 0;
            savedContact.Web_site = txtWebSite.Text;
            savedContact.Email = txtEmail.Text;
            savedContact.Management_contact = chkManagementContact.Checked;
            savedContact.Billing_contact = chkBillingContact.Checked;
            savedContact.Sales_contact = chkSalesContact.Checked;
            savedContact.Technical_contact = chkTechnicalContact.Checked;
            savedContact.General_contact = chkGeneralContact.Checked;

            //Save the new data to the server
            try
            {
                svr.UpdateContact(ref savedContact, ref savedGrfa, out msg);

                //Update the contact in the grids datasource
                List<Contact> contacts = (List<Contact>)gridContacts.DataSource;
                contacts[gridContacts.SelectedRows[0].Index] = savedContact;
                gridContacts.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
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

            if (txtWorkPhone.Text.Length > 0)
            {
                long tmpPhone;
                if (!long.TryParse(txtWorkPhone.Text, out tmpPhone))
                {
                    errorMessage = String.Format("{0}\nWork phone must be numeric", errorMessage);
                    retval = false;
                }
            }

            if (txtMobilePhone.Text.Length > 0)
            {
                long tmpPhone;
                if (!long.TryParse(txtMobilePhone.Text, out tmpPhone))
                {
                    errorMessage = String.Format("{0}\nMobile phone must be numeric", errorMessage);
                    retval = false;
                }
            }

            if (txtHomePhone.Text.Length > 0)
            {
                long tmpPhone;
                if (!long.TryParse(txtHomePhone.Text, out tmpPhone))
                {
                    errorMessage = String.Format("{0}\nHome phone must be numeric", errorMessage);
                    retval = false;
                }
            }

            if (txtFax.Text.Length > 0)
            {
                long tmpPhone;
                if (!long.TryParse(txtFax.Text, out tmpPhone))
                {
                    errorMessage = String.Format("{0}\nFax number must be numeric", errorMessage);
                    retval = false;
                }
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
