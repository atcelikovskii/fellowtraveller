using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class DataServiceRAM:IDataService
    {
        public List<User> UserList = new List<User>();

        public DataServiceRAM()
        {
            this.UserList.Add(new User() { Name = "Иванов" });
            this.UserList.Add(new User() { Name = "Петров" });
            this.UserList.Add(new User() { Name = "Сидоров" });
        }

        public IEnumerable<User> GetUsers()
        {
            return UserList;
        }
    }
}
