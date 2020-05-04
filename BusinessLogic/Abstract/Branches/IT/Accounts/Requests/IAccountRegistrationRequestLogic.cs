using Domain.Models.Requests.Accounts;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Accounts.Requests
{
    public interface IAccountRegistrationRequestLogic
    {
        Task<AccountRegistrationRequest> Save(AccountRegistrationRequest request);
        Task Delete(AccountRegistrationRequest request);
        Task<AccountRegistrationRequest> GetRequest(int id);
    }
}
