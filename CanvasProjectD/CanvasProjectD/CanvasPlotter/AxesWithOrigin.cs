using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CanvasProjectD.CanvasPlotter
{
    /// <summary>
    /// Class for managing X and Y axes
    /// </summary>
    public class AxesWithOrigin
    {
        /// <summary>
        /// The backing field for the public property "Origin"
        /// </summary>
        private Tuple<double, double> _origin;
        /// <summary>
        /// Position of the mathematical/bukalemun origin (0, 0) of the graph in terms of pixel values on a canvas. Also relocates the X and Y axes when its value updated.
        /// </summary>
        public Tuple<double, double> Origin
        {
            get { return _origin; }
            set
            {
                _origin = value;
                
                // Relocate the axes
                XAxis.X1 = 0;
                XAxis.Y1 = _origin.Item2;
                XAxis.X2 = canvasWidth;
                XAxis.Y2 = _origin.Item2;

                YAxis.X1 = _origin.Item1;
                YAxis.Y1 = 0;
                YAxis.X2 = _origin.Item1;
                YAxis.Y2 = canvasHeight;
            }
        }

        private readonly double canvasWidth;
        private readonly double canvasHeight;


        public Line XAxis { get; set; }
        // public List<string> XLabels { get; set; }
        private double _XScalingFactor; // backing field
        /// <summary>
        /// This many pixels represent the mathematical/bukalemun 1 unit on X axis. It must be positive for a right handed plane.
        /// </summary>
        public double XScalingFactor
        {
            get { return _XScalingFactor; }
            set { if (value > 0) _XScalingFactor = value; }
        }


        public Line YAxis { get; set; }
        // public List<string> YLabels { get; set; }
        private double _YScalingFactor; // backing field
        /// <summary>
        /// This many pixels represent the mathematical/bukalemun 1 unit on Y axis. It must be negative for a right handed plane.
        /// </summary>
        public double YScalingFactor
        {
            get { return _YScalingFactor; }
            set { if (value < 0) _YScalingFactor = value; }
        }

        public double X_max
        {
            get
            {
                // The greatest X value that can be fitted to the canvas

                double rightSpace = canvasWidth - Origin.Item1;
                double x_max = rightSpace / _XScalingFactor;

                return x_max;
            }
        }

        public double X_min
        {
            get
            {
                // The lowest X value that can be fitted to the canvas

                double leftSpace = Origin.Item1;
                double x_min = leftSpace / XScalingFactor;

                return x_min;
            }
        }

        public double Y_max
        {
            get
            {
                // The greatest Y value that can be fitted to the canvas

                double topSpace = Origin.Item2;
                double y_max = -topSpace / YScalingFactor;

                return y_max;
            }
        }

        public double Y_min
        {
            get
            {
                // The lowest Y value that can be fitted to the canvas

                double bottomSpace = canvasHeight - Origin.Item2;
                double y_min = bottomSpace / YScalingFactor;

                return y_min;
            }
        }

        /// <summary>
        /// Creates a new set of axes with given point as mathematical origin
        /// </summary>
        /// <param name="CanvasWidth">Width of the parent canvas (CanvasToDrawOn)</param>
        /// <param name="CanvasHeight">Height of the parent canvas (CanvasToDrawOn)</param>
        /// <param name="origin">Position of the mathematical/bukalemun origin (0, 0) of the graph in terms of pixel values on a canvas.</param>
        public AxesWithOrigin(double CanvasWidth, double CanvasHeight, Tuple<double, double> origin)
        {

            canvasWidth = CanvasWidth;
            canvasHeight = CanvasHeight;
            

            // XAxis
            XAxis = new Line();
            XScalingFactor = 50;
            XAxis.Stroke = new SolidColorBrush(Colors.Green);

            // YAxis
            YAxis = new Line();
            YScalingFactor = -50;
            YAxis.Stroke = new SolidColorBrush(Colors.MediumVioletRed);

            Origin = origin;
        }

        /// <summary>
        /// Creates a new set of axes with a centered origin
        /// </summary>
        /// <param name="CanvasWidth">Width of the parent canvas (CanvasToDrawOn)</param>
        /// <param name="CanvasHeight">Height of the parent canvas (CanvasToDrawOn)</param>
        public AxesWithOrigin(double CanvasWidth, double CanvasHeight) : this(CanvasWidth, CanvasHeight, new Tuple<double, double>(CanvasWidth / 2, CanvasHeight / 2))
        {

        }
    }
}
