using CanvasProjectB.CanvasPlotter;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CanvasProjectB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myyC.ClipToBounds = true;
            Plotter p = new Plotter(myyC);

            List<DataPoint> testData = new List<DataPoint>();
            
            for(int i = -20; i < 20; i++)
            {
                testData.Add(new DataPoint(i, i+1));
            }

            p.SetPoints(testData);

            p.DrawAll();

            
        }
    }
}
