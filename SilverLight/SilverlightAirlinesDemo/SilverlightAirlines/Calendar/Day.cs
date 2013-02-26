/////////////////////////////////////////////////////////////
//
// Day.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Mix07
{
    /// <summary>
    /// Class representing a day in the calendar
    /// </summary>
    [XamlResource("Mix07.Calendar.Day.xaml")]
    public class Day : MixControl
    {
        private readonly DateTime _date;
        private readonly bool _selectable;
        private readonly TextBlock _text;
        private readonly TextBlock _endText;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="date">date of the day</param>
        /// <param name="width">width of the day</param>
        /// <param name="height">height of the day</param>
        public Day(DateTime date, double width, double height)
        {
            _date = date;
            _selectable = DateTime.Now <= _date;

            // Position and clip the day
            Width = width;
            Height = height;
            RectangleGeometry clippingRectangle = new RectangleGeometry();
            clippingRectangle.Rect = new Rect(0, 0, width, height);
            Root.Clip = clippingRectangle;

            // Add a background for hover detection
            SolidColorBrush backgroundBrush = new SolidColorBrush();
            backgroundBrush.Color = Color.FromArgb(0, 0, 0, 0);
            Root.Background = backgroundBrush;

            // Set the texts if present
            _text = Root.FindName("text") as TextBlock;
            if (null != _text)
            {
                _text.Text = _date.Day.ToString(CultureInfo.CurrentCulture);
            }
            _endText = Root.FindName("endText") as TextBlock;
            if (null != _endText)
            {
                _endText.Text = _date.Day.ToString(CultureInfo.CurrentCulture);
                // Set Opacity to 1 so ActualWidth will be correct
                _endText.Opacity = 1;
            }

            // Position the children
            RecursivelySetWidthAndHeight(Root, width, height);
            if (null != _endText)
            {
                // Reset Opacity
                _endText.Opacity = 0;
            }

            // Set the day's appearance accordingly
            if (0 == Date.Month % 2)
            {
                UIElement alternatingMonthStyle = (UIElement)Root.FindName("alternatingMonthStyle") as UIElement;
                if (null != alternatingMonthStyle)
                {
                    alternatingMonthStyle.Opacity = 1.0;
                }
            }
            if ((DayOfWeek.Saturday == Date.DayOfWeek) || (DayOfWeek.Sunday == Date.DayOfWeek))
            {
                UIElement weekendStyle = (UIElement)Root.FindName("weekendStyle") as UIElement;
                if (null != weekendStyle)
                {
                    weekendStyle.Opacity = 1.0;
                }
            }

            // Cross out unselectable dates
            if (!_selectable)
            {
                Line crossOut = new Line();
                crossOut.X1 = 0;
                crossOut.Y1 = Height;
                crossOut.X2 = Width;
                crossOut.Y2 = 0;
                SolidColorBrush solidColorBrush = new SolidColorBrush();
                solidColorBrush.Color = Color.FromRgb(127, 127, 127);
                crossOut.Stroke = solidColorBrush;
                Root.Children.Add(crossOut);
            }
        }

        /// <summary>
        /// Date represented by the object
        /// </summary>
        public DateTime Date
        {
            get
            {
                return _date;
            }
        }

        /// <summary>
        /// True iff the day is selectable (i.e., not in the past)
        /// </summary>
        public bool Selectable
        {
            get
            {
                return _selectable;
            }
        }

        /// <summary>
        /// Displays the selection indicator for this day
        /// </summary>
        /// <param name="selectionIndicator">SelectionIndicator to use</param>
        /// <param name="endDay">true iff this is at the end of the selection</param>
        public void SetSelectionIndicator(SelectionIndicator selectionIndicator, bool endDay)
        {
            // Add the indicator to the right place
            Panel selectionContainer = Root.FindName("selectionContainer") as Panel;
            if (null != selectionContainer)
            {
                if (null == selectionIndicator)
                {
                    selectionContainer.Children.Clear();
                }
                else
                {
                    selectionContainer.Children.Add(selectionIndicator);
                }
                if (null != _endText)
                {
                    double endOpacity = (!endDay || (null == selectionIndicator)) ? 0 : 1;
                    _endText.Opacity = endOpacity;
                    _text.Opacity = 1 - endOpacity;
                }
            }
        }

        /// <summary>
        /// Enable/disable the hover indicator
        /// </summary>
        /// <param name="enable">true to enable</param>
        public void EnableHoverIndicator(bool enable)
        {
            PlayNamedStoryboard(enable ? "EnableHoverStoryboard" : "DisableHoverStoryboard");
        }

        /// <summary>
        /// Play the specified storyboard
        /// </summary>
        /// <param name="name">storyboard to play</param>
        private void PlayNamedStoryboard(string name)
        {
            Storyboard storyboard = Root.FindName(name) as Storyboard;
            if (null != storyboard)
            {
                storyboard.Begin();
            }
        }
    }
}
