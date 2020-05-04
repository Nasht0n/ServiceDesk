using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IStatusLogic
    {
        Task<Status> GetStatus(int id);
        Task<List<Status>> GetStatuses(bool descending = false);
    }
}
