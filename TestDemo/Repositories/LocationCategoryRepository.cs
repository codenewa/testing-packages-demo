using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDemo.Model;

namespace TestDemo.Repositories
{
    public class LocationCategoryRepository : IRepository<LocationCategory>
    {
        public LocationCategory Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<LocationCategory> GetAll()
        {
            return new List<LocationCategory>();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
