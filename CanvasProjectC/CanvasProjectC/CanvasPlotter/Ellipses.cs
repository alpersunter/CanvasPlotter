using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasProjectC.CanvasPlotter
{
    /// <summary>
    /// Class for managing points to be plotted
    /// </summary>
    public class Ellipses // "Ellipses" is the name of the class which generates "Cirle"s due to commands of the "Plotter" 
    {
        public List<Circle> CirclesList { get; set; }

        /// <summary>
        /// Creates a new instance of the Ellipses class
        /// </summary>
        public Ellipses()
        {
            CirclesList = new List<Circle>();
        }

        /// <summary>
        /// Stores both the bukalemun and pixel value of the point to be plotted
        /// </summary>
        /// <param name="bukalemunDataPoint">This is the mathematical/ideal/bukalemun location of the point</param>
        /// <param name="pixelatedDataPoint">This is the corresponding pixel location of bukalemun point on canvas</param>
        internal void AddPoint(DataPoint bukalemunDataPoint, DataPoint pixelatedDataPoint)
        {
            CirclesList.Add(new Circle(bukalemunDataPoint, pixelatedDataPoint));
        }

        /// <summary>
        /// Clears the data stored
        /// </summary>
        internal void Reset()
        {
            CirclesList.Clear();
        }
    }
}
