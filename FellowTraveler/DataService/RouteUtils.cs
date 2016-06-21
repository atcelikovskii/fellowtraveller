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
        public static double GetDistance(this Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
        }

        public static Point SearchClosedPoint(Point point, IEnumerable<PointSearch> collection)
        {
            // поиск ближайшей точки

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

            return closedPoint;
        }

        public static LineBreak SearchClosedLineBreak(IEnumerable<LineBreak> lineBreakCollection, Point point)
        {
            // поиск ближайшего отрезка
            double minDistance = double.MaxValue;
            LineBreak closedLineBreak = null;
            foreach (var lineBreak in lineBreakCollection)
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

        public static List<LineBreak> SearchLineBreakCollection(IEnumerable<LineBreak> lineBreakCollection, Point point, double S)
        {
            // поиск ближайших отрезков
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
        public static List<r> SearchClosedRoute(Point point1, Point point2, IEnumerable<RoutedLineBreak> lineBreakCollection, double sMax)
        {
            //поиск ближайших маршрутов 
            IEnumerable<RoutedLineBreak> col = SearchLineBreakCollection(lineBreakCollection, point1, sMax / 2).Cast<RoutedLineBreak>();
            List<r> rCol = new List<r>();
            foreach (var line in col)
            {
                var route = line.Route;
                var line2 = SearchClosedLineBreak(route.LineBreakCollection, point2);
                double s = line.GetDistanceToPoint(point1) + line2.GetDistanceToPoint(point2);
                if (s <= sMax)
                {
                    rCol.Add(new r() { Route = route, S = s });
                }
            }
            return rCol;
        }
    }
}
