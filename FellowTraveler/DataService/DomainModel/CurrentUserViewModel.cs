using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.DomainModel
{
    public class CurrentUserViewModel
    {
        public string CurrentUser { get; set; }
        public IEnumerable<User> Users { get; set; }
        //public string Usering { get; set; }
    }
}
