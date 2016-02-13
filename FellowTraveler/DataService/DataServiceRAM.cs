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
        private int _userLastId = 0;
        private int _routeLastId = 0;
        

        public List<User> UserList = new List<User>();

        public DataServiceRAM()
        {
            AddUser(new User() { Name = "Иванов" });
            UserList[0].RouteList = new List<Route>(){new Route(){
                Owner = UserList[0],
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
            AddUser(new User() { Name = "Петров"});
            AddUser(new User() { Name = "Сидоров"});
        }

        public IEnumerable<User> GetUsers()
        {
            return UserList;
        }

        public void UpdateUser(User user)
        {
            this.UserList.First(u => u.Id == user.Id).Name = user.Name;
        }

        
        public User GetUser(int id)
        {
            return this.UserList.First(u => u.Id == id);
        }


        public IEnumerable<Route> GetRouteListForUser(int id)
        {
            return this.UserList.First(u => u.Id == id).RouteList;
        }

        public void AddUser(User user)
        {
            if (user.Id == null) user.Id = ++_userLastId;
            UserList.Add(user);
        }

        public void AddRoute(Route route, User user)
        {
            //int idUser = user.Id;
            //UserList[idUser].RouteList = new Route() { }


            if (route.Id == null) route.Id = ++_routeLastId;
            
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
