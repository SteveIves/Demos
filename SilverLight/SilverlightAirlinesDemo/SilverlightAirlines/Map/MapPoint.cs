/////////////////////////////////////////////////////////////
//
// MapPoint.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Mix07
{
    /// <summary>
    /// Individual point on a map that represents a City
    /// </summary>
    [XamlResource("Mix07.Map.MapPoint.xaml")]
    public class MapPoint : MixControl
    {
        /// <summary>
        /// Name of the Label TextBlock in the template
        /// </summary>
        private const string LabelName = "Label";

        private City _city;

        /// <summary>
        /// City represented by the MapPoint
        /// </summary>
        public City City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                Update();
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MapPoint()
            : this(null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="city">City represented by the MapPoint</param>
        public MapPoint(City city)
            : base()
        {
            _city = city;
        }

        /// <summary>
        /// Update the values of the template when loaded
        /// </summary>
        /// <param name="e">event args</param>
        protected override void OnLoaded(EventArgs e)
        {
            base.OnLoaded(e);
            Update();
            SetValue(Canvas.ZIndexProperty, 30);
        }

        /// <summary>
        /// Update the values of the template
        /// </summary>
        private void Update()
        {
            if (_city == null)
            {
                return;
            }

            Debug.Assert(Root != null);
            SetValue(DependencyObject.NameProperty, _city.Name);
            Root.SetValue(Canvas.LeftProperty, _city.Coordinates.X - Root.Width / 2.0);
            Root.SetValue(Canvas.TopProperty, _city.Coordinates.Y - Root.Height / 2.0);

            TextBlock label = Root.FindName(LabelName) as TextBlock;
            Debug.Assert(label != null);
            label.Text = _city.Name;
        }
    }
}
