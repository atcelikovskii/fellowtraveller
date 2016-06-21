using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataService;
using DataService.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace DataServiceTest
{
    [TestClass]
    public class UnitTestRouteUtils
    {
        [TestMethod]
        public void ClosedPointSeacrhTest1()
        {
            // поиск ближайшей точки к текущей
            var p1 = new Point() { X = 3.5, Y = 3 };
            var ps = new PointSearch[]
            {
               new PointSearch() {Point = new Point() { X = 5, Y = 2 } },
               new PointSearch() {Point = new Point() { X = 7, Y = 5 } },
                new PointSearch() {Point = new Point() { X = 10, Y = 6 } },
                new PointSearch() {Point = new Point() { X = 77, Y = 9 } }
            };
            Point expectedPoint = ps[0].Point;
            Point actualPoint = RouteUtils.SearchClosedPoint(p1, ps);
            Assert.AreEqual(expectedPoint, actualPoint);
        }

        [TestMethod]
        public void ClosedPointLineSearchTest2()
        {
            //  поиск ближайшего отрезка к точке
            LineBreak lb = new LineBreak(new Point(8, 3), new Point(26, 3));
            Assert.AreEqual(3, lb.GetDistanceToPoint(new Point(18, -2)));
        }

        [TestMethod]
        public void ClosedLineBreakSearchTest3()
        {
            // поиск ближайших отрезков к точке
            var p1 = new Point() { X = 5.5, Y = 6 };
            var lines = new LineBreak[]
            {
               new LineBreak  (new Point (4.5,5.5) , new Point(7, 5.5)),
               new LineBreak  (new Point(5.5,5) , new Point(6.5, 4.5)),
               new LineBreak (new Point(6.5,6.5), new Point(8, 6.5)),
               new LineBreak (new Point(5,6.5) , new Point(6, 7.5)),
               new LineBreak (new Point(6,6), new Point(8,6)),
               new LineBreak (new Point(7.5, 5.5), new Point(9,4.5))
            };
            var expected = new LineBreak[]
            {
                lines[0],
                lines[4],
                lines[3],
                lines[1]
            };
            var actual = RouteUtils.SearchLineBreakCollection(lines, p1, 1);
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void ClosedRouteSearchTest4()
        {
            // поиск ближайшего маршрута к точке
            var p1 = new Point() { X = 5.5, Y = 6 };
            var p2 = new Point() { X = 12.5, Y = 4.5 };

            var routes = new Route[]
                {
                new Route(),
                new Route(),
                new Route(),
                new Route(),
                new Route(),
                new Route(),
                new Route()
                };
            routes[0].LineBreakCollection = new List<RoutedLineBreak>() {
                new RoutedLineBreak(new Point(4.5, 5.5), new Point(7, 5.5), routes[0]),
                new RoutedLineBreak(new Point(7, 5.5), new Point(8.5, 3), routes[0]),
                new RoutedLineBreak(new Point(8.5, 3), new Point(12,3), routes[0]),
                new RoutedLineBreak(new Point(12,3), new Point(13,4), routes[0]),
                };
            routes[1].LineBreakCollection = new List<RoutedLineBreak>() {
                new RoutedLineBreak(new Point(5.5, 5), new Point(6.5, 4.5), routes[1]),
                new RoutedLineBreak(new Point(6.5, 4.5), new Point(8.5, 4.5), routes[1]),
                new RoutedLineBreak(new Point(8.5, 4.5), new Point(11, 5.5), routes[1]),
                new RoutedLineBreak(new Point(11, 5.5), new Point(12, 4), routes[1]),
                };
            routes[2].LineBreakCollection = new List<RoutedLineBreak>() {
                new RoutedLineBreak(new Point(6.5, 6.5), new Point(8, 6.5), routes[2]),
                new RoutedLineBreak(new Point(8, 6.5), new Point(11.5, 7.2), routes[2]),
                new RoutedLineBreak(new Point(11.5, 7.2), new Point(12.5,5), routes[2])
                };
            routes[3].LineBreakCollection = new List<RoutedLineBreak>() {
                new RoutedLineBreak(new Point(5, 6.5), new Point(6, 7.5), routes[3]),
                new RoutedLineBreak(new Point(6, 7.5), new Point(11.5, 8), routes[3])
                };
            routes[4].LineBreakCollection = new List<RoutedLineBreak>() {
                new RoutedLineBreak(new Point(6, 6), new Point(8, 6), routes[4]),
                new RoutedLineBreak(new Point(8, 6), new Point(14.5, 6), routes[4]),
                new RoutedLineBreak(new Point(14.5, 6), new Point(14, 4.5), routes[4])
                };
            routes[5].LineBreakCollection = new List<RoutedLineBreak>() {
                new RoutedLineBreak(new Point(7.5, 5.5), new Point(9, 4.5), routes[5]),
                new RoutedLineBreak(new Point(9, 4.5), new Point(11.5, 4.5), routes[5]),
                new RoutedLineBreak(new Point(11.5, 4.5), new Point(12.7, 5.5), routes[5])
                };
            routes[6].LineBreakCollection = new List<RoutedLineBreak>() {
                new RoutedLineBreak(new Point(6, 3), new Point(8.5, 4.5), routes[6]),
                new RoutedLineBreak(new Point(8.5, 4.5), new Point(11.5, 4.5), routes[6]),
                new RoutedLineBreak(new Point(11.5, 4.5), new Point(12, 3.5), routes[6])
                };
            var allLines = routes.SelectMany(r => r.LineBreakCollection);
            var actual = RouteUtils.SearchClosedRoute(p1, p2, allLines, 2);

            var expected = new List<RouteUtils.r>() {
                new RouteUtils.r() {Route = routes[0], S = 1.2 },
                new RouteUtils.r() {Route = routes[1], S = 1.7 },
                new RouteUtils.r() {Route = routes[2], S = 2 }
            };

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
