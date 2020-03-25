using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(Category category);
        Task<List<Category>> GetCategories();
    }
}
