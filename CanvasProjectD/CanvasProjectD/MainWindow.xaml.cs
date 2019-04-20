using CanvasProjectD.CanvasPlotter;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace CanvasProjectD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

 
        private Plotter plotter;
        public MainWindow()
        {
            InitializeComponent();
            
            myCanvas.ClipToBounds = true;

            plotter = new Plotter(myCanvas);
            plotter.AxesWithOrigin.Origin = new Tuple<double, double>(0, myCanvas.Height / 2);
            plotter.AxesWithOrigin.XScalingFactor = 10;
            plotter.AxesWithOrigin.YScalingFactor = -100;
            plotter.PointMarksVisible = true;
            plotter.PolylineVisible = false;
            plotter.DrawAll();

            xLabel.Content = $"X range: [{plotter.AxesWithOrigin.X_min}, {plotter.AxesWithOrigin.X_max}]";
            yLabel.Content = $"Y range: [{plotter.AxesWithOrigin.Y_min}, {plotter.AxesWithOrigin.Y_max}]";



        }




    }
}
