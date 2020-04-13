using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Requests
{
    public interface IAccountRegistrationRequestRepository
    {
        Task<AccountRegistrationRequest> Add(AccountRegistrationRequest request);
        Task<AccountRegistrationRequest> Update(AccountRegistrationRequest request);
        Task Delete(AccountRegistrationRequest request);
        Task<List<AccountRegistrationRequest>> GetRequests();
    }
}
