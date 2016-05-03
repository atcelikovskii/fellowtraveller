using DataService.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
   public static class RouteUtils
    {
       // static Func<Point, Point, double> sFunc = new Func<Point, Point, double>((p1, p2) => Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)));

        public static double GetDistance(this Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }

        public static Point SearchClosedPoint(Point point, IEnumerable<PointSearch> collection)
        {
            // поиск ближайщей точки

            Point closedPoint = null;// PointList[0].Point;
          
            double sMin = double.MaxValue;// sFunc(closedPoint, point);
            foreach (var pointSearch in collection)
            {
                var s = GetDistance(pointSearch.Point, point);
                if (sMin > s)
                {
                    sMin = s;
                    closedPoint = pointSearch.Point;
                }
            }
            //PointList.ForEach(p =>  Math.Sqrt(Math.Pow(p.Point.X - point.X, 2) + Math.Pow(p.Point.Y - point.Y, 2)));
            return closedPoint;
        }

        public static LineBreak SearchClosedLineBreak(IEnumerable<LineBreak> lineBreakCollection, Point point)
        {
            // поиск ближайщего отрезка
            double minDistance = double.MaxValue;
            LineBreak closedLineBreak = null;
            foreach(var lineBreak in lineBreakCollection)
            {
                var distance = lineBreak.GetDistanceToPoint(point);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closedLineBreak = lineBreak;
                }
            }
            return closedLineBreak;
        }


        /// <summary>
        /// Возвращает отрезки, расстояние от которых до точки point не более sMax
        /// </summary>
        
        public static List<LineBreak> SearchLineBreakCollection(IEnumerable<LineBreak> lineBreakCollection, Point point, int S)
        {
            List<LineBreak> nearsLineBreak = new List<LineBreak>();
            foreach (var lineBreak in lineBreakCollection)
            {
                var distance = lineBreak.GetDistanceToPoint(point);
                if (distance <= S)
                {
                   nearsLineBreak.Add(lineBreak);
                }
            }
            return nearsLineBreak;
        }

       public struct r
        {
            public Route Route;
            public double S;
        }
        public static List<r> SearchClosedRoute(Point point1, Point point2, IEnumerable<RoutedLineBreak> lineBreakCollection, int sMax)
        {
            //поиск ближайшего маршрута 
            IEnumerable<RoutedLineBreak> col = SearchLineBreakCollection(lineBreakCollection, point1, sMax).Cast<RoutedLineBreak>();
            List<r> rCol = new List<r>();
            foreach (var line in col)
            {
                var route = line.Route;
                var line2= SearchClosedLineBreak(route.LineBreakCollection, point2);
                double s = line.GetDistanceToPoint(point1) + line2.GetDistanceToPoint(point2);
                if (s <= sMax)
                {
                    rCol.Add(new r() { Route = route, S = s });
                }
            }
            return rCol;
        }


        //static Route SearchClosedRoute(Point point1, Point point2, IEnumerable<Route> routeCollection)
        //{
        //    Route nearRoute = null;
        //    IEnumerable<Route> nearRouteCollection = null;
        //    IEnumerable<LineBreak> lineBreakCollection;
        //    var minDistanceLineBreak1 = SearchClosedLineBreak(lineBreakCollection, point1); //ближайщий отрезок к точке 1  
        //    var minDistanceLineBreak2 = SearchClosedLineBreak(lineBreakCollection, point2); //ближайщий отрезок к точке 2

        //    foreach (var route in routeCollection)
        //    {
        //        //поиск ближайшего маршрута 
        //        var minLineBreak = SearchClosedLineBreak(route.LineBreakCollection, point1);//ближайщий отрезок в маршруте
        //        if (minLineBreak == minDistanceLineBreak1)
        //        {
        //            nearRouteCollection = route;
        //        }
        //    }
        //    foreach (var NearRoute in nearRouteCollection)
        //    {
        //        var minLineBreakNearRoute = SearchClosedLineBreak(NearRoute.LineBreakCollection, point2);
        //        if (minLineBreakNearRoute == minDistanceLineBreak2)
        //        {
        //            nearRoute = NearRoute;
        //        }
        //    }
        //    return nearRoute;    
        //}
    }
}
