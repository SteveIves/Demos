/////////////////////////////////////////////////////////////
//
// Header.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Windows.Controls;

namespace Mix07
{
    /// <summary>
    /// Class for the day names header
    /// </summary>
    [XamlResource("Mix07.Calendar.Header.xaml")]
    public class Header : MixControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width">width of the header</param>
        /// <param name="height">height of the header</param>
        /// <param name="text">text for the header</param>
        public Header(double width, double height, string text)
        {
            TextBlock textBlock = Root.FindName("text") as TextBlock;
            if (null != textBlock)
            {
                textBlock.Text = text;
            }
            RecursivelySetWidthAndHeight(Root, width, height);
        }
    }
}
