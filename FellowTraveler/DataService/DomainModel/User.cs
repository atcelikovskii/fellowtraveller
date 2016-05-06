using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class User
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set;}
        public DateTime? DateOfBirthday { get; set; }
        public bool Sex { get; set; }

        public IEnumerable<Route> RouteList { get; set; }
    }
}
