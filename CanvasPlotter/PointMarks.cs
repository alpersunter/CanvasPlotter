using CanvasPlotter.Markers;
using System;
using System.Collections.Generic;
using System.Threading;

/* 
 * 
 *  IMPORTANT UPDATE! 
 *  With the "CanvasProjectD", the class referred as "Ellipses" in "CanvasProjectA", "CanvasProjectB" and "CanvasProjectC"  are now RENAMED as and EVOLVED to "PointMarks"
 *  
 *  This is due to a naming convention of Python matplotlib library
 *  Check that link: https://matplotlib.org/api/markers_api.html
 *  
 *  Since they call any shape representing any plotted point as a "Marker", this is a better practice to rename them.
 *  
 *  There will be an "IMarkerType" interface, which will supply enough flexibility and practicality for further marker types
 *  At this version, the only types implementing it are "Circle" and "Triangle". (i.e. Currently, the only marker options are "Circle" and "Triangle".)
 *  
 *  With the further versions, I can add more "marker types" to plotter code.
 *  
 */
namespace CanvasPlotter
{

    /// <summary>
    /// Class for managing points to be plotted
    /// </summary>
    public class PointMarks // "PointMarks" is the name of the class which generates "Mark"s due to commands of the "Plotter" 
    {
        public List<IMarkerType> MarksList { get; set; }
        public MarkerType MarkType { get; set; }

        /// <summary>
        /// Creates a new instance of the PointMarks class
        /// </summary>
        public PointMarks(MarkerType mt)
        {
            MarkType = mt;
            MarksList = new List<IMarkerType>();
        }

        /// <summary>
        /// Stores both the bukalemun and pixel value of the point to be plotted
        /// </summary>
        /// <param name="bukalemunDataPoint">This is the mathematical/ideal/bukalemun location of the point</param>
        /// <param name="pixelatedDataPoint">This is the corresponding pixel location of bukalemun point on canvas</param>
       
        internal void AddPoint(DataPoint bukalemunDataPoint, DataPoint pixelatedDataPoint)
        {
            switch (MarkType)
            {
                case MarkerType.Circle:
                    MarksList.Add(new Circle(bukalemunDataPoint, pixelatedDataPoint));
                    break;
                case MarkerType.Triangle:
                    MarksList.Add(new Triangle(bukalemunDataPoint, pixelatedDataPoint)); 
                    break;
            }
        }

        /// <summary>
        /// Clears the data stored
        /// </summary>
        internal void Reset()
        {
            MarksList.Clear();
        }
    }
}
