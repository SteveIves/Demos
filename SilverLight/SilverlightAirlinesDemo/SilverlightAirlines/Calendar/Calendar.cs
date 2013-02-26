/////////////////////////////////////////////////////////////
//
// Calendar.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Mix07
{
    /// <summary>
    /// Class representing the reusable calendar control
    /// </summary>
    [XamlResource("Mix07.Calendar.Calendar.xaml")]
    public class Calendar : MixControl
    {
        /// <summary>
        /// Event fired when dates are selected
        /// </summary>
        public event EventHandler DateRangeSelected;

        /// <summary>
        /// Number of weeks to scroll each time
        /// </summary>
        private const int ScrollWeeks = 4;

        /// <summary>
        /// Height of the earlier/later buttons
        /// </summary>
        private const int ButtonHeight = 15;

        /// <summary>
        /// Height of the day names header
        /// </summary>
        private const int HeaderHeight = 20;

        private CalendarContainer _calendarContainer;
        private List<List<Day>> _daysInWeeks;
        private Day _startDay;
        private Day _endDay;
        private bool _selectingDates;
        private List<Day> _selectedDays;
        private double _monthWidth;
        private double _dayHeight;
        private double _currentTop;
        private double _currentBottom;
        private double _laterInvalidTop;
        private DateTime _laterInvalidDate;
        private double _earlierInvalidTop;
        private DateTime _earlierInvalidDate;
        private Storyboard _scrollStoryboard;
        private DoubleAnimation _scrollAnimation;

        /// <summary>
        /// OnLoaded override
        /// </summary>
        /// <param name="e">event args</param>
        protected override void OnLoaded(EventArgs e)
        {
            base.OnLoaded(e);

            // Size the container
            RecursivelySetWidthAndHeight(Root, Width, Height);

            // Clip the calendar as it's translated up/down
            Canvas clippingContainer = new Canvas();
            clippingContainer.SetValue(Canvas.TopProperty, ButtonHeight + HeaderHeight);
            clippingContainer.Width = Width;
            clippingContainer.Height = Height - (2 * ButtonHeight) - HeaderHeight;
            RectangleGeometry rectangleGeometry = new RectangleGeometry();
            rectangleGeometry.Rect = new Rect(0, 0, clippingContainer.Width, clippingContainer.Height);
            clippingContainer.Clip = rectangleGeometry;
            Root.Children.Add(clippingContainer);

            // Create a container for holding and scrolling the calendar days
            _calendarContainer = new CalendarContainer();
            _calendarContainer.Width = clippingContainer.Width;
            _calendarContainer.Height = clippingContainer.Height;
            clippingContainer.Children.Add(_calendarContainer);

            // Get references to the storyboard and animation for later use
            _scrollStoryboard = _calendarContainer.FindName("storyboard") as Storyboard;
            _scrollAnimation = _calendarContainer.FindName("doubleAnimation") as DoubleAnimation;

            // Measure the month label text
            MonthLabel monthLabel = new MonthLabel();
            _monthWidth = _calendarContainer.Width;
            TextBlock textBlock = monthLabel.Root.FindName("text") as TextBlock;
            if (null != textBlock)
            {
                textBlock.Text = "X";
                double monthTextWidth = Math.Round(textBlock.ActualHeight);
                _monthWidth -= monthTextWidth;

                // Add month label background
                MonthLabelBackground monthLabelBackground = new MonthLabelBackground(monthTextWidth, _calendarContainer.Height);
                monthLabelBackground.SetValue(Canvas.LeftProperty, _monthWidth);
                clippingContainer.Children.Insert(0, monthLabelBackground);
            }
            _dayHeight = Math.Round(_monthWidth / 7.0);

            // Add the day names header
            string[] indexToDayAbbreviation = new string[] { "S", "M", "T", "W", "Th", "F", "S" };
            for (int i = 0; i < 7; i++)
            {
                double left = (i / 7.0) * _monthWidth;
                double width = (((i + 1) / 7.0) * _monthWidth) - left;
                Header h = new Header(width, HeaderHeight, indexToDayAbbreviation[i]);
                h.SetValue(Canvas.LeftProperty, left);
                h.SetValue(Canvas.TopProperty, ButtonHeight);
                Root.Children.Add(h);
            }

            // Add the days to the calendar
            int[] adjustToSundayOffsets = new int[] { 0, -1, -2, -3, -4, -5, -6 };
            DateTime now = DateTime.Now.Date;
            _laterInvalidDate = now.AddDays(adjustToSundayOffsets[(int)now.DayOfWeek]);
            _laterInvalidTop = 0;
            _earlierInvalidDate = _laterInvalidDate.AddDays(-7);
            _earlierInvalidTop = -_dayHeight;
            _daysInWeeks = new List<List<Day>>();
            while (true)
            {
                if (_calendarContainer.Height <= _laterInvalidTop)
                {
                    break;
                }
                AddWeek(_laterInvalidDate, _laterInvalidTop);
                _laterInvalidDate = _laterInvalidDate.AddDays(7);
                _laterInvalidTop += _dayHeight;
            }
            _currentTop = 0;
            _currentBottom = _laterInvalidTop;
            _selectedDays = new List<Day>();

            // Add the earlier/later buttons
            ButtonEarlier buttonEarlier = new ButtonEarlier(Width, ButtonHeight);
            buttonEarlier.MouseLeftButtonDown += new MouseEventHandler(earlierButton_MouseLeftButtonDown);
            Root.Children.Add(buttonEarlier);
            ButtonLater buttonLater = new ButtonLater(Width, ButtonHeight);
            buttonLater.SetValue(Canvas.TopProperty, ButtonHeight + HeaderHeight + _calendarContainer.Height);
            buttonLater.MouseLeftButtonDown += new MouseEventHandler(laterButton_MouseLeftButtonDown);
            Root.Children.Add(buttonLater);

            Root.MouseLeave += new EventHandler(Root_MouseLeave);
        }

        /// <summary>
        /// Adds a week (row of days) to the calendar
        /// </summary>
        /// <param name="startingDay">starting day of the week</param>
        /// <param name="top">y coordinate of the top of the week</param>
        /// <remarks>
        /// RemoveWeek is not currently implemented
        /// </remarks>
        private void AddWeek(DateTime startingDay, double top)
        {
            // Calculate positions
            double bottom = top + _dayHeight;
            List<Day> daysInWeek = new List<Day>();
            for (int i = 0; i < 7; i++)
            {
                double left = Math.Round((i / 7.0) * _monthWidth);
                double right = Math.Round(((i + 1.0) / 7.0) * _monthWidth);
                double width = right - left;
                double height = bottom - top;

                // Create the day and hook it up
                Day dayCanvas = new Day(startingDay, width, height);
                dayCanvas.SetValue(Canvas.LeftProperty, left);
                dayCanvas.SetValue(Canvas.TopProperty, top);
                dayCanvas.MouseEnter += new MouseEventHandler(dayCanvas_MouseEnter);
                dayCanvas.MouseLeave += new EventHandler(dayCanvas_MouseLeave);
                dayCanvas.MouseLeftButtonDown += new MouseEventHandler(dayCanvas_MouseLeftButtonDown);
                dayCanvas.MouseMove += new MouseEventHandler(dayCanvas_MouseMove);
                dayCanvas.MouseLeftButtonUp += new MouseEventHandler(dayCanvas_MouseLeftButtonUp);
                _calendarContainer.Children.Add(dayCanvas);
                daysInWeek.Add(dayCanvas);

                // The month name is centered around the 15th of the month
                if (15 == startingDay.Day)
                {
                    MonthLabel monthLabel = new MonthLabel();
                    TextBlock textBlock = monthLabel.Root.FindName("text") as TextBlock;
                    if (null != textBlock)
                    {
                        textBlock.Text = startingDay.ToString(textBlock.Text, CultureInfo.CurrentCulture);
                        textBlock.SetValue(Canvas.LeftProperty, _monthWidth);
                        textBlock.SetValue(Canvas.TopProperty, top + ((height + textBlock.ActualWidth) / 2));
                        _calendarContainer.Children.Add(monthLabel);
                    }
                }

                startingDay = startingDay.AddDays(1);
            }
            _daysInWeeks.Add(daysInWeek);
        }

        /// <summary>
        /// Scrolls up when the "earlier" button is pressed
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void earlierButton_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            // For each week, if the necessary days aren't present, add them
            for (int i = 0; i < ScrollWeeks; i++)
            {
                if (_currentTop <= _earlierInvalidTop + _dayHeight)
                {
                    AddWeek(_earlierInvalidDate, _earlierInvalidTop);
                    _earlierInvalidTop -= _dayHeight;
                    _earlierInvalidDate = _earlierInvalidDate.AddDays(-7);
                }
                _currentTop -= _dayHeight;
                _currentBottom -= _dayHeight;
            }
            // Do the scroll
            if ((null != _scrollAnimation) && (null != _scrollStoryboard))
            {
                _scrollAnimation.To = -_currentTop;
                _scrollStoryboard.Begin();
            }
        }

        /// <summary>
        /// Scrolls up when the "later" button is pressed
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void laterButton_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            // For each week, if the necessary days aren't present, add them
            for (int i = 0; i < ScrollWeeks; i++)
            {
                if (_laterInvalidTop <= _currentBottom)
                {
                    AddWeek(_laterInvalidDate, _laterInvalidTop);
                    _laterInvalidTop += _dayHeight;
                    _laterInvalidDate = _laterInvalidDate.AddDays(7);
                }
                _currentTop += _dayHeight;
                _currentBottom += _dayHeight;
            }
            // Do the scroll
            if ((null != _scrollAnimation) && (null != _scrollStoryboard))
            {
                _scrollAnimation.To = -_currentTop;
                _scrollStoryboard.Begin();
            }
        }

        /// <summary>
        /// Handles mouse going over a day
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void dayCanvas_MouseEnter(object sender, MouseEventArgs e)
        {
            Day c = (Day)sender;
            if (!_selectingDates && c.Selectable)
            {
                c.EnableHoverIndicator(true);
            }
        }

        /// <summary>
        /// Handles mouse leaving a day
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void dayCanvas_MouseLeave(object sender, EventArgs e)
        {
            Day c = (Day)sender;
            if (!_selectingDates && c.Selectable)
            {
                c.EnableHoverIndicator(false);
            }
        }

        /// <summary>
        /// Handles mouse button going down for a day
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void dayCanvas_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            // Start selecting a range
            dayCanvas_MouseLeave(sender, e);
            Day c = (Day)sender;
            if (c.Selectable)
            {
                _startDay = c;
                _endDay = c;
                _selectingDates = true;
                ShowSelectedDays();
            }
        }

        /// <summary>
        /// Handles mouse moving over a day
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void dayCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Update display if necessary
            if (_selectingDates)
            {
                Day c = (Day)sender;
                if (c.Selectable)
                {
                    _endDay = c;
                    ShowSelectedDays();
                }
            }
        }

        /// <summary>
        /// Handles mouse button going up for a day
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void dayCanvas_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            if (_selectingDates)
            {
                // Finish selecting a range
                dayCanvas_MouseMove(sender, e);
                _selectingDates = false;

                // Fire the associated event
                FireDateRangeSelectedEvent();
            }
        }

        /// <summary>
        /// Called when the mouse leaves the map
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void Root_MouseLeave(object sender, EventArgs e)
        {
            // Commit the current selection
            if (_selectingDates)
            {
                _selectingDates = false;
                FireDateRangeSelectedEvent();
            }
        }

        /// <summary>
        /// Fires the DateRangeSelected event
        /// </summary>
        private void FireDateRangeSelectedEvent()
        {
            EventHandler handler = DateRangeSelected;
            if (null != handler)
            {
                handler(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Shows the selection bar for the selected days
        /// </summary>
        private void ShowSelectedDays()
        {
            // Clear the previous selection bar
            foreach (Day dc in _selectedDays)
            {
                dc.SetSelectionIndicator(null, false);
            }
            _selectedDays.Clear();

            // Ensure start <= end
            DateTime start = _startDay.Date;
            DateTime end = _endDay.Date;
            if (end.Date < start.Date)
            {
                start = _endDay.Date;
                end = _startDay.Date;
            }

            // For each selected day in the calendar...
            for (int w = 0; w < _daysInWeeks.Count; w++)
            {
                for (int d = 0; d < _daysInWeeks[w].Count; d++)
                {
                    Day dayCanvas = _daysInWeeks[w][d];
                    if ((start.Date <= dayCanvas.Date) && (dayCanvas.Date <= end.Date))
                    {
                        // Calculate the layout
                        double width = dayCanvas.Width;
                        double height = dayCanvas.Height;
                        int numberSelectedDays = (end.Date - start.Date).Days + 1;
                        int numberSelectedDaysBeforeThis = (dayCanvas.Date - start.Date).Days;

                        // Create the selection indicator
                        SelectionIndicator selectionIndicator = new SelectionIndicator(numberSelectedDays * width, height);
                        selectionIndicator.SetValue(Canvas.LeftProperty, -(numberSelectedDaysBeforeThis * width));

                        // Style the selection indicator specially for the first/last day of the selection
                        bool endDay = false;
                        if (start.Date == dayCanvas.Date)
                        {
                            FrameworkElement startStyle = selectionIndicator.FindName("start") as FrameworkElement;
                            if (null != startStyle)
                            {
                                startStyle.Width = width;
                                startStyle.Height = height;
                                startStyle.Opacity = 1;
                            }
                            endDay = true;
                        }
                        else if (end.Date == dayCanvas.Date)
                        {
                            FrameworkElement endStyle = selectionIndicator.FindName("end") as FrameworkElement;
                            if (null != endStyle)
                            {
                                endStyle.SetValue(Canvas.LeftProperty, numberSelectedDaysBeforeThis * width);
                                endStyle.Width = width;
                                endStyle.Height = height;
                                endStyle.Opacity = 1;
                            }
                            endDay = true;
                        }

                        // Add the selection indicator
                        dayCanvas.SetSelectionIndicator(selectionIndicator, endDay);
                        _selectedDays.Add(dayCanvas);
                    }
                }
            }
        }

        /// <summary>
        /// Start date of the current selection
        /// </summary>
        public DateTime? SelectionStartDate
        {
            get
            {
                return (null != _startDay) ? _startDay.Date : (DateTime?)null;
            }
        }

        /// <summary>
        /// End date of the current selection
        /// </summary>
        public DateTime? SelectionEndDate
        {
            get
            {
                return (null != _endDay) ? _endDay.Date : (DateTime?)null;
            }
        }
    }
}
