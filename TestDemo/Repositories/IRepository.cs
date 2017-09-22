using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDemo.Model;

namespace TestDemo.Repositories
{
    public interface IRepository<T>
    {
        IList<T> GetAll();
        T Get(int id);
        void Update(Category category);
    }
}
