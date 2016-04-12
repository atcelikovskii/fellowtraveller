using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataService;
using DataService.DomainModel;

namespace DataServiceTest
{
    [TestClass]
    public class UnitTestDataService
    {
        [TestMethod]
        public void ClosedPointSeacrhTest1()
        {
            var p1 = new Point() { X = 3.5, Y = 3 };
            var ps = new PointSearch[]
            {
               new PointSearch() {Point = new Point() { X = 5, Y = 2 } },
               new PointSearch() {Point = new Point() { X = 7, Y = 5 } },
                new PointSearch() {Point = new Point() { X = 10, Y = 6 } },
                new PointSearch() {Point = new Point() { X = 77, Y = 9 } }
            };
            Point expectedPoint =ps[2].Point;
            Point actualPoint = RouteUtils.GetClosedPoint(p1, ps);
            Assert.AreEqual(expectedPoint, actualPoint);
        }

        [TestMethod]
        public void ClosedLineSearchTest2()
        {
            LineBreak lb = new LineBreak(new Point(8, 3), new Point(26, 3));

            Assert.AreEqual(5, lb.GetDistanceToPoint(new Point(18, -2)));
           
            //var C = new PointSearch[]
            //{
            //   new PointSearch() {Point = new Point() { X = 1.5, Y = 2.5 } },
            //   new PointSearch() {Point = new Point() { X = 2.5, Y = 2.5 } },
            //   new PointSearch() {Point = new Point() { X = 4.5, Y = 2.5 } },
            //   new PointSearch() {Point = new Point() { X = 6, Y = 2.5 } },
            //   new PointSearch() {Point = new Point() { X = 7, Y = 2.5 } }
            //};
            

            //Point expectedPoint = C[0].Point; //ожидаемая
            //Point actualPoint = LineBreak.GetDistanceToPoint(A); //текущая
            
        }
    }
}
