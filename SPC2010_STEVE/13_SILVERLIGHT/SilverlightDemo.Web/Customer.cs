using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SilverlightDemo.Web
{
    /// <summary>
    /// Summary description for Customer
    /// </summary>
    [DataContract]
    public class Customer
    {
        public Customer()
        {
        }

        /*
        public Customer(int customerID, string customerName)
        {
            CustomerId = customerID;
            CustomerName = customerName;
        }
        */

        public Customer(spc2010.Customer customer)
        {
            CustomerId = customer.Customer_id;
            CustomerName = customer.Name;
            DateCreated = customer.Date_created;
            DateModified = customer.Date_modified;
            Status = customer.Status;
        }

        public spc2010.Customer ToSynObject()
        {
            spc2010.Customer c = new spc2010.Customer();
            c.Customer_id = CustomerId;
            c.Name = CustomerName;
            c.Date_created = DateCreated;
            c.Date_modified = DateModified;
            c.Status = Status;
            return c;
        }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public string CustomerName { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }

        [DataMember]
        public DateTime DateModified { get; set; }

        [DataMember]
        public string Status { get; set; }

    }
}
