using Domain.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IRequestRepository
    {
        Task<List<Requests>> GetRequests();
    }
}
