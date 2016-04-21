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
            //throw new NotImplementedException();
            //return PointList.Min(p => Math.Sqrt(Math.Pow(p.Point.X - point.X, 2) + Math.Pow(p.Point.Y - point.Y, 2)));
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

        static LineBreak SearchClosedLineBreak(IEnumerable<LineBreak> lineBreakCollection, Point point)
        {
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

        static Route SearchClosedRoute(Point point, IEnumerable<Route> routeCollection)
        {
            foreach(var route in routeCollection)
            {
                //поиск ближайшего маршрута 
                var minDistanceLineBreak = SearchClosedLineBreak(route.LineBreakCollection, point);
            }

            throw new NotImplementedException();
            
           
        }
    }
}
