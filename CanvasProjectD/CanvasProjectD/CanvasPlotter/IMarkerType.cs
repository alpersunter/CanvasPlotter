﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace CanvasProjectD.CanvasPlotter
{
    public interface IMarkerType
    {
        UIElement Marker { get; }
        DataPoint BukalemunDataPoint { get; set; }
        DataPoint PixelatedDataPoint { get; set; }
        

    }
}
