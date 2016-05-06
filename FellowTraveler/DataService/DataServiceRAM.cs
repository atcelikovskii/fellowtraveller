using DataService.DomainModel;
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
        private int _routeLastId = 1;
        

        public List<PointSearch> PointList { get; set; }
        public List<Route> RouteList { get; set; }


        public List<User> UserList = new List<User>();

        public DataServiceRAM()
        {
            AddUser(new User() {Surname = "Иванов", Name="Иван", Sex=true, Email="ivan@mail.ru" });
            UserList[0].RouteList = new List<Route>(){new Route(){
                Owner = UserList[0],
                Id = 1,
                Name = "Первый маршрут",
                To = "г.Ставрополь, Доваторцев 4",
                From = "г.Ставрополь, Кулакова 2/2",
                //Не хорошие точки для отображения - корректно их использовать только при тестировании
                //Points = new List<Point>()
                //{
                //    new Point(){X = 0, Y = 0, Name = "1"},
                //    new Point(){X = 5, Y = 10, Name = "2"},
                //    new Point(){X = 15, Y = 30, Name = "3"},
                //    new Point(){X = 5, Y = 10, Name = "4"}
                //}
            }
            };
            AddUser(new User() { Surname = "Петров", Name = "Петр", Sex = true, Email = "petr@mail.ru" });
            AddUser(new User() {
                Surname = "Сидорова",
                Name = "Елена",
                Sex = false,
                Email = "Elen@mail.ru" });
        }

        public IEnumerable<User> GetUsers()
        {
            return UserList;
        }

        public void UpdateUser(User user)
        {
           UserList.First(u => u.Id == user.Id).UpdateAll(user);
            // userRep
            //userRep.Update(user.Name, user.Sex, user.Surname);
            //UserList.First(u => u.Id == user.Id).Name = user.Name;
            //UserList.First(u => u.Id == user.Id).Surname = user.Surname;
        }

        public User GetUser(int id)
        {
            return UserList.First(u => u.Id == id);
        }

        public Route GetRoute(int userId, int routeId)
        {
            
            User userIn = GetUser(userId);
            return userIn.RouteList.First(r => r.Id == routeId); // при idМаршрута = 3, берет данные 3 пользователя
            //return userIn.RouteList.Select();
        }

        public IEnumerable<Route> GetRouteListForUser(int id)
        {
            return UserList.First(u => u.Id == id).RouteList;
        }

        public void AddUser(User user)
        {
            if (user.Id == null) user.Id = ++_userLastId;
            UserList.Add(user);
        }
        public void AddRoute(Route route, User user)
        {

            int IdUser = (int)user.Id;
            User userIn = GetUser(IdUser);

            if (userIn.RouteList == null)
            {
                userIn.RouteList = new Route[] { route };
            }
            else
            {
                List<Route> routes = new List<Route>(userIn.RouteList);
                routes.Add(route);
                userIn.RouteList = routes;
            }
            route.Owner = userIn;
            if (route.Id == null) route.Id = ++_routeLastId;
            
            //PointList.AddRange(route.Points.Select(p => new PointSearch() { Point = p, Route = route }));

        }


       
        Point IDataService.SearchClosedPoint(Point point)
        {
            //throw new NotImplementedException();
            return RouteUtils.SearchClosedPoint(point, PointList);
        }

       
        Route IDataService.SearchClosedRoute(Point point)
        {
            throw new NotImplementedException();
        }

     
    }
}
