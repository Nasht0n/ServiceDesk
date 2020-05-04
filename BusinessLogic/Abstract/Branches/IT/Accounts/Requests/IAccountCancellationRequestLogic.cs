using Domain.Models.Requests.Accounts;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Accounts.Requests
{
    public interface IAccountCancellationRequestLogic
    {
        Task<AccountCancellationRequest> Save(AccountCancellationRequest request);
        Task Delete(AccountCancellationRequest request);
        Task<AccountCancellationRequest> GetRequest(int id);
    }
}
