using Domain.Models.Requests.Accounts;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Accounts.Requests
{
    public interface IAccountLossRequestLogic
    {
        Task<AccountLossRequest> Save(AccountLossRequest request);
        Task Delete(AccountLossRequest request);
        Task<AccountLossRequest> GetRequest(int id);
    }
}
