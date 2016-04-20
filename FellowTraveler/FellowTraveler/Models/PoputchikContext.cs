using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FellowTraveler.Models
{
    public class PoputchikContext:DbContext
    {
        public DbSet<Point> Points { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
