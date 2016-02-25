using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.DomainModel
{
   public  class LineBreak
    {
        public Point point1 { get; set; }
        public Point point2 { get; set; }

        public double GetLength(Point point )
        {
            throw new NotImplementedException();
        }
    }
}
