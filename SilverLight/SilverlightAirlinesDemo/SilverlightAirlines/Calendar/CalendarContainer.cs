/////////////////////////////////////////////////////////////
//
// CalendarContainer.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Windows.Media;

namespace Mix07
{
    /// <summary>
    /// Class representing the calendar's container for months
    /// </summary>
    [XamlResource("Mix07.Calendar.CalendarContainer.xaml")]
    class CalendarContainer : MixControl
    {
        public VisualCollection Children
        {
            get { return Root.Children; }
        }
    }
}