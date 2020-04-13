using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.LifeCycles
{
    public interface IAccountCancellationRequestLifeCycleRepository
    {
        Task<AccountCancellationRequestLifeCycle> Add(AccountCancellationRequestLifeCycle lifeCycle);
        Task<AccountCancellationRequestLifeCycle> Update(AccountCancellationRequestLifeCycle lifeCycle);
        Task Delete(AccountCancellationRequestLifeCycle lifeCycle);
        Task<List<AccountCancellationRequestLifeCycle>> GetLifeCycles();
    }
}
