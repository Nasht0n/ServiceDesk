using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.LifeCycles
{
    public interface IAccountRegistrationRequestLifeCycleRepository
    {
        Task<AccountRegistrationRequestLifeCycle> Add(AccountRegistrationRequestLifeCycle lifeCycle);
        Task<AccountRegistrationRequestLifeCycle> Update(AccountRegistrationRequestLifeCycle lifeCycle);
        Task Delete(AccountRegistrationRequestLifeCycle lifeCycle);
        Task<List<AccountRegistrationRequestLifeCycle>> GetLifeCycles();
    }
}
