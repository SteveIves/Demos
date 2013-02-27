using System;
using System.Collections.Generic;
using System.Text;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinEditors;
using System.ComponentModel;

namespace DateTest
{
    public class RealRadioButtons : MyRadioButtons
    {

        public const ValueListItemsCollection x = null;

        public RealRadioButtons()
        {
            base.Items.Add(new ValueListItem(1,"A"));
            base.Items.Add(new ValueListItem(2,"B"));
            base.Items.Add(new ValueListItem(3,"C"));

        }


        [DefaultValue(x)]
        public new ValueListItemsCollection Items
        {
            get
            {
                return base.Items;
            }
        }
    }
}
