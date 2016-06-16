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
                From = "г.Ставрополь, Кулакова 2/2"
            }
            };
            AddUser(new User() { Surname = "Петров", Name = "Петр", Sex = true, Email = "petr@mail.ru" });
            AddUser(new User() {
                Surname = "Сидорова",
                Name = "Елена",
                Sex = false,
                Email = "Elen@mail.ru" });
            this.RouteList = new List<Route>();
        }

        public IEnumerable<User> GetUsers()
        {
            return UserList;
        }

        public void UpdateUser(User user)
        {
           UserList.First(u => u.Id == user.Id).UpdateAll(user);
        }

        public User GetUser(int id)
        {
            return UserList.First(u => u.Id == id);
        }

        public Route GetRoute(int userId, int routeId)
        {
            User userIn = GetUser(userId);
            return userIn.RouteList.First(r => r.Id == routeId); // при idМаршрута = 3, берет данные 3 пользователя
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
        public int AddRoute(Route route, User user)
        {

            int IdUser = (int)user.Id;
            User userIn = GetUser(IdUser);
            route.Owner = userIn;
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

            this.RouteList.Add(route);
            //PointList.AddRange(route.Points.Select(p => new PointSearch() { Point = p, Route = route }));
            return (int)route.Id;

        }



        IEnumerable<FoundRoute> IDataService.SearchClosedRoutes(Point point1, Point point2, int sMax)
        {
            return RouteUtils.SearchClosedRoute(point1, point2, this.RouteList, sMax);
        }




      
        public void RemoveRoute(int id)
        {
            throw new NotImplementedException();
        }
    }
}
