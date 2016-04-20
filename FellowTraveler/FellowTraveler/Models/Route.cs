using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FellowTraveler.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }


        public int? UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<Point> Points { get; set; }

    }
}
