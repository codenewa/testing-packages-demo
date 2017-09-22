using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDemo.Model;

namespace TestDemo.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Category> GetAll()
        {
            return new List<Category>();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
