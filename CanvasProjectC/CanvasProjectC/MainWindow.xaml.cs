using CanvasProjectC.CanvasPlotter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace CanvasProjectC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        Plotter plotter;
        public MainWindow()
        {
            InitializeComponent();
            myCanvas.ClipToBounds = true;

            plotter = new Plotter(myCanvas);
            //plotter.AxesWithOrigin.XScalingFactor = 10;
            //plotter.AxesWithOrigin.YScalingFactor = -20;
            plotter.Polyliner.Polyline.StrokeThickness = 3;
            plotter.Polyliner.Polyline.Stroke = new SolidColorBrush(Colors.DarkMagenta);



        }


    }
}
