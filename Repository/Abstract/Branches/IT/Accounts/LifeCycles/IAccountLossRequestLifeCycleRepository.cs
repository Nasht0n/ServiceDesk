using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.LifeCycles
{
    public interface IAccountLossRequestLifeCycleRepository
    {
        Task<AccountLossRequestLifeCycle> Add(AccountLossRequestLifeCycle lifeCycle);
        Task<AccountLossRequestLifeCycle> Update(AccountLossRequestLifeCycle lifeCycle);
        Task Delete(AccountLossRequestLifeCycle lifeCycle);
        Task<List<AccountLossRequestLifeCycle>> GetLifeCycles();
    }
}
