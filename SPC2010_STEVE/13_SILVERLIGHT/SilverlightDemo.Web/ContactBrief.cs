using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SilverlightDemo.Web
{
    /// <summary>
    /// Summary description for Contact
    /// </summary>
    [DataContract]
    public class ContactBrief
    {
        public ContactBrief()
        {
        }

        public ContactBrief(spc2010.Contact contact)
        {
            CustomerId = contact.Customer_id;
            ContactId = contact.Contact_id;
            FriendlyName = contact.Friendly_name;
        }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public int ContactId { get; set; }

        [DataMember]
        public string FriendlyName { get; set; }

    }
}
