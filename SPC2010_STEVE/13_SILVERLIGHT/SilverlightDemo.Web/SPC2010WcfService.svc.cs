using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SilverlightDemo.Web
{
    public class SPC2010WcfService : ISPC2010WcfService
    {
        public MethodStatus GetCustomers(out List<Customer> customers, out string message)
        {
            MethodStatus retval = MethodStatus.Success;
            customers = new List<Customer>();
            message = "";

            ArrayList tmpCustomers = new ArrayList();
            try
            {
                spc2010.SynergyServer svr = new spc2010.SynergyServer();
                svr.GetAllCustomers(ref tmpCustomers);
                foreach (spc2010.Customer tmpCustomer in tmpCustomers)
                    customers.Add(new Customer(tmpCustomer));
            }
            catch
            {
                message = "Failed to retrieve customers from Synergy";
                retval = MethodStatus.FatalError;
            }

            return retval;
        }

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

        public MethodStatus GetCustomerForUpdate(int customerId, out Customer customer, out byte[] grfa, out string message)
        {
            //Return status
            spc2010.Method_status sts;
            MethodStatus rsts = MethodStatus.Success;

            //Prepare parameters for Synergy method call
            spc2010.Customer tmpCustomer = new spc2010.Customer();
            customer = new Customer();
            grfa = new byte[10];
            message = "";

            //Get an instance of our main Synergy class
            spc2010.SynergyServer svr = new spc2010.SynergyServer();

            //Call the Synergy method
            sts = svr.GetCustomerForUpdate(customerId, ref tmpCustomer, ref grfa, ref message);

            //On success, return a Customer object
            switch (sts)
            {
                case spc2010.Method_status.Success:
                    customer = new Customer(tmpCustomer);
                    break;
                case spc2010.Method_status.Info_error:
                    rsts = MethodStatus.InfoError;
                    break;
                case spc2010.Method_status.Fatal_error:
                    rsts = MethodStatus.FatalError;
                    break;
            }

            return rsts;
        }

        public MethodStatus UpdateCustomer(ref Customer customer, ref byte[] grfa, out string message)
        {
            //Return status
            spc2010.Method_status sts;
            MethodStatus rsts = MethodStatus.Success;

            //Prepare parameters for Synergy method call
            spc2010.Customer c = customer.ToSynObject();
            message = "";

            //Get an instance of our main Synergy class
            spc2010.SynergyServer svr = new spc2010.SynergyServer();

            //Call the Synergy method
            sts = svr.UpdateCustomer(ref c, ref grfa, ref message);

            switch (sts)
            {
                case spc2010.Method_status.Info_error:
                    rsts = MethodStatus.InfoError;
                    break;
                case spc2010.Method_status.Fatal_error:
                    rsts = MethodStatus.FatalError;
                    break;
            }

            return rsts;
        }

    }
}
