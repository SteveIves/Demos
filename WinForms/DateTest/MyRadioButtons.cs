using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using System.ComponentModel;

namespace DateTest
{
    public class MyRadioButtons : UltraOptionSet
    {
        public MyRadioButtons()
        {
            base.BackColor = System.Drawing.Color.Transparent;

        }

        [DefaultValue(typeof(System.Drawing.Color), "Transparent")]
        public override System.Drawing.Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }
    }
}
