using System;
using System.Collections.Generic;
using System.Text;

namespace MyClassLibrary
{
    public enum ReviewFrequency
    {
        Never = 1,
        Monthly = 2,
        Quarterly = 3,
        Biannually = 4,
        Annually = 5
    }

    public class Employee
    {
        private string pFirstName;
        private string pLastName;
        private string pPhotoFile;
        private DateTime pHireDate;
        private ReviewFrequency pReviewed;

        private bool pChanged;

        public Employee()
        {
            TrackChanges();
        }

        public void TrackChanges()
        {
            pChanged=false;
        }

        public bool Changed
        {
            get { return pChanged; }
        }

        public string FirstName
        {
            get { return pFirstName; }
            set {
                if (!value.Equals(pFirstName))
                {
                    pFirstName = value;
                    pChanged = true;
                }
            }
        }

        public string LastName
        {
            get { return pLastName; }
            set
            {
                if (!value.Equals(pLastName))
                {
                    pLastName = value;
                    pChanged = true;
                }
            }
        }

        public string PhotoFile
        {
            get { return pPhotoFile; }
            set
            {
                if (!value.Equals(pPhotoFile))
                {
                    pPhotoFile = value;
                    pChanged = true;
                }
            }
        }

        public DateTime HireDate
        {
            get { return pHireDate; }
            set
            {
                if (!value.Equals(pHireDate))
                {
                    pHireDate = value;
                    pChanged = true;
                }
            }
        }

        public ReviewFrequency Reviewed
        {
            get { return pReviewed; }
            set
            {
                if (!value.Equals(pReviewed))
                {
                    pReviewed = value;
                    pChanged = true;
                }
            }
        }
    
    }
}
