using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasProjectB.CanvasPlotter
{
    public class Polyliner
    {
        List<DataPoint> pixelatedLinePoints;

        public Polyliner()
        {
            pixelatedLinePoints = new List<DataPoint>();
        }

        internal void AddPoint(DataPoint temporaryDataPoint)
        {
            // Do nothing
        }

        internal void Reset()
        {
            pixelatedLinePoints.Clear();
        }
    }
}
