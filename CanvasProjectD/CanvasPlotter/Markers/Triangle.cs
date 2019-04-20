using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CanvasPlotter.Markers
{
    /// <summary>
    /// Class for an equilateral triangle on canvas storing and capable of showing both pixel and bukalemun values
    /// </summary>
    public class Triangle : IMarkerType
    {
        // Implementation of the IMarkerType interface
        public UIElement Marker { get; }
        public DataPoint BukalemunDataPoint { get; set; }
        public DataPoint PixelatedDataPoint { get; set; }
        
        /// <summary>
        /// Polygon object to create a triangle
        /// </summary>
        Polygon triangle;

        /// <summary>
        /// How far apart are corners from the center of mass of the triangle
        /// </summary>
        readonly int radius = 10;
        readonly PointCollection cornerPoints;
        public Triangle(DataPoint bukalemunDataPoint, DataPoint pixelatedDataPoint)
        {
            BukalemunDataPoint = bukalemunDataPoint;
            PixelatedDataPoint = pixelatedDataPoint;

            triangle = new Polygon
            {
                Stroke = new SolidColorBrush(Colors.Green),
                Fill = new SolidColorBrush(Colors.Green),
                StrokeThickness = 0.01
            };
            cornerPoints = new PointCollection
            {

                // Add the corner pointing upwards
                new Point(PixelatedDataPoint.X, PixelatedDataPoint.Y - radius),

                // Add the corner pointing bottom right
                new Point(PixelatedDataPoint.X + radius * .87, PixelatedDataPoint.Y + radius / 2),

                // Add the corner pointing bottom left
                new Point(PixelatedDataPoint.X - radius * .87, PixelatedDataPoint.Y + radius / 2)
            };

            triangle.Points = cornerPoints;

            Marker = triangle;
        }

    }
}
