using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Accounts.LifeCycles
{
    public interface IAccountDisconnectRequestLifeCycleLogic
    {
        Task<AccountDisconnectRequestLifeCycle> Add(AccountDisconnectRequestLifeCycle lifeCycle);
        Task<List<AccountDisconnectRequestLifeCycle>> GetLifeCycles(AccountDisconnectRequest request);
    }
}
