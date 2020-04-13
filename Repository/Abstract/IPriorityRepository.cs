using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IPriorityRepository
    {
        Task<Priority> Add(Priority priority);
        Task<Priority> Update(Priority priority);
        Task Delete(Priority priority);
        Task<List<Priority>> GetPriorities();        
    }
}
