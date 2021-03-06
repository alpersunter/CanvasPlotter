﻿using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace CanvasProjectB.CanvasPlotter
{
    public class Plotter
    {
        // Auto implemented properties
        public Canvas CanvasToDrawOn { get; set; }
        public AxesWithOrigin AxesWithOrigin { get; set; }
        public Ellipses Ellipses { get; set; }
        public Polyliner Polyliner { get; set; }


        // Constructor function
        public Plotter(Canvas c)
        {
            // set properties   
            CanvasToDrawOn = c;

            Ellipses = new Ellipses();
            Polyliner = new Polyliner();

            CanvasToDrawOn.Width = 400;
            CanvasToDrawOn.Height = 300;
            //AxesWithOrigin = new AxesWithOrigin((int)CanvasToDrawOn.Width, (int)CanvasToDrawOn.Height);
            //AxesWithOrigin = new AxesWithOrigin((int)CanvasToDrawOn.Width, (int)CanvasToDrawOn.Height, new System.Tuple<int, int>(80, 200));
            AxesWithOrigin = new AxesWithOrigin((int)CanvasToDrawOn.Width, (int)CanvasToDrawOn.Height, new System.Tuple<int, int>((int)CanvasToDrawOn.Width/2, (int)CanvasToDrawOn.Height));
            CanvasToDrawOn.Background = new SolidColorBrush(Colors.WhiteSmoke);

            //CanvasToDrawOn.Children.Add(AxesWithOrigin.XAxis);
            //CanvasToDrawOn.Children.Add(AxesWithOrigin.YAxis);
            
        }

        /// <summary>
        /// Takes "bukalemun" values, converts them to "pixelated" values and saves for next drawing.
        /// </summary>
        /// <param name="dataPoints">An IEnumerable set of bukalemun type data points</param>
        public void SetPoints(IEnumerable<DataPoint> dataPoints)
        {
            // Convert bukalemunDataPoints into pixelatedDataPoints and add them to Ellipses & Polyliner classes //hypothetical == bukalemun?
            Ellipses.Reset();
            Polyliner.Reset();
            DataPoint temp_PixelatedDataPoint;
            foreach (DataPoint bukalemunDataPoint in dataPoints)
            {
                // Linear mapping from imagined "bukalemun 2D plane" to real "pixelated 2D plane" 
                temp_PixelatedDataPoint = bukalemunDataPoint;
                temp_PixelatedDataPoint.X = AxesWithOrigin.Origin.Item1 + temp_PixelatedDataPoint.X * AxesWithOrigin.XScalingFactor;
                temp_PixelatedDataPoint.Y = AxesWithOrigin.Origin.Item2 + temp_PixelatedDataPoint.Y * AxesWithOrigin.YScalingFactor;

                // Add the result of transformation as both a circle to the Ellipses and point to the Polyliner
                Ellipses.AddPoint(bukalemunDataPoint, temp_PixelatedDataPoint);
                Polyliner.AddPoint(temp_PixelatedDataPoint);
            }
        }

        public void DrawAll()
        {
            CanvasToDrawOn.Children.Clear();

            CanvasToDrawOn.Children.Add(AxesWithOrigin.XAxis);
            CanvasToDrawOn.Children.Add(AxesWithOrigin.YAxis);

            // CanvasToDrawOn.Children.Add(Polyliner.Polyline); async!
            // CanvasToDrawOn.Children.Add(Ellipses.Circles[i].Ellipse); async!
            // CanvasToDrawOn.Children.Add(Ellipses.Elipsler); async!

            foreach(Circle c in Ellipses.Circles)
            {
                CanvasToDrawOn.Children.Add(c.Ellipse);
            }


            CanvasToDrawOn.UpdateLayout();
        }
    }
}