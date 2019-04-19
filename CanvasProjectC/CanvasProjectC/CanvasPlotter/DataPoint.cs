using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasProjectC.CanvasPlotter
{
    /// <summary>
    /// Struct for storing corresponding X and Y values together
    /// </summary>
    public struct DataPoint
    {
        public double X, Y;

        public DataPoint(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

    }
}
