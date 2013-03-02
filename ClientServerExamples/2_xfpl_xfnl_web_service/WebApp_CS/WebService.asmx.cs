using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using xfpldemo;

namespace WebApp_CS
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Customer> GetAllCustomers()
        {
            SynergyServer svr = new SynergyServer();
            List<Customer> customers = new List<Customer>();
            svr.GetAllCustomers(ref customers);
            return customers;
        }

        [WebMethod]
        public List<Contact> GetCustomerContacts(int CustomerId)
        {
            SynergyServer svr = new SynergyServer();
            List<Contact> contacts = new List<Contact>();
            svr.GetCustomerContacts(CustomerId, ref contacts);
            return contacts;
        }

        [WebMethod]
        public Method_status GetContactForUpdate(int customerId, int contactId, out Contact contact, out byte[] grfa, out String msg)
        {
            SynergyServer svr = new SynergyServer();
            contact = new Contact();
            grfa = new byte[10];
            msg = "";
            return svr.GetContactForUpdate(customerId, contactId, ref contact, ref grfa, ref msg);
        }

        [WebMethod]
        public Method_status UpdateContact(ref Contact contact, ref byte[] grfa, out String msg)
        {
            SynergyServer svr = new SynergyServer();
            msg = "";
            return svr.UpdateContact(ref contact, ref grfa, ref msg);
        }

    }
}
