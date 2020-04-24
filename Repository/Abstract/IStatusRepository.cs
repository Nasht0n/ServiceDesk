using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IStatusRepository
    {
        Task<Status> Add(Status status);
        Task<Status> Update(Status status);
        Task Delete(Status status);
        Task<List<Status>> GetStatuses();
    }
}
