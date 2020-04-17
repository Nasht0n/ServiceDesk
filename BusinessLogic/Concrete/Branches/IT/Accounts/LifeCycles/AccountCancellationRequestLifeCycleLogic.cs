using BusinessLogic.Abstract.Branches.IT.Accounts.LifeCycles;
using Domain.Models.Requests.Accounts;
using Repository.Abstract.Branches.IT.Accounts.LifeCycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<List<AccountCancellationRequestLifeCycle>> GetLifeCycles(int requestId)
        {
            var lifeCycles = await repository.GetLifeCycles();
            return lifeCycles.Where(lc => lc.RequestId == requestId).ToList();
        }
    }
}
