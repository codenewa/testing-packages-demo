using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDemo.Model;

namespace TestDemo.Repositories
{
    public class LocationRepository : IRepository<Location>
    {
        public LocationRepository()
        {
        }

        public Location Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Location> GetAll()
        {
            return new List<Location>();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
