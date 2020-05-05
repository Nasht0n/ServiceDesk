using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Category>> GetCategories(Branch branch, bool descendings = false)
        {
            var categories = await categoryRepository.GetCategories();
            if(descendings) return categories.Where(c => c.BranchId == branch.Id).OrderByDescending(c=>c.Name).ToList();
            else return categories.Where(c => c.BranchId == branch.Id).OrderBy(c=>c.Name).ToList();
        }

        public async Task<List<Category>> GetCategories(bool descendings = false)
        {
            var categories = await categoryRepository.GetCategories();
            if (descendings) return categories.OrderByDescending(c => c.Name).ToList();
            else return categories.OrderBy(c => c.Name).ToList();
        }

        public async Task<Category> GetCategory(int id)
        {
            var categories = await categoryRepository.GetCategories();
            return categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
