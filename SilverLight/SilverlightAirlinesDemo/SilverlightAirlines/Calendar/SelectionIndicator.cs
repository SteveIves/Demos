/////////////////////////////////////////////////////////////
//
// SelectionIndicator.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;

namespace Mix07
{
    /// <summary>
    /// Class for the selection indicator of the calendar
    /// </summary>
    [XamlResource("Mix07.Calendar.SelectionIndicator.xaml")]
    public class SelectionIndicator : MixControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width">width of the selection indicator</param>
        /// <param name="height">height of the selection indicator</param>
        public SelectionIndicator(double width, double height)
        {
            RecursivelySetWidthAndHeight(Root, width, height);
        }
    }
}
