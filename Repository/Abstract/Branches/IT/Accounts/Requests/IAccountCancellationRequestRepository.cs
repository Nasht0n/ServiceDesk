using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Requests
{
    public interface IAccountCancellationRequestRepository
    {
        Task<AccountCancellationRequest> Add(AccountCancellationRequest request);
        Task<AccountCancellationRequest> Update(AccountCancellationRequest request);
        Task Delete(AccountCancellationRequest request);
        Task<List<AccountCancellationRequest>> GetRequests();
    }
}
