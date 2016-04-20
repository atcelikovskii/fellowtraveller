using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowTraveler.Models
{
    public class Point
    {
        public int PointId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int LastPoint { get; set; }

        public int? RouteId { get; set; }
        public Route Route { get; set; }



    }
}
