using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

/*
 *      RELEASE NOTES:          !!!CHECK THE CURRENT STATUS before starting to code!!!
 * + "Ellipse" is no more used. Check PointMarks.cs for details.        
 * + plotter.Add(yValue) functionality is added. (X axis auto-incremented plotting)
 * - [Add more if you can, or pass to CPE]
 * - CPE! now as a dll file
 * - Marks introduced also for "AxesAndOrigin.Axes"
 * - Raise events when properties change
 * 
 * 
 */
namespace CanvasProjectD.CanvasPlotter
{
    public class Plotter
    {
        // Auto implemented properties
        public Canvas CanvasToDrawOn { get; set; }
        public AxesWithOrigin AxesWithOrigin { get; set; }
        public PointMarks PointMarks { get; set; }
        public Polyliner Polyliner { get; set; }
        public bool PointMarksVisible { get; set; }
        public bool PolylineVisible { get; set; }
        public List<DataPoint> AutoIncrementedDataPoints { get; set; }


        // Constructor function
        public Plotter(Canvas c)
        {
            // set properties   
            CanvasToDrawOn = c;
            PointMarksVisible = false;
            PolylineVisible = true;

            PointMarks = new PointMarks(MarkerType.Triangle);
            Polyliner = new Polyliner();
            AutoIncrementedDataPoints = new List<DataPoint>();

            CanvasToDrawOn.Width = 650;
            CanvasToDrawOn.Height = 300;


            AxesWithOrigin = new AxesWithOrigin(CanvasToDrawOn.Width, CanvasToDrawOn.Height);
            // Instead of "AxesWithOrigin(double width, double height)" one can prefer "AxesWithOrigin(double width, double height, Tuple origin)" as default action like shown down below
            // AxesWithOrigin = new AxesWithOrigin(CanvasToDrawOn.Width, CanvasToDrawOn.Height, new System.Tuple<double, double>(CanvasToDrawOn.Width / 2, CanvasToDrawOn.Height));
            CanvasToDrawOn.Background = new SolidColorBrush(Colors.WhiteSmoke);

        }

        public void ResetAll()
        {
            AutoIncrementedDataPoints.Clear();
            PointMarks.Reset();
            Polyliner.Reset();
        }

        /// <summary>
        /// Takes "bukalemun" values, converts them to "pixelated" values and saves for next drawing.
        /// </summary>
        /// <param name="dataPoints">An IEnumerable set of bukalemun type data points</param>
        public void SetPoints(IEnumerable<DataPoint> dataPoints)
        {
            // Convert bukalemunDataPoints into pixelatedDataPoints and add them to Ellipses & Polyliner classes //hypothetical == bukalemun?
            PointMarks.Reset();
            Polyliner.Reset();
            DataPoint temp_PixelatedDataPoint;
            foreach (DataPoint bukalemunDataPoint in dataPoints)
            {
                // Linear mapping from imagined "bukalemun 2D plane" to real "pixelated 2D plane" 
                temp_PixelatedDataPoint = bukalemunDataPoint;
                temp_PixelatedDataPoint.X = AxesWithOrigin.Origin.Item1 + temp_PixelatedDataPoint.X * AxesWithOrigin.XScalingFactor;
                temp_PixelatedDataPoint.Y = AxesWithOrigin.Origin.Item2 + temp_PixelatedDataPoint.Y * AxesWithOrigin.YScalingFactor;

                // Add the result of transformation as both a circle to the Ellipses and point to the Polyliner
                PointMarks.AddPoint(bukalemunDataPoint, temp_PixelatedDataPoint);
                Polyliner.AddPoint(new System.Windows.Point(temp_PixelatedDataPoint.X, temp_PixelatedDataPoint.Y));
            }

        }


        /// <summary>
        /// Adds given y value to an internally stored generic List of DataPoint and displays it
        /// </summary>
        /// <param name="y">Value to be plotted</param>
        /// <param name="StartAt">X value of the first element</param>
        public void Add(double y, int StartAt)
        {
            AutoIncrementedDataPoints.Add(new DataPoint(AutoIncrementedDataPoints.Count + StartAt, y));
            this.SetPoints(AutoIncrementedDataPoints);
        }
        public void Add(double y) { this.Add(y, 0); }

        public void DrawAll()
        {
            CanvasToDrawOn.Children.Clear();

            if (PointMarksVisible)
            {
                // -------------------------------------------------------------Async!
                foreach (IMarkerType c in PointMarks.MarksList)              // Async!
                {                                                            // Async!
                    CanvasToDrawOn.Children.Add(c.Marker);                   // Async!
                }                                                            // Async!
                // -------------------------------------------------------------Async!
            }

            CanvasToDrawOn.Children.Add(AxesWithOrigin.XAxis);
            CanvasToDrawOn.Children.Add(AxesWithOrigin.YAxis);

            if (PolylineVisible)
            {
                CanvasToDrawOn.Children.Add(Polyliner.Polyline);
            }


            CanvasToDrawOn.UpdateLayout();
        }
    }
}