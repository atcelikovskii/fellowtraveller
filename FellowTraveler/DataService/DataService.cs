using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    //Конкретное хранилище, работающее по протоколу (интерфейсу) IDataService
    public class DataServiceRAM : IDataService
    {
        public List<User> UserList = new List<User>();

        public DataServiceRAM()
        {
            this.UserList.Add(new User() { Name = "Иванов", Id = 1 });
            this.UserList[0].RouteList = new List<Route>(){new Route(){
                Owner=this.UserList[0],
                Id = 1,
                Name = "Первый маршрут",
                //Не хорошие точки для отображения - корректно их использовать только при тестировании
                Points = new List<Point>()
                {
                    new Point(){X = 0, Y = 0},
                    new Point(){X = 5, Y = 10},
                    new Point(){X = 15, Y = 30},
                    new Point(){X = 5, Y = 10}
                }
            }
            };
            this.UserList.Add(new User() { Name = "Петров", Id = 2 });
            this.UserList.Add(new User() { Name = "Сидоров", Id = 3 });
        }

        public IEnumerable<User> GetUsers()
        {
            return UserList;
        }


        public User GetUser(int id)
        {
            return this.UserList.First(u => u.Id == id);
        }


        public IEnumerable<Route> GetRouteListForUser(int Id)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            this.UserList.First(u => u.Id == user.Id).Name = user.Name;
        }

        public void AddRoute(int userId, Route route)
        {
            throw new NotImplementedException();
        }




      

        Point IDataService.GetClosedPoint(Point point)
        {
            throw new NotImplementedException();
        }

        Route IDataService.GetClosedRoute(Point point)
        {
            throw new NotImplementedException();
        }
    }
}
