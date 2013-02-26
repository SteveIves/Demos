using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace SilverlightDemo.Web
{
    /// <summary>
    /// Summary description for Address
    /// </summary>
    [DataContract]
    public class Address
    {
        public Address()
        {
        }

        public Address(spc2010.Address address)
        {
            CustomerId = address.Customer_id;
            AddressId = address.Address_id;

            switch (address.Address_type)
            {
                case spc2010.Address_type.Business:
                    AddressType = "Business Address";
                    break;
                case spc2010.Address_type.Home:
                    AddressType = "Home Address";
                    break;
                default:
                    AddressType = "Other Address";
                    break;
            }

            Street = address.Address1;
            City = address.City;
            State = address.State;
            Zip = address.Postal_code;
        }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public int AddressId { get; set; }

        [DataMember]
        public string AddressType { get; set; }

        [DataMember]
        public string Street { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Zip { get; set; }
    }
}
