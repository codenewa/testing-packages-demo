using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDemo.Model
{
    public class LocationCategory
    {
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
