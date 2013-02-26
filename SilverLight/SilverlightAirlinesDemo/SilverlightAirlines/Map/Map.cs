/////////////////////////////////////////////////////////////
//
// Map.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Mix07
{
    /// <summary>
    /// Map of cities that displays flights
    /// </summary>
    [XamlResource("Mix07.Map.Map.xaml")]
    public class Map : MixControl
    {
        /// <summary>
        /// Name of the container Canvas in the template
        /// </summary>
        private const string ContainerName = "Container";

        /// <summary>
        /// Name of the ScaleTransform in the template
        /// </summary>
        private const string ScaleTransformName = "ScaleTransform";

        /// <summary>
        /// Name of the plane glyph FrameworkElement in the template
        /// </summary>
        private const string PlaneGlyphName = "PlaneGlyph";

        /// <summary>
        /// Name of the plane glyph RotateTransform in the template
        /// </summary>
        private const string PlaneGlyphRotateTransformName = "PlaneGlyphRotateTransform";

        /// <summary>
        /// Name of the plane glyph ScaleTransform in the template
        /// </summary>
        private const string PlaneGlyphScaleTransformName = "PlaneGlyphScaleTransform";

        /// <summary>
        /// Name of the plane glyph TranslateTransform in the template
        /// </summary>
        private const string PlaneGlyphTranslateTransformName = "PlaneGlyphTranslateTransform";

        /// <summary>
        /// Name of the flight animation StoryBoard in the template
        /// </summary>
        private const string FlightAnimationName = "FlightAnimation";

        /// <summary>
        /// Name of the flight animation X translation animation in the template
        /// </summary>
        private const string FlightAnimationTranformXName = "FlightAnimationTranformX";

        /// <summary>
        /// Name of the flight animation Y translation animation in the template
        /// </summary>
        private const string FlightAnimationTranformYName = "FlightAnimationTranformY";

        /// <summary>
        /// Name of the flight animation X scale animation in the template
        /// </summary>
        private const string FlightAnimationScaleXName = "FlightAnimationScaleX";

        /// <summary>
        /// Name of the flight animation Y scale animation in the template
        /// </summary>
        private const string FlightAnimationScaleYName = "FlightAnimationScaleY";

        /// <summary>
        /// Name of the flight animation opacity animation in the template
        /// </summary>
        private const string FlightAnimationOpacityName = "FlightAnimationOpacity";

        /// <summary>
        /// Name of the flight animation rotation animation in the template
        /// </summary>
        private const string FlightAnimationRotationName = "FlightAnimationRotation";

        /// <summary>
        /// Number of seconds to animate a flight across the width of the entire map
        /// </summary>
        private const double AnimationDuration = 5;

        /// <summary>
        /// Number of seconds to animate a flight transition (i.e. angle/opacity change)
        /// </summary>
        private const double AnimationTransitionDuration = .1;

        /// <summary>
        /// Amount to initially scale the size of the animation glyph
        /// </summary>
        private const double AnimationInitialScale = .5;

        /// <summary>
        /// Amount to scale the size of the animation glyph in the middle of the flight
        /// </summary>
        private const double AnimationEnlargedScale = 1.5;
        
        /// <summary>
        /// Number of seconds to wait before playing the animation
        /// </summary>
        private const double AnimationInitialDelay = 1.0;

        /// <summary>
        /// Amount to scale the size of the plane glyph when selecting a flight
        /// </summary>
        private const double PlaneGlyphSelectionScale = .5;

        /// <summary>
        /// User selection between two cities on the map
        /// </summary>
        private MapSelection _selection;

        /// <summary>
        /// Path used to show a route between two cities
        /// </summary>
        private List<MapPathSegment> _path;

        /// <summary>
        /// Little plane we can draw on the map
        /// </summary>
        private FrameworkElement _planeGlyph;

        /// <summary>
        /// Transformation to rotate the plane glyph
        /// </summary>
        private RotateTransform _planeGlyphRotation;

        /// <summary>
        /// Transformation to move the plane glyph
        /// </summary>
        private TranslateTransform _planeGlyphTranslation;

        /// <summary>
        /// Transformation to scale the plane glyph
        /// </summary>
        private ScaleTransform _planeGlyphScale;

        /// <summary>
        /// Animation used to show an itinerary (if this is null, we won't animate)
        /// </summary>
        private Storyboard _animation;

        /// <summary>
        /// Animation used to change the opacity
        /// </summary>
        private DoubleAnimationUsingKeyFrames _opacityAnimation;

        /// <summary>
        /// Animation used to change the X coordinate
        /// </summary>
        private DoubleAnimationUsingKeyFrames _translateXAnimation;

        /// <summary>
        /// Animation used to change the Y coordinate
        /// </summary>
        private DoubleAnimationUsingKeyFrames _translateYAnimation;

        /// <summary>
        /// Animation used to scale the width
        /// </summary>
        private DoubleAnimationUsingKeyFrames _scaleXAnimation;

        /// <summary>
        /// Animation used to scale the height
        /// </summary>
        private DoubleAnimationUsingKeyFrames _scaleYAnimation;

        /// <summary>
        /// Animation used to rotate
        /// </summary>
        private DoubleAnimationUsingKeyFrames _rotateAnimation;

        private MapPointCollection _points;
        private City _selectedOrigin;
        private MapPoint _origin;
        private City _selectedDestination;
        private MapPoint _destination;
        private Canvas _pointContainer;

        /// <summary>
        /// Collection of MapPoints shown on the map
        /// </summary>
        public MapPointCollection Points
        {
            get
            {
                return _points;
            }
        }

        /// <summary>
        /// Origin of the currently drawn flight
        /// </summary>
        public City Origin
        {
            get
            {
                return _selectedOrigin;
            }
        }

        /// <summary>
        /// Destination of the currently drawn flight
        /// </summary>
        public City Destination
        {
            get
            {
                return _selectedDestination;
            }
        }

        /// <summary>
        /// Container to display the points
        /// </summary>
        internal Canvas PointContainer
        {
            get
            {
                if (_pointContainer == null)
                {
                    Update();
                }
                return _pointContainer;
            }
        }

        /// <summary>
        /// Event raised when a destination is selected (or when a destination was
        /// selected but no longer is)
        /// </summary>
        public event EventHandler DestinationSelected;

        /// <summary>
        /// Constructor
        /// </summary>
        public Map()
            : base()
        {
            _points = new MapPointCollection(this);
            _path = new List<MapPathSegment>();
            Root.MouseLeave += new EventHandler(Root_MouseLeave);

            // Create the map points
            foreach (City city in FlightService.GetDestinations())
            {
                Points.Add(city);
            }

            // Create the selection line
            _selection = new MapSelection();
            _selection.SetValue(Canvas.ZIndexProperty, 5);
            _selection.Visibility = Visibility.Collapsed;
            _pointContainer.Children.Add(_selection);
        }

        /// <summary>
        /// Update the values of the template when loaded
        /// </summary>
        protected override void OnLoaded(EventArgs e)
        {
            base.OnLoaded(e);

            Update();

            // Add event handlers for the template
            _pointContainer.MouseLeftButtonDown += new MouseEventHandler(OnMouseDown);
            _pointContainer.MouseMove += new MouseEventHandler(OnMouseMove);
            _pointContainer.MouseLeftButtonUp += new MouseEventHandler(OnMouseUp);
        }

        /// <summary>
        /// Update the values of the template
        /// </summary>
        private void Update()
        {
            Debug.Assert(Root != null);

            // Get the container template
            _pointContainer = Root.FindName(ContainerName) as Canvas;
            Debug.Assert(_pointContainer != null);

            // Scale the container template
            ScaleTransform scaleTransform = Root.FindName(ScaleTransformName) as ScaleTransform;
            if (scaleTransform == null)
            {
                scaleTransform = new ScaleTransform();
                scaleTransform.SetValue(DependencyObject.NameProperty, ScaleTransformName);
                _pointContainer.RenderTransform = scaleTransform;
            }
            scaleTransform.ScaleX = Width / _pointContainer.Width;
            scaleTransform.ScaleY = Height / _pointContainer.Height;

            // Get the plane glyph
            _planeGlyph = FindName(PlaneGlyphName) as FrameworkElement;
            Debug.Assert(_planeGlyph != null);
            _planeGlyphRotation = FindName(PlaneGlyphRotateTransformName) as RotateTransform;
            Debug.Assert(_planeGlyphRotation != null);
            _planeGlyphTranslation = FindName(PlaneGlyphTranslateTransformName) as TranslateTransform;
            Debug.Assert(_planeGlyphTranslation != null);
            _planeGlyphScale = FindName(PlaneGlyphScaleTransformName) as ScaleTransform;
            Debug.Assert(_planeGlyphScale != null);

            // Get the animations
            _animation = FindName(FlightAnimationName) as Storyboard;
            if (_animation != null)
            {
                _translateXAnimation = FindName(FlightAnimationTranformXName) as DoubleAnimationUsingKeyFrames;
                _translateYAnimation = FindName(FlightAnimationTranformYName) as DoubleAnimationUsingKeyFrames;
                _scaleXAnimation = FindName(FlightAnimationScaleXName) as DoubleAnimationUsingKeyFrames;
                _scaleYAnimation = FindName(FlightAnimationScaleYName) as DoubleAnimationUsingKeyFrames;
                _opacityAnimation = FindName(FlightAnimationOpacityName) as DoubleAnimationUsingKeyFrames;
                _rotateAnimation = FindName(FlightAnimationRotationName) as DoubleAnimationUsingKeyFrames;

                // Don't animate if we didn't get everything we need
                if ((_translateXAnimation == null) ||
                    (_translateYAnimation == null) ||
                    (_scaleYAnimation == null) ||
                    (_scaleXAnimation == null) ||
                    (_rotateAnimation == null) ||
                    (_opacityAnimation == null))
                {
                    _animation = null;
                }
            }
        }

        /// <summary>
        /// Find the center of a rectangle
        /// </summary>
        /// <param name="bounds">Rectangle</param>
        /// <returns>Point at the center</returns>
        private static Point GetCenter(Rect bounds)
        {
            return new Point(bounds.X + bounds.Width / 2.0, bounds.Y + bounds.Height / 2.0);
        }

        /// <summary>
        /// Handler for mouse down
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            _origin = _points.GetMapPoint(e.GetPosition(_pointContainer));
            if (_origin == null)
            {
                return;
            }

            HideItinerary();

            _selectedOrigin = null;
            _selectedDestination = null;

            _planeGlyph.Opacity = 1;
            _planeGlyphScale.ScaleX = PlaneGlyphSelectionScale;
            _planeGlyphScale.ScaleY = PlaneGlyphSelectionScale;

            _selection.Start = GetCenter(_origin.RootBounds);
            OnMouseMove(sender, e);
            _selection.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Handler for mouse move
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_origin == null)
            {
                return;
            }

            Point location = e.GetPosition(_pointContainer);
            MapPoint current = _points.GetMapPoint(location);
            if (current != null && current != _origin)
            {
                _destination = current;
                location = GetCenter(_destination.RootBounds);
            }
            else
            {
                _destination = null;
            }

            _selection.End = location;
            _planeGlyphTranslation.X = location.X;
            _planeGlyphTranslation.Y = location.Y;
            _planeGlyphRotation.Angle = ComputeAngle(_origin.City.Coordinates, location);
        }

        /// <summary>
        /// Handler for mouse up
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (_origin == null)
            {
                return;
            }

            HidePlaneGlyph();

            EventHandler handler = DestinationSelected;
            if (_destination != null)
            {
                if (handler != null)
                {
                    _selectedOrigin = _origin.City;
                    _selectedDestination = _destination.City;
                    handler(this, EventArgs.Empty);
                }
            }
            else
            {
                _selection.Visibility = Visibility.Collapsed;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }

            _origin = null;
            _destination = null;
        }

        /// <summary>
        /// Cancel selection when the user leaves the map
        /// </summary>
        private void Root_MouseLeave(object sender, EventArgs e)
        {
            if (_origin != null && _selection.Visibility == Visibility.Visible)
            {
                _selection.Visibility = Visibility.Collapsed;
                HidePlaneGlyph();
                EventHandler handler = DestinationSelected;
                if (handler != null)
                    handler(this, EventArgs.Empty);
                _origin = null;
                _destination = null;
            }
        }

        /// <summary>
        /// Reset the plane glyph so it is not visible (and can be used for animations)
        /// </summary>
        private void HidePlaneGlyph()
        {
            _planeGlyph.Opacity = 0;
            _planeGlyphTranslation.X = 0;
            _planeGlyphTranslation.Y = 0;
            _planeGlyphRotation.Angle = 0;
            _planeGlyphScale.ScaleX = 1;
            _planeGlyphScale.ScaleY = 1;
        }

        /// <summary>
        /// Display a graphical indicator for an itinerary and animate
        /// an icon along its path
        /// </summary>
        /// <param name="itinerary">Itinerary</param>
        public void ShowItinerary(Itinerary itinerary)
        {
            // Always hide any itinerary that was displaying
            HideItinerary();
            if (itinerary == null || itinerary.Flights.Count <= 0)
                return;
            Flight firstFlight = itinerary.Flights[0];

            // Points between each pair of cities
            Point last = GetCenter(_points[firstFlight.Origin.Name].RootBounds);
            Point next = GetCenter(_points[firstFlight.Destination.Name].RootBounds);

            // Angle of the last segment (to prevent rotating 359 degrees instead of
            // 1 degree when we want to change from 359 degrees to 0 degrees)
            double lastAngle = ComputeAngle(last, next);

            // Amount of time already "flown" (we always add a little extra so the
            // animation doesn't repeat too quickly and it doesn't look jumpy when you
            // mouse over a sequence of itineraries)
            double time = AnimationInitialDelay;

            // Setup the animation
            if (_animation != null)
            {
                // Compute the total time spent in the air (so we can reset
                // the opacity to zero after the rest of the animations are done)
                double totalTime = time;
                foreach (Flight flight in itinerary.Flights)
                    totalTime += flight.Origin.DistanceTo(flight.Destination) / Width * AnimationDuration;

                // Clear the key frames from prior animations
                _translateXAnimation.KeyFrames.Clear();
                _translateYAnimation.KeyFrames.Clear();
                _scaleXAnimation.KeyFrames.Clear();
                _scaleYAnimation.KeyFrames.Clear();
                _opacityAnimation.KeyFrames.Clear();
                _rotateAnimation.KeyFrames.Clear();

                // Start at the right coordinates
                CreateKeyFrame(_translateXAnimation, time, last.X);
                CreateKeyFrame(_translateYAnimation, time, last.Y);

                // Start scaled small, then big in the middle, then small again at the end
                CreateKeyFrame(_scaleXAnimation, time, AnimationInitialScale);
                CreateKeyFrame(_scaleYAnimation, time, AnimationInitialScale);
                CreateKeyFrame(_scaleXAnimation, time + (totalTime - time) / 2, AnimationEnlargedScale);
                CreateKeyFrame(_scaleYAnimation, time + (totalTime - time) / 2, AnimationEnlargedScale);
                CreateKeyFrame(_scaleXAnimation, totalTime, AnimationInitialScale);
                CreateKeyFrame(_scaleYAnimation, totalTime, AnimationInitialScale);

                // Start at the right opacity (note we force the initial animation delay to be hidden)
                CreateKeyFrame(_opacityAnimation, 0, 0);
                CreateKeyFrame(_opacityAnimation, time, 0);
                CreateKeyFrame(_opacityAnimation, time + AnimationTransitionDuration, 1);

                // Keep the opacity until the end
                CreateKeyFrame(_opacityAnimation, totalTime - AnimationTransitionDuration, 1);
                CreateKeyFrame(_opacityAnimation, totalTime, 0);

                // Rotate to the initial angle
                CreateKeyFrame(_rotateAnimation, time, lastAngle);
            }   

            // Create segments for each flight
            foreach (Flight flight in itinerary.Flights)
            {
                next = GetCenter(_points[flight.Destination.Name].RootBounds);

                // Create the segment
                MapPathSegment segment = new MapPathSegment();
                segment.SetValue(Canvas.ZIndexProperty, 5);
                segment.Start = last;
                segment.End = next;
                _path.Add(segment);
                _pointContainer.Children.Add(segment);

                // Animate this segment
                if (_animation != null)
                {
                    // Compute the angle and adjust it so we never change
                    // more than 180 degrees
                    double angle = ComputeAngle(last, next);
                    double delta = angle - lastAngle;
                    if (delta > 180)
                    {
                        angle -= 360;
                    }
                    else if (delta < -180)
                    {
                        angle += 360;
                    }
                    lastAngle = angle;

                    // Compute the animation's duration for this flight
                    double angleStart = time + AnimationTransitionDuration;
                    time += flight.Origin.DistanceTo(flight.Destination) / Width * AnimationDuration;
                    double angleEnd = time - AnimationTransitionDuration;

                    // Setup the angle
                    CreateKeyFrame(_rotateAnimation, angleStart, angle);
                    CreateKeyFrame(_rotateAnimation, angleEnd, angle);

                    // Add the new coordinates
                    CreateKeyFrame(_translateXAnimation, time, next.X);
                    CreateKeyFrame(_translateYAnimation, time, next.Y);
                }

                last = next;
            }

            // Play the animation
            if (_animation != null)
                _animation.Begin();
        }

        /// <summary>
        /// Hide the graphical indicator for an itinerary
        /// </summary>
        public void HideItinerary()
        {
            // Stop animating any itinerary we're going to hide
            if (_animation != null)
                _animation.Stop();

            // Remove the path from the map and hide it
            foreach (MapPathSegment segment in _path)
                _pointContainer.Children.Remove(segment);
            _path.Clear();
        }

        /// <summary>
        /// Create a new SplineDoubleKeyFrame
        /// </summary>
        /// <param name="animation">Animation to hold the keyframe</param>
        /// <param name="durationInSeconds">Duration of the key frame in seconds</param>
        /// <param name="value">Value of the key frame</param>
        private static void CreateKeyFrame(DoubleAnimationUsingKeyFrames animation, double durationInSeconds, double value)
        {
            SplineDoubleKeyFrame keyFrame = new SplineDoubleKeyFrame();
            keyFrame.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(durationInSeconds));
            keyFrame.Value = value;
            animation.KeyFrames.Add(keyFrame);
        }

        /// <summary>
        /// Computes the angle between a horizontal line through the first point
        /// and the line created by the first and second points.
        /// </summary>
        /// <param name="first">Point</param>
        /// <param name="second">Point</param>
        /// <returns>Angle (in degrees)</returns>
        private static double ComputeAngle(Point first, Point second)
        {
            return Math.Atan2(second.Y - first.Y, second.X - first.X) * 180.0 / Math.PI;
        }
    }
}
