using BusinessLogic.Abstract.Branches.IT.Accounts.Requests;
using Domain.Models.Requests.Accounts;
using Repository.Abstract.Branches.IT.Accounts.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Accounts.Requests
{
    public class AccountCancellationRequestLogic : IAccountCancellationRequestLogic
    {
        private readonly IAccountCancellationRequestRepository repository;

        public AccountCancellationRequestLogic(IAccountCancellationRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(AccountCancellationRequest request)
        {
            await repository.Delete(request);
        }

        public async Task<AccountCancellationRequest> GetRequestById(int id)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<AccountCancellationRequest> Save(AccountCancellationRequest request)
        {
            AccountCancellationRequest result;
            if (request.Id == 0) result = await repository.Add(request);
            else result = await repository.Update(request);
            return result;
        }
    }
}
