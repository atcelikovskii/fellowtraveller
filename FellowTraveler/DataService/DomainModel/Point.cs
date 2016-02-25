using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get; set; }

        public override bool Equals(Object pp)
        {
            var p = (Point)pp;
            return (p.X == X) && (p.Y == Y);
        }
    }
}
