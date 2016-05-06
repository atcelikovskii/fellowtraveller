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
        public DateTime DateOfBirthday { get; set; }
        public bool Sex { get; set; }

        public IEnumerable<Route> RouteList { get; set; }

        internal void Update(string name, bool sex, string surname, string password, string email, DateTime dateOfBirthday)
        {
          
            this.Name = name;
            this.Surname = surname;
            this.Sex = sex;
            this.Email = email;
            this.Password = password;
            this.DateOfBirthday = dateOfBirthday;
        }

        internal void UpdateAll(User user)
        {
            this.Update(user.Name, user.Sex, user.Surname, user.Password, user.Email, user.DateOfBirthday);
        }
    }
}
