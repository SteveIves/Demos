using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;

namespace ControlLibrary
{
    public class MyRadioButtons : UltraOptionSet
    {
        public MyRadioButtons()
        {
            this.BorderStyle = UIElementBorderStyle.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.BackColorDisabled = System.Drawing.Color.Transparent;
        }
    }
}
