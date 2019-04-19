using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CanvasProjectB.CanvasPlotter
{

    /*
     
         AxesWithOrigin classında canvasın width ve height'ları piksel sayısı olarak düşünüldüğünden tamsayı (integer) alındı.

        Alternatif bir "double" classı kurmayı dene!

        ! Aynı projeyi kopyalayıp CanvasProjectC yapacağım bu defa double'lar ile ! 7 Ekim 2018 Pazar 17:01
         
         */
    public class AxesWithOrigin
    {
        public Tuple<int, int> Origin { get; set; }

        private readonly int canvasWidth;
        private readonly int canvasHeight;


        /*
         Line line = new Line();
         line.X1 = 0;
         line.Y1 = 0;
         line.X2 = 100;
         line.Y2 = 100;
         line.StrokeThickness = 4;
         line.Stroke = new SolidColorBrush(Colors.Blue);
         myyC.Children.Add(line);
         line.Y2 = 300;
         */

        public Line XAxis { get; set; }
        // public List<string> XLabels { get; set; }
        private int _XScalingFactor; // backing field
        public int XScalingFactor
        {
            get { return _XScalingFactor; }
            set { if (value > 0) _XScalingFactor = value; }
        }


        public Line YAxis { get; set; }
        // public List<string> YLabels { get; set; }
        private int _YScalingFactor; // backing field
        public int YScalingFactor
        {
            get { return _YScalingFactor; }
            set { if (value < 0) _YScalingFactor = value; }
        }

        public int X_max
        {
            get
            {
                // The greatest X value that can be fitted to the canvas

                int rightSpace = canvasWidth - Origin.Item1;
                int x_max = rightSpace / _XScalingFactor;

                return x_max;
            }
        }

        public int X_min
        {
            get
            {
                // The lowest X value that can be fitted to the canvas

                int leftSpace = Origin.Item1;
                int x_min = leftSpace / XScalingFactor;

                return x_min;
            }
        }

        public int Y_max
        {
            get
            {
                // The greatest Y value that can be fitted to the canvas

                int topSpace = Origin.Item2;
                int y_max =  - topSpace / YScalingFactor;

                return y_max;
            }
        }

        public int Y_min
        {
            get
            {
                // The lowest Y value that can be fitted to the canvas

                int bottomSpace = canvasHeight - Origin.Item2;
                int y_min = - bottomSpace / YScalingFactor;

                return 0;
            }
        }

        public AxesWithOrigin(int CanvasWidth, int CanvasHeight, Tuple<int, int> origin)
        {

            canvasWidth = CanvasWidth;
            canvasHeight = CanvasHeight;
            Origin = origin;

            // XAxis
            XAxis = new Line();
            XAxis.X1 = 0;
            XAxis.Y1 = origin.Item2;
            XAxis.X2 = CanvasWidth;
            XAxis.Y2 = origin.Item2;
            XScalingFactor = 50;
            XAxis.Stroke = new SolidColorBrush(Colors.Green);

            // YAxis
            YAxis = new Line();
            YAxis.X1 = origin.Item1;
            YAxis.Y1 = 0;
            YAxis.X2 = origin.Item1;
            YAxis.Y2 = CanvasHeight;
            YScalingFactor = -50;
            
            YAxis.Stroke = new SolidColorBrush(Colors.MediumVioletRed);
        }

        public AxesWithOrigin(int CanvasWidth, int CanvasHeight) : this(CanvasWidth, CanvasHeight, new Tuple<int, int>(CanvasWidth / 2, CanvasHeight / 2))
        {

        }
    }
}
