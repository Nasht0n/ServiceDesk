using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Requests
{
    public interface IAccountDisconnectRequestRepository
    {
        Task<AccountDisconnectRequest> Add(AccountDisconnectRequest request);
        Task<AccountDisconnectRequest> Update(AccountDisconnectRequest request);
        Task Delete(AccountDisconnectRequest request);
        Task<List<AccountDisconnectRequest>> GetRequests();
    }
}
