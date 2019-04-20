using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

/*
 * IMPLEMENT IDisposable interface
 * */


namespace CanvasPlotter.Markers
{
    /// <summary>
    /// Class for a single circle on canvas storing and capable of showing both pixel and bukalemun values
    /// </summary>
    public class Circle : IMarkerType
    {
        // Implementation of the IMarkerType interface
        public UIElement Marker { get; }
        public DataPoint BukalemunDataPoint { get; set; }
        public DataPoint PixelatedDataPoint { get; set; }

        
        /// <summary>
        /// Ellipse object to be transformed to circle
        /// </summary>
        Ellipse Ellipse;
        

        /// <summary>
        /// Create new instance of the class Circle
        /// </summary>
        /// <param name="bukalemunDataPoint">This is the mathematical/ideal/bukalemun location of the point</param>
        /// <param name="pixelatedDataPoint">This is the corresponding pixel location of bukalemun point on canvas as the center of the circle</param>
        public Circle(DataPoint bukalemunDataPoint, DataPoint pixelatedDataPoint)
        {
            BukalemunDataPoint = bukalemunDataPoint;
            PixelatedDataPoint = pixelatedDataPoint;

            Ellipse = new Ellipse
            {
                Height = 10,
                Width = 10
            };
            double fromLeft = pixelatedDataPoint.X - Ellipse.Width / 2;
            double fromTop = pixelatedDataPoint.Y - Ellipse.Height / 2;
            Ellipse.Margin = new Thickness(fromLeft, fromTop, 0, 0);
            Ellipse.Fill = new SolidColorBrush(Colors.BlueViolet);
            Marker = Ellipse;
        }
    }
}
