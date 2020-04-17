using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Accounts.LifeCycles
{
    public interface IAccountCancellationRequestLifeCycleLogic
    {
        Task<AccountCancellationRequestLifeCycle> Add(AccountCancellationRequestLifeCycle lifeCycle);
        Task<List<AccountCancellationRequestLifeCycle>> GetLifeCycles(int requestId);
    }
}
