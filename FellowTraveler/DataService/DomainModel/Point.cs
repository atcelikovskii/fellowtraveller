using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }

        public Point() { }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(Object pp)
        {
            var p = (Point)pp;
            return (p.X == X) && (p.Y == Y);
        }
    }
}
