using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CanvasProjectC.CanvasPlotter
{
    /// <summary>
    /// Class for a single circle on canvas storing and capable of showing both pixel and bukalemun values
    /// </summary>
    public class Circle
    {
        public Ellipse Ellipse { get; }
        DataPoint bukalemunDataPoint;
        DataPoint pixelatedDataPoint;

        /// <summary>
        /// Create new instance of the class Circle
        /// </summary>
        /// <param name="bukalemunDataPoint">This is the mathematical/ideal/bukalemun location of the point</param>
        /// <param name="pixelatedDataPoint">This is the corresponding pixel location of bukalemun point on canvas as the center of the circle</param>
        public Circle(DataPoint bukalemunDataPoint, DataPoint pixelatedDataPoint)
        {
            this.bukalemunDataPoint = bukalemunDataPoint;
            this.pixelatedDataPoint = pixelatedDataPoint;

            Ellipse = new Ellipse();
            Ellipse.Height = 10;
            Ellipse.Width = 10;
            double fromLeft = pixelatedDataPoint.X - Ellipse.Width / 2;
            double fromTop = pixelatedDataPoint.Y - Ellipse.Height / 2;
            Ellipse.Margin = new Thickness(fromLeft, fromTop, 0, 0);
            Ellipse.Fill = new SolidColorBrush(Colors.BlueViolet);
        }
    }
}
