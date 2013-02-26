using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Paint
{
    public class ShapeSelectEventArgs : EventArgs
    {
        public PaintShape Shape {get; set;}
        
        public ShapeSelectEventArgs(PaintShape shape)
        {
            this.Shape = shape;
        }
    }

    public delegate void ShapeSelectEventHandler(object sender, ShapeSelectEventArgs e);
}
