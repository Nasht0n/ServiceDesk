using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IPriorityLogic
    {
        Task<Priority> GetPriority(int id);
        Task<List<Priority>> GetPriorities(bool descendings = false);
    }
}
