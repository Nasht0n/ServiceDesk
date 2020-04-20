using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Accounts.LifeCycles
{
    public interface IAccountLossRequestLifeCycleLogic
    {
        Task<AccountLossRequestLifeCycle> Add(AccountLossRequestLifeCycle lifeCycle);
        Task<List<AccountLossRequestLifeCycle>> GetLifeCycles(AccountLossRequest request);
    }
}
