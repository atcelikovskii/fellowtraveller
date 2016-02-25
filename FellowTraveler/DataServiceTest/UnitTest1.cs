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
            var p1 = new Point() { X = 1, Y = 2 };
            var ps = new PointSearch[]
            {
               new PointSearch() {Point = new Point() { X = 0, Y = 2 } },
               new PointSearch() {Point = new Point() { X = 1, Y = 5 } },
                new PointSearch() {Point = new Point() { X = 5, Y = 6 } },
                new PointSearch() {Point = new Point() { X = 7, Y = 9 } }
            };
            Point expectedPoint =ps[0].Point;
            Point actualPoint = RouteUtils.GetClosedPoint(p1, ps);
            Assert.AreEqual(expectedPoint, actualPoint);
        }
    }
}
