using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace WebServer
{
    [DataContract]
    public class Person
    {
        public Person()
        {
            FirstName = "Albert";
            LastName = "Einstein";
            StreetAddress = "1234 Main Street";
            City = "Bird Island";
            State = "MN";
            Zip = "12345";
            EmailAddress = "albert.einstein@rccbi.com";
            PhoneNumber = "(555) 555-5555";
        }

        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string StreetAddress { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Zip { get; set; }
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
    }
}
