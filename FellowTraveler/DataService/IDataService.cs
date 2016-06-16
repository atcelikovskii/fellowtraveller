using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DataService
{
    public struct FoundRoute
    {
        //[ScriptIgnore]
        public Route Route;
        public string Name{
            get { return Route.Name; }
        }
        
        public double S;
    }

    public interface IDataService
    {

        IEnumerable<User> GetUsers();

        User GetUser(int id);
        Route GetRoute(int userId, int routeId);
        //Получить список маршрутов для пользователя
        IEnumerable<Route> GetRouteListForUser(int id);


        void AddUser(User user);
        void UpdateUser(User user);
        int AddRoute(Route route, User user);
        void RemoveRoute(int id);

        //Получить ближайший маршрут
        IEnumerable<FoundRoute> SearchClosedRoutes(Point point1, Point point2, int sMax);



    }
}
