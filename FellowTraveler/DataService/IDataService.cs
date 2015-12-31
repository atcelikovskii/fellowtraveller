using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public interface IDataService
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
        IEnumerable<Route> GetRouteListForUser(int id);

        void AddUser(User user);
        void UpdateUser(User user);
        void AddRoute(int userId, Route route);

        Point GetClosedPoint(Point point);
        Route GetClosedRoute(Point point);

    }
}
