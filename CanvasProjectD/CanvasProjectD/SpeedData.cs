using CanvasProjectD.CanvasPlotter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasProjectD
{
    /// <summary>
    /// This is a test class for CanvasPlotter driven by an imaginary car
    /// </summary>
    public class SpeedData
    {
        readonly Queue<double> Velocities;
        readonly int totalNumberofEntries = 0;

        public void AddPoint(double velocity)
        {
            Velocities.Dequeue();
            Velocities.Enqueue(velocity);
            
        }

        public SpeedData(int totalCapacity)
        {
            VelocityDataList = new List<DataPoint>();
            Velocities = new Queue<double>();
            totalNumberofEntries = totalCapacity;
            for(int i = 0; i < totalNumberofEntries; i++)
            {
                Velocities.Enqueue(0);
            }
        }

        List<DataPoint> VelocityDataList { get; set; }

        public IEnumerable<DataPoint> VelocityData()
        {
            VelocityDataList.Clear();
            for (int i = 0; i < totalNumberofEntries; i++)
            {
                VelocityDataList.Add(new DataPoint(i, Velocities.ElementAt(i)));
            }

            //Parallel.For(0, totalNumberofEntries, (i) =>
            //{
            //    VelocityDataList.Add(new DataPoint(i, Velocities.ElementAt(i)));
            //});


            //List<DataPoint> xkare = new List<DataPoint>();
            //for (int i = -5; i < 6; i++)
            //{
            //    xkare.Add(new DataPoint(i, i * i));
            //}
            //IEnumerable<DataPoint> dt = xkare;
            return VelocityDataList;
        }
    }
}
