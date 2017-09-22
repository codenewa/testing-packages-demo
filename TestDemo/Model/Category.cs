using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDemo.Model;

namespace TestDemo
{
    public class Category
    {
        public Category()
        {
            CategoryLocations = new List<LocationCategory>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<LocationCategory> CategoryLocations { get; set; }

        public virtual bool Add(Location location)
        {
            if (location == null) return false;
            CategoryLocations.Add(new LocationCategory
            {
                Category = this,
                CategoryId = Id,
                Location = location,
                LocationId = location.Id
            });
            return true;
        }

        public virtual bool HasLocation(Location location)
        {
            return CategoryLocations.Any(cl => cl.Location.Id == location.Id);
        }
    }
}
