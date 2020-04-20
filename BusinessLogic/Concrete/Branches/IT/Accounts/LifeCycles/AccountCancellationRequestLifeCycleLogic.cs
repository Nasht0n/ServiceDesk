using BusinessLogic.Abstract.Branches.IT.Accounts.LifeCycles;
using Domain.Models.Requests.Accounts;
using Repository.Abstract.Branches.IT.Accounts.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Accounts.LifeCycles
{
    public class AccountCancellationRequestLifeCycleLogic : IAccountCancellationRequestLifeCycleLogic
    {
        private readonly IAccountCancellationRequestLifeCycleRepository repository;

        public AccountCancellationRequestLifeCycleLogic(IAccountCancellationRequestLifeCycleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AccountCancellationRequestLifeCycle> Add(AccountCancellationRequestLifeCycle lifeCycle)
        {
            return await repository.Add(lifeCycle);
        }

        public async Task<List<AccountCancellationRequestLifeCycle>> GetLifeCycles(AccountCancellationRequest request)
        {
            var lifeCycles = await repository.GetLifeCycles();
            return lifeCycles.Where(lc => lc.RequestId == request.Id).ToList();
        }
    }
}
