using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.LifeCycles
{
    public interface IAccountDisconnectRequestLifeCycleRepository
    {
        Task<AccountDisconnectRequestLifeCycle> Add(AccountDisconnectRequestLifeCycle lifeCycle);
        Task<AccountDisconnectRequestLifeCycle> Update(AccountDisconnectRequestLifeCycle lifeCycle);
        Task Delete(AccountDisconnectRequestLifeCycle lifeCycle);
        Task<List<AccountDisconnectRequestLifeCycle>> GetLifeCycles();
    }
}
