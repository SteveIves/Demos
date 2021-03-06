/////////////////////////////////////////////////////////////
//
// ButtonLater.cs
//
// � 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;

namespace Mix07
{
    /// <summary>
    /// Class representing the "later dates" button
    /// </summary>
    [XamlResource("Mix07.Calendar.ButtonLater.xaml")]
    class ButtonLater : CalendarButton
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width">width of the button</param>
        /// <param name="height">height of the button</param>
        public ButtonLater(double width, double height)
            : base(width, height)
        {
        }
    }
}