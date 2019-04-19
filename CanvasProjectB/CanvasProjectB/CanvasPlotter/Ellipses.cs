using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasProjectB.CanvasPlotter
{
    public class Ellipses // "Ellipses" is the name of the class which generates "Cirle"s due to commands of the "Plotter" 
    {
        public List<Circle> Circles { get; set; }

        public Ellipses()
        {
            Circles = new List<Circle>();
        }

        internal void AddPoint(DataPoint bukalemunDataPoint, DataPoint pixelatedDataPoint)
        {
            Circles.Add(new Circle(bukalemunDataPoint, pixelatedDataPoint));
        }

        internal void Reset()
        {
            Circles.Clear();
        }
    }
}
