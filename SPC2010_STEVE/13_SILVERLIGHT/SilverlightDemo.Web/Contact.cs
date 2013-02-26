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
    public class Contact
    {
        public Contact()
        {
        }

        public Contact(spc2010.Contact contact)
        {
            CustomerId = contact.Customer_id;
            ContactId = contact.Contact_id;
            Salutation = contact.Salutation;
            FirstName = contact.First_name;
            LastName = contact.Last_name;
            FriendlyName = contact.Friendly_name;
            if (contact.Work_phone > 0)
                WorkPhone = contact.Work_phone.ToString("(000) 000-0000");
            if (contact.Home_phone > 0)
                HomePhone = contact.Home_phone.ToString("(000) 000-0000");
            Email = contact.Email;
            Department = contact.Department;
            Title = contact.Title;
        }

        [DataMember]
        [Key]
        [Display(Name = "Customer ID", Description = "The customer ID associated with this contact.")]
        [Required(ErrorMessage = "Customer ID is a required field.")]
        public int CustomerId { get; set; }

        [DataMember]
        [Key]
        [Display(Name = "Contact ID", Description = "This contacts uniquie contact ID.")]
        [Required(ErrorMessage = "Contact ID is a required field")]
        public int ContactId { get; set; }

        [DataMember]
        [Display(Name = "Salutation", Description = "The salutation associated with this contact, e.g. Mr, Mrs, Miss, Dr.")]
        [StringLength(5, ErrorMessage = "Salutation is too long.")]
        public string Salutation { get; set; }

        [DataMember]
        [Display(Name = "First Name", Description = "The contacts first name.")]
        [Required(ErrorMessage = "First name is a required field")]
        [StringLength(30, ErrorMessage = "First name is too long.")]
        public string FirstName { get; set; }

        [DataMember]
        [Display(Name = "Last Name", Description = "The contacts last name.")]
        [Required(ErrorMessage = "Last name is a required field")]
        [StringLength(30, ErrorMessage = "Last name is too long.")]
        public string LastName { get; set; }

        [DataMember]
        [Display(Name = "Friendly Name", Description = "The name usually used to address this contact. This is often the combination of first name and last name.")]
        [StringLength(60, ErrorMessage = "Friendly name is too long.")]
        public string FriendlyName { get; set; }

        [DataMember]
        [Display(Name = "Work Phone #", Description = "The contacts work telephone number.")]
        public string WorkPhone { get; set; }

        [DataMember]
        [Display(Name = "Home Phone #", Description = "The contacts home telephone number.")]
        public string HomePhone { get; set; }

        [DataMember]
        [Display(Name = "Email Address", Description = "The contacts email address.")]
        [Required(ErrorMessage = "Email Address is a required field.")]
        [StringLength(50, ErrorMessage = "Email address is too long.")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [DataMember]
        [Display(Name = "Department", Description = "The contacts department.")]
        [StringLength(15, ErrorMessage = "Department is too long.")]
        public string Department { get; set; }

        [DataMember]
        [Display(Name = "Title", Description = "The contacts title.")]
        [StringLength(25, ErrorMessage = "Title is too long.")]
        public string Title { get; set; }
    }
}
