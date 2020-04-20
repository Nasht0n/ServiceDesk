using BusinessLogic.Abstract.Branches.IT.Accounts.LifeCycles;
using Domain.Models.Requests.Accounts;
using Repository.Abstract.Branches.IT.Accounts.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Accounts.LifeCycles
{
    public class AccountLossRequestLifeCycleLogic : IAccountLossRequestLifeCycleLogic
    {
        private readonly IAccountLossRequestLifeCycleRepository repository;

        public AccountLossRequestLifeCycleLogic(IAccountLossRequestLifeCycleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AccountLossRequestLifeCycle> Add(AccountLossRequestLifeCycle lifeCycle)
        {
            return await repository.Add(lifeCycle);
        }

        public async Task<List<AccountLossRequestLifeCycle>> GetLifeCycles(AccountLossRequest request)
        {
            var lifeCycles = await repository.GetLifeCycles();
            return lifeCycles.Where(lc => lc.RequestId == request.Id).ToList();
        }
    }
}
