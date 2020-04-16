using Domain.Models;
using Domain.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IRequestsLogic
    {
        Task<List<Requests>> GetRequests();
        Task<List<Requests>> GetRequests(Employee employee, int service, bool descending = true);
        Task<List<Requests>> GetRequestsByDescending();
    }
}
