using BusinessLogic.Abstract.Branches.IT.Accounts.LifeCycles;
using Domain.Models.Requests.Accounts;
using Repository.Abstract.Branches.IT.Accounts.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Accounts.LifeCycles
{
    public class AccountDisconnectRequestLifeCycleLogic : IAccountDisconnectRequestLifeCycleLogic
    {
        private readonly IAccountDisconnectRequestLifeCycleRepository repository;

        public AccountDisconnectRequestLifeCycleLogic(IAccountDisconnectRequestLifeCycleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AccountDisconnectRequestLifeCycle> Add(AccountDisconnectRequestLifeCycle lifeCycle)
        {
            return await repository.Add(lifeCycle);
        }

        public async Task<List<AccountDisconnectRequestLifeCycle>> GetLifeCycles(AccountDisconnectRequest request)
        {
            var lifeCycles = await repository.GetLifeCycles();
            return lifeCycles.Where(lc => lc.RequestId == request.Id).ToList();
        }
    }
}
