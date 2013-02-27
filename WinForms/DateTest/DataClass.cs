using System;
using System.Collections.Generic;
using System.Text;

namespace DateTest
{
    public class DataClass
    {
        private DateTime pDateField;

        public DateTime DateField
        {
            get
            {
                return pDateField;
            }
            set
            {
                pDateField = value;
            }
        }
    }
}
