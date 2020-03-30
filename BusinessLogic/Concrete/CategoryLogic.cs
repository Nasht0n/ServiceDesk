using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryLogic(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetCategoriesByBranchId(int branchId)
        {
            var categories = await categoryRepository.GetCategories();
            return categories.Where(c => c.BranchId == branchId).ToList();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var categories = await categoryRepository.GetCategories();
            return categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
