using BusinessLogic.Abstract.Branches.IT.Accounts.LifeCycles;
using Domain.Models.Requests.Accounts;
using Repository.Abstract.Branches.IT.Accounts.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Accounts.LifeCycles
{
    public class AccountRegistrationRequestLifeCycleLogic : IAccountRegistrationRequestLifeCycleLogic
    {
        private readonly IAccountRegistrationRequestLifeCycleRepository repository;

        public AccountRegistrationRequestLifeCycleLogic(IAccountRegistrationRequestLifeCycleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AccountRegistrationRequestLifeCycle> Add(AccountRegistrationRequestLifeCycle lifeCycle)
        {
            return await repository.Add(lifeCycle);
        }

        public async Task<List<AccountRegistrationRequestLifeCycle>> GetLifeCycles(AccountRegistrationRequest request)
        {
            var lifeCycles = await repository.GetLifeCycles();
            return lifeCycles.Where(lc => lc.RequestId == request.Id).ToList();
        }
    }
}
