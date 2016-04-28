using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.DomainModel
{
    public class RoutedLineBreak:LineBreak
    {
        public RoutedLineBreak(Point point1, Point point2, Route route) : base(point1, point2)
        {

        }

        public Route Route { get; set; }
    }
}
