using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CanvasProjectD.CanvasPlotter
{
    /// <summary>
    /// Class for managing the curve will be drawn
    /// </summary>
    public class Polyliner
    {

        public Polyline Polyline { get; }
        /// <summary>
        /// Creates a new instance of the class
        /// </summary>
        public Polyliner()
        {
            Polyline = new Polyline
            {
                StrokeThickness = 3,
                Stroke = new SolidColorBrush(Colors.DarkMagenta)
            };
        }
        /// <summary>
        /// Stores the given real "pixelated" data point
        /// </summary>
        /// <param name="pixelatedDataPoint">The graph will pass from this exact point on canvas</param>
        internal void AddPoint(Point pixelatedDataPoint)
        {
            Polyline.Points.Add(pixelatedDataPoint);
        }

        /// <summary>
        /// Clears the data stored.
        /// </summary>
        internal void Reset()
        {
            Polyline.Points.Clear();
        }
    }
}
