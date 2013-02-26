/////////////////////////////////////////////////////////////
//
// MapPathSegment.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Mix07
{
    /// <summary>
    /// Segment of a Map Path
    /// </summary>
    [XamlResource("Mix07.Map.MapPathSegment.xaml")]
    public class MapPathSegment : MixControl
    {
        /// <summary>
        /// Pieces of the path used when updating
        /// </summary>
        private PathFigure _figure;
        private LineSegment _line;
        private Point _start;
        private Point _end;

        /// <summary>
        /// Start of the segment
        /// </summary>
        public Point Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
                Update();
            }
        }

        /// <summary>
        /// End of the segment
        /// </summary>
        public Point End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
                Update();
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MapPathSegment()
            : base()
        {
            CreatePath();
        }

        /// <summary>
        /// Create the path displayed by the segment
        /// </summary>
        private void CreatePath()
        {
            Path path = FindName("Path") as Path;
            if (path == null)
            {
                path = new Path();
                Root.Children.Add(path);
                path.Stroke = new SolidColorBrush(Colors.Purple);
                path.StrokeThickness = 5;
            }

            PathGeometry geometry = new PathGeometry();
            path.Data = geometry;
            geometry.FillRule = FillRule.Nonzero;
            geometry.Figures = new PathFigureCollection();
            geometry.Figures.Add(_figure = new PathFigure());
            _figure.Segments = new PathSegmentCollection();
            _figure.Segments.Add(_line = new LineSegment());

            Update();
        }

        /// <summary>
        /// Update the segement
        /// </summary>
        private void Update()
        {
            if (_figure == null || _line == null)
            {
                return;
            }

            // Set the start end points
            _figure.StartPoint = _start;
            _line.Point = _end;
        }
    }
}
