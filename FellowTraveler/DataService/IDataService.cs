﻿using System;
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
        Route GetRoute(int userId, int routeId);
        //Получить список маршрутов для пользователя
        IEnumerable<Route> GetRouteListForUser(int id);


        void AddUser(User user);
        void UpdateUser(User user);
        void AddRoute(Route route, User user);

        //Получить ближайшую точку
        Point SearchClosedPoint(Point point);

        //Получить ближайший маршрут
        Route SearchClosedRoute(Point point);



    }
}
