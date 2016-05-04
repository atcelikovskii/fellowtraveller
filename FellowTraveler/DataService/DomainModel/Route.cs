using DataService.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class Route
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime? Date { get; set; }
        public int? Price { get; set; }
        public int? AmountPassengers { get; set; }

        public User Owner { get; set; }
        public IEnumerable<Point> Points { get; }

        public List<RoutedLineBreak> LineBreakCollection = new List<RoutedLineBreak>();
        //public IEnumerable<RoutedLineBreak> LineBreakCollection
        //{
        //    get
        //    {

        //        //var lineBreakCollection = new List<RoutedLineBreak>();
        //        //Point prevPoint = null;
        //        //foreach (var nextPoint in this.Points)
        //        //{
        //        //    if (prevPoint == null) { prevPoint = nextPoint; continue; }
        //        //     lineBreakCollection.Add(new RoutedLineBreak(prevPoint, nextPoint));
        //        //}

        //        return lineBreakCollection;
        //    }
        //    set
        //    {
        //        lineBreakCollection = value;
        //    }
        }
    }

