using DataService.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
   public static  class RouteUtils
    {
        static Func<Point, Point, double> sFunc = new Func<Point, Point, double>((p1, p2) => Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)));

        public static Point   GetClosedPoint(Point point, IEnumerable<PointSearch> collection)
        {
            //throw new NotImplementedException();
            //return PointList.Min(p => Math.Sqrt(Math.Pow(p.Point.X - point.X, 2) + Math.Pow(p.Point.Y - point.Y, 2)));
            Point closedPoint = null;// PointList[0].Point;
          
            double sMin = double.MaxValue;// sFunc(closedPoint, point);
            foreach (var pointSearch in collection)
            {
                var s = sFunc(pointSearch.Point, point);
                if (sMin > s)
                {
                    sMin = s;
                    closedPoint = pointSearch.Point;
                }
            }
            //PointList.ForEach(p =>  Math.Sqrt(Math.Pow(p.Point.X - point.X, 2) + Math.Pow(p.Point.Y - point.Y, 2)));
            return closedPoint;
        }



        Route GetClosedRoute(Point point, IEnumerable<Route> routeCollection)
        {
            foreach(var route in routeCollection)
            {
                Point prevPoint = null;
                foreach(var nextPoint in route.Points)
                {
                    if (prevPoint == null) { prevPoint = nextPoint; continue; }
                    LineBreak l = new LineBreak() { point1 = prevPoint, point2 = nextPoint };
                    double length = l.GetLength(point);
                    //поиск минимального расстояния и соответсвующего маршрута
                }

            }

            throw new NotImplementedException();
            
           
        }
    }
}
