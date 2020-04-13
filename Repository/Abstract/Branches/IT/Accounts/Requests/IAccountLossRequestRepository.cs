using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Requests
{
    public interface IAccountLossRequestRepository
    {
        Task<AccountLossRequest> Add(AccountLossRequest request);
        Task<AccountLossRequest> Update(AccountLossRequest request);
        Task Delete(AccountLossRequest request);
        Task<List<AccountLossRequest>> GetRequests();
    }
}
