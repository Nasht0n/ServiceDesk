using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IPriorityLogic
    {
        Task<Priority> GetPriorityById(int id);
        Task<List<Priority>> GetPriorities();
        Task<List<Priority>> GetPrioritiesByDescendings();
    }
}
