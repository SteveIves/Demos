/////////////////////////////////////////////////////////////
//
// CalendarButton.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace Mix07
{
    /// <summary>
    /// Base class for buttons on the calendar
    /// </summary>
    public class CalendarButton : MixControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width">width of the button</param>
        /// <param name="height">height of the button</param>
        public CalendarButton(double width, double height)
        {
            Rectangle background = FindName("Background") as Rectangle;
            if (background != null)
                RecursivelySetWidthAndHeight(background, width, height);

            Canvas arrow = FindName("Arrow") as Canvas;
            if (arrow != null)
            {
                arrow.SetValue(Canvas.TopProperty, height / 2);
                arrow.SetValue(Canvas.LeftProperty, width / 2);
            }
        }
    }
}