using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ICategoryLogic
    {
        Task<Category> GetCategory(int id);
        Task<List<Category>> GetCategories(bool descendings = false);
        Task<List<Category>> GetCategories(Branch branch, bool descendings = false);
    }
}
