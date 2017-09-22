using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDemo.Model;
using TestDemo.Repositories;

namespace TestDemo.Application
{
    public class CategoryApp
    {
        private readonly IRepository<Location> _locRepo;
        private readonly IRepository<Category> _categoryRepo;

        public CategoryApp(IRepository<Location> locationRepo,
            IRepository<Category> categoryRepo
            )
        {
            _locRepo = locationRepo;
            _categoryRepo = categoryRepo;
        }

        public bool AddLocation(int categoryId, int locationid)
        {
            var location = _locRepo.Get(locationid);
            var category = _categoryRepo.Get(categoryId);
            if (!category.HasLocation(location))
            {
                var returnVal = category.Add(location);
                _categoryRepo.Update(category);
                return returnVal;
            }
            return false;
        }
    }
}
