using Domain.Models;
using Domain.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IRequestsLogic
    {
        Task<List<Requests>> GetRequests(bool descending = true);
        Task<List<Requests>> GetRequests(Employee employee, bool descending = true);
        Task<List<Requests>> GetRequests(Employee employee, bool client = false, bool descending = true);
        Task<List<Requests>> GetRequests(Employee employee, Status status, bool descending = true);
        Task<List<Requests>> GetRequests(Employee employee, Status status, bool client= false, bool descending = true);
        Task<List<Requests>> GetRequests(Employee employee, Service service, bool descending = true);
        Task<List<Requests>> GetRequests(Employee employee, Category category, Service service, Status status, bool descending = true);
        Task<List<Requests>> GetRequests(Employee employee, Category category, Service service, Status status, bool client = false, bool descending = true);

        Task<List<Requests>> GetRequests(Account account, bool descending = true);
        Task<List<Requests>> GetRequests(Account account, Category category, Service service, Status status, bool isClient, bool descending = true);
    }
}
