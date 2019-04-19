namespace CanvasProjectB.CanvasPlotter
{
    public class Circle
    {
        public System.Windows.Shapes.Ellipse Ellipse { get; }
        DataPoint bukalemunDataPoint;
        DataPoint pixelatedDataPoint;

        public Circle(DataPoint bukalemunDataPoint, DataPoint pixelatedDataPoint)
        {
            this.bukalemunDataPoint = bukalemunDataPoint;
            this.pixelatedDataPoint = pixelatedDataPoint;

            Ellipse = new System.Windows.Shapes.Ellipse();
            Ellipse.Height = 10;
            Ellipse.Width = 10;
            double fromLeft = pixelatedDataPoint.X - Ellipse.Width / 2;
            double fromTop = pixelatedDataPoint.Y - Ellipse.Height / 2;
            Ellipse.Margin = new System.Windows.Thickness(fromLeft, fromTop, 0, 0);
            Ellipse.Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.BlueViolet);
        }
    }
}
