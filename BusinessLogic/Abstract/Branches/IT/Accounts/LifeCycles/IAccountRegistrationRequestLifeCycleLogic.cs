using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Accounts.LifeCycles
{
    public interface IAccountRegistrationRequestLifeCycleLogic
    {
        Task<AccountRegistrationRequestLifeCycle> Add(AccountRegistrationRequestLifeCycle lifeCycle);
        Task<List<AccountRegistrationRequestLifeCycle>> GetLifeCycles(AccountRegistrationRequest request);
    }
}
