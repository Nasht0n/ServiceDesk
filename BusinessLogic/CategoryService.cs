using DataAccess.Concrete;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class CategoryService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public List<Category> GetCategories()
        {
            return serviceDesk.CategoryRepository.Get(includeProperties: "Branch").ToList();
        }

        public Category GetCategoryById(int id)
        {
            return serviceDesk.CategoryRepository.Get(filter: e => e.Id == id, includeProperties: "Branch").FirstOrDefault();
        }

        public void AddCategory(Category category)
        {
            serviceDesk.CategoryRepository.Insert(category);
            serviceDesk.Save();
        }

        public void UpdateCategory(Category category)
        {
            serviceDesk.CategoryRepository.Update(category);
            serviceDesk.Save();
        }

        public void DeleteCategory(Category category)
        {
            serviceDesk.CategoryRepository.Delete(category);
            serviceDesk.Save();
        }
    }
}
