using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using System.ComponentModel;

namespace DateTest
{
    public class MyDateField : UltraDateTimeEditor
    {

        public MyDateField()
        {
            base.NullText = "No date";
        }
        
        public new object Value
        {
            get
            {
                return base.Value;
            }
            set
            {
                System.DateTime x = (System.DateTime)value;
                if (x.Year.Equals(1))
                    base.Value = DBNull.Value;
                else
                    base.Value = value;
            }
        }

        [DefaultValue("No date")]
        public new string NullText
        {
            get
            {
                return base.NullText;
            }
            set
            {
                base.NullText = value;
            }
        }
    }
}
