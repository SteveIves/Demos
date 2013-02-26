using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilverlightDemo.Web
{
    /// <summary>
    /// Summary description for SPC2010WebService
    /// </summary>
    [WebService(Namespace = "http://psg.synergex.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class SPC2010WebService : System.Web.Services.WebService
    {
        [WebMethod(Description = "Returns a collection of all customer ID's and names.")]
        public List<Customer> GetCustomers()
        {
            ArrayList tmpCustomers = new ArrayList();
            List<Customer> customers = new List<Customer>();

            spc2010.SynergyServer svr = new spc2010.SynergyServer();
            svr.GetAllCustomers(ref tmpCustomers);

            foreach (spc2010.Customer tmpCustomer in tmpCustomers)
                customers.Add(new Customer(tmpCustomer));

            return customers;
        }

        [WebMethod(Description = "Returns a collection of all contacts for a customer.")]
        public List<Contact> GetCustomerContacts(int customerId)
        {
            ArrayList tmpContacts = new ArrayList();
            List<Contact> contacts = new List<Contact>();

            spc2010.SynergyServer svr = new spc2010.SynergyServer();
            svr.GetCustomerContacts(customerId, ref tmpContacts);

            foreach (spc2010.Contact tmpContact in tmpContacts)
                contacts.Add(new Contact(tmpContact));

            return contacts;
        }

        [WebMethod(Description = "Returns a collection of all addresses for a customer.")]
        public List<Address> GetCustomerAddresses(int customerId)
        {
            ArrayList tmpAddresses = new ArrayList();
            List<Address> addresses = new List<Address>();

            spc2010.SynergyServer svr = new spc2010.SynergyServer();
            svr.GetCustomerAddresses(customerId, ref tmpAddresses);

            foreach (spc2010.Address tmpAddress in tmpAddresses)
                addresses.Add(new Address(tmpAddress));

            return addresses;
        }

        [WebMethod(Description = "Returns a current contact record and its current GRFA")]
        public spc2010.Method_status GetContactForUpdate(int customerId, int contactId, out Contact contact, out byte[] grfa, out string msg)
        {
            spc2010.Method_status retval;
            spc2010.Contact tmpContact = new spc2010.Contact();
            grfa = new byte[10];
            msg = "";
            spc2010.SynergyServer svr = new spc2010.SynergyServer();

            try
            {
                if (svr.GetContactForUpdate(customerId, contactId, ref tmpContact, ref grfa, ref msg) == spc2010.Method_status.Success)
                {
                    contact = new Contact(tmpContact);
                    retval = spc2010.Method_status.Success;
                }
                else
                {
                    contact = new Contact();
                    retval = spc2010.Method_status.Info_error;
                }
            }
            catch (Exception ex)
            {
                contact = new Contact();
                msg = ex.Message;
                retval = spc2010.Method_status.Fatal_error;
            }
            return retval;
        }

        [WebMethod(Description = "Updates a contact record if it hasn't already been changed by another user")]
        public spc2010.Method_status UpdateContact(ref Contact contact, ref byte[] grfa, out string msg)
        {
            spc2010.Method_status retval;
            spc2010.Contact tmpContact = new spc2010.Contact();
            tmpContact.Contact_id = contact.ContactId;
            tmpContact.First_name = contact.FirstName;
            tmpContact.Last_name = contact.LastName;
            tmpContact.Friendly_name = contact.FriendlyName;
            tmpContact.Salutation = contact.Salutation;
            tmpContact.Email = contact.Email;
            tmpContact.Department = contact.Title;
            tmpContact.Title = contact.Title;

            //MISING PHONE FIELDS - NEED TO FIX THIS!!!

            msg = "";
            spc2010.SynergyServer svr = new spc2010.SynergyServer();

            try
            {
                if (svr.UpdateContact(ref tmpContact, ref grfa, ref msg) == spc2010.Method_status.Success)
                {
                    retval = spc2010.Method_status.Success;
                }
                else
                {
                    contact = new Contact(tmpContact);
                    retval = spc2010.Method_status.Info_error;
                }
            }
            catch (Exception ex)
            {
                contact = new Contact();
                msg = ex.Message;
                retval = spc2010.Method_status.Fatal_error;
            }
            return retval;
        }


    }
}
