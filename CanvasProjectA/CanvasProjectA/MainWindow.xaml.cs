using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CanvasProjectA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Queue<Point> valueList = new Queue<Point>(10);
        int gecenSure = 0;
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(30);
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            myPolyline.Stroke = System.Windows.Media.Brushes.SlateGray;
            myPolyline.StrokeThickness = 2;
            myPolyline.FillRule = FillRule.EvenOdd;
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            gecenSure++;
            if (valueList.Count > 100) valueList.Dequeue();
            valueList.Enqueue(new Point(gecenSure*2%400,sinOmegaTe(gecenSure)*100+115));
            myPolyline.Points = new PointCollection(valueList);
        }

      

        double sinOmegaTe(double time)
        {
            double result = 0;

            double ohm = Math.PI/80;
            result = Math.Sin(ohm * time);


            return result;
        }
    }
}
