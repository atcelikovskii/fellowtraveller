using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataService;

namespace DataServiceTest
{
    [TestClass]
    public class UnitTestDataService
    {
        IDataService ds;
        [TestInitialize]
        public void DataServiceInit() {
            this.ds = new DataServiceRAM();
        }


       [TestMethod]
        public void IDataServiceTest()
        {
            Point p1 = new Point(){
                X=1,
                Y=1
            };
            Point expectedPoint = new Point() { X = 0, Y = 0 };
            Point actualPoint = ds.GetClosedPoint(p1);
            Assert.AreEqual(expectedPoint, expectedPoint);
            
        }
    }
}
