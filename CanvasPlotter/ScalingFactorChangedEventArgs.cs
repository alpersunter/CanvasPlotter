using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasPlotter
{
    public class ScalingFactorChangedEventArgs : EventArgs
    {
        public double X_Old;
        public double Y_Old;
        public double X_New;
        public double Y_New;
    }

}
