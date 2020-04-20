using Domain.Models.Requests.Accounts;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Accounts.Requests
{
    public interface IAccountDisconnectRequestLogic
    {
        Task<AccountDisconnectRequest> Save(AccountDisconnectRequest request);
        Task Delete(AccountDisconnectRequest request);
        Task<AccountDisconnectRequest> GetRequestById(int id);
    }
}
