using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataService;
using DataService.DomainModel;

namespace DataServiceTest
{
    [TestClass]
    public class UnitTestRouteUtils
    {
        [TestMethod]
        public void ClosedPointSeacrhTest1()
        {
            // поиск ближайщей точки к текущей
            var p1 = new Point() { X = 3.5, Y = 3 };
            var ps = new PointSearch[]
            {
               new PointSearch() {Point = new Point() { X = 5, Y = 2 } },
               new PointSearch() {Point = new Point() { X = 7, Y = 5 } },
                new PointSearch() {Point = new Point() { X = 10, Y = 6 } },
                new PointSearch() {Point = new Point() { X = 77, Y = 9 } }
            };
            Point expectedPoint = ps[2].Point;
            Point actualPoint = RouteUtils.SearchClosedPoint(p1, ps);
            Assert.AreEqual(expectedPoint, actualPoint);
        }

        [TestMethod]
        public void ClosedPointLineSearchTest2()
        {
            //  поиск ближайщего отрезка к точке
            LineBreak lb = new LineBreak(new Point(8, 3), new Point(26, 3));
            Assert.AreEqual(5, lb.GetDistanceToPoint(new Point(18, -2)));
        }

        [TestMethod]
        public void ClosedLineBreakSearchTest3()
        {
            // поиск ближайщего отрезка к точке
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
            // поиск ближайщего маршрута к точке
            var p1 = new Point() { X = 5.5, Y = 6 };
            var p2 = new Point() { X = 12.5, Y = 4.5 };
            var lines = new LineBreak[]
           {
               new LineBreak  (new Point (4.5,5.5) , new Point(7, 5.5)),
               new LineBreak  (new Point(5.5,5) , new Point(6.5, 4.5)),
               new LineBreak (new Point(6.5,6.5), new Point(8, 6.5)),
               new LineBreak (new Point(5,6.5) , new Point(6, 7.5)),
               new LineBreak (new Point(6,6), new Point(8,6)),
               new LineBreak (new Point(7.5, 5.5), new Point(9,4.5))
           };
            var actual = RouteUtils.SearchLineBreakCollection(lines, p1, 1);
            var routes = new Route[]
                {
                 //  new RoutedLineBreak { new Route (new LineBreak {new Point (4.5, 5.5), new Point(7, 5.5)})
                };
            var route = new RoutedLineBreak[]
            {
                new RoutedLineBreak (new Point (4.5,5.5), new Point(7, 5.5), new Route ()),
            };
        }
    }
}
