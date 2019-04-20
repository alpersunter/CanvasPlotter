using System.Windows;
using CanvasPlotter;

namespace CanvasProjectE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Plotter plotter = new Plotter(myCanvas)
            {
                PointMarksVisible = true,
                PolylineVisible = true
            };
            myCanvas.ClipToBounds=true;
            myCanvas.MouseLeave += MyCanvas_MouseLeave;
            myCanvas.MouseEnter += MyCanvas_MouseEnter;
            myCanvas.MouseWheel += MyCanvas_MouseWheel;
            plotter.PointMarks.MarkType = MarkerType.Circle;
            plotter.AxesWithOrigin.YScalingFactor /= 20;
            plotter.AxesWithOrigin.XScalingFactor /= 3;

            for(int i = -10; i < 11; i++)
            {
                plotter.Add(i*i, -10);
            }

            plotter.DrawAll();
        }

        private void MyCanvas_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            lbl.Content = "OK!";
        }

        private void MyCanvas_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            lbl.Content = $"Zumlayalım: {e.Delta}";
            
        }

        private void MyCanvas_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            lbl.Content = "Şimdi çizemem :/";
        }


    }
}
