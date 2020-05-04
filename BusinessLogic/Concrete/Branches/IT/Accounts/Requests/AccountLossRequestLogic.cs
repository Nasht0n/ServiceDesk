using BusinessLogic.Abstract.Branches.IT.Accounts.Requests;
using Domain.Models.Requests.Accounts;
using Repository.Abstract.Branches.IT.Accounts.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Accounts.Requests
{
    public class AccountLossRequestLogic : IAccountLossRequestLogic
    {
        private readonly IAccountLossRequestRepository repository;

        public AccountLossRequestLogic(IAccountLossRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(AccountLossRequest request)
        {
            await repository.Delete(request);
        }

        public async Task<AccountLossRequest> GetRequest(int id)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<AccountLossRequest> Save(AccountLossRequest request)
        {
            AccountLossRequest result;
            if (request.Id == 0) result = await repository.Add(request);
            else result = await repository.Update(request);
            return result;
        }
    }
}
