using DataService.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace DataService
{
    public class Route
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        [ScriptIgnore]
        public DateTime? Date { get; set; }
        [ScriptIgnore]
        public int? Price { get; set; }
        [ScriptIgnore]
        public int? AmountPassengers { get; set; }

        [ScriptIgnore]
        public User Owner { get; set; }

        //[ScriptIgnore]
        public IEnumerable<Point> Points { get; set; }


        IEnumerable<RoutedLineBreak> lineBreakCollection =  null;
        [ScriptIgnore]
        public IEnumerable<RoutedLineBreak> LineBreakCollection
        {
            get
            {
                if (this.lineBreakCollection!= null) return this.lineBreakCollection;
                var lineBreakCollection = new List<RoutedLineBreak>();
                Point prevPoint = null;
                foreach (var nextPoint in this.Points)
                {
                    if (prevPoint == null) { prevPoint = nextPoint; continue; }
                    lineBreakCollection.Add(new RoutedLineBreak(prevPoint, nextPoint, this));
                }

                return lineBreakCollection;
            }
            set
            {
                lineBreakCollection = value;
            }
        }
    }
}

