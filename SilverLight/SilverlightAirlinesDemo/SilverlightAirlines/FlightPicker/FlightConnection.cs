/////////////////////////////////////////////////////////////
//
// FlightConnection.cs
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
    /// Class representing the connecting line between flights
    /// </summary>
    [XamlResource("Mix07.FlightPicker.FlightConnection.xaml")]
    class FlightConnection : MixControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width">width of the connection</param>
        /// <param name="height">height of the connection</param>
        public FlightConnection(double width, double height)
        {
            RecursivelySetWidthAndHeight(Root, width, height);
        }
    }
}
