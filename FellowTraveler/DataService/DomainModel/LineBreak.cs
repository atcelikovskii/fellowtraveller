using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.DomainModel
{
   public class LineBreak
    {
        public LineBreak(Point point1,Point point2)
        {
            this.Point1 = point1;
            this.Point2 = point2;
        }

        public Point Point1 { get; set; }
        public Point Point2 { get; set; }

        public double Length
        {
            get
            {
                return RouteUtils.GetDistance(this.Point1, this.Point2);
            }
        }

        double getHeightToPoint(Point point)
        {
           return 
                ((this.Point1.Y - this.Point2.Y) * point.X + (this.Point2.X - this.Point1.X) * point.Y + (this.Point1.X * this.Point2.Y - this.Point2.X * this.Point1.Y)) 
                / Math.Sqrt(Math.Pow(this.Point2.X - this.Point1.X, 2) + Math.Pow(this.Point2.Y - this.Point1.Y, 2));
        }

        public double GetDistanceToPoint(Point point)
        {
            var CF = this.getHeightToPoint(point); // точка перпендикуляра от исходной точки до отрезка

            var CA = point.GetDistance(Point1); // расстояние от исходной точки до начала отрезка
            var CB = point.GetDistance(Point2); // расстояние от исходной точки до конца отрезка 

            var AF = Math.Sqrt(CA * CA - CF * CF); // расстояние от точки перпендикуляра до начала отрезка
            var AB = RouteUtils.GetDistance(this.Point1, this.Point2); // длина отрезка
            var FB = Math.Sqrt(CB * CB - CF * CF); // расстояние от точки перпендикуляра до конца отрезка
            double minDistance = double.MaxValue;

            if (AF + FB == AB)
            {
                CF = minDistance;
                return minDistance;
            }
            else
            {
                if (CA > CB)
                {
                    CB = minDistance;
                    return minDistance;
                }
                else
                {
                    CA = minDistance;
                    return minDistance;
                }
            }
         }



     
        /// Поиск ближайшего отрезка к точке point
       
        //public double GetLength(Point point, IEnumerable<PointSearch> routeCollection)
        //{
        //    // throw new NotImplementedException();
        //    Func<Point, double> h1Func = new Func<Point, double>((point1) => Math.Sqrt(Math.Pow(point.X - point1.X, 2) + Math.Pow(point.Y - point1.Y, 2)));
        //    Func<Point, double> h2Func = new Func<Point, double>((point2) => Math.Sqrt(Math.Pow(point.X - point2.X, 2) + Math.Pow(point.Y - point2.Y, 2)));
        //  //  Func<Point, Point, double> hperFunc = new Func<Point, Point, double>((point1, point2) => ((point1.Y - point2.Y)*point.X +(point2.X - point1.X)*point.Y+(point1.X*point2.Y-point2.X*point1.Y))/ Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2)));
        //    Func<Point, Point, double> lineFunc = new Func<Point, Point, double>((point1, point2) => (point2.X - point1.X) + (point2.Y - point1.Y));
        //    LineBreak closedLine = null;
        //    double hMin = double.MaxValue;

        //    foreach (var routePoint in routeCollection)
        //    {
                

        //        var hper = getHeightToPoint(routePoint.Point, point);
        //        var h1 = h1Func(routePoint.Point);
        //        var h2 = h2Func(routePoint.Point);
        //        var line = lineFunc(routePoint.Point, point);

        //        var hight = Math.Sqrt(Math.Pow(hper - h1, 2));

        //        if (hight > line)
        //        {
        //            if (h1 > h2)
        //            {
        //                hMin = h2;
        //                closedLine = throw new NotImplementedException();
        //            }
        //            else
        //            {
        //                hMin = h1;
        //                closedLine = throw new NotImplementedException();
        //            }
        //        }
        //        else
        //        {
        //            hMin = hper;
        //            closedLine = throw new NotImplementedException();
        //        }
        //    }
        //    return closedLine;
        //}
    }
}
