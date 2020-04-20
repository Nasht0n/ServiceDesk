using BusinessLogic.Abstract.Branches.IT.Accounts.Requests;
using Domain.Models.Requests.Accounts;
using Repository.Abstract.Branches.IT.Accounts.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Accounts.Requests
{
    public class AccountDisconnectRequestLogic : IAccountDisconnectRequestLogic
    {
        private readonly IAccountDisconnectRequestRepository repository;

        public AccountDisconnectRequestLogic(IAccountDisconnectRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(AccountDisconnectRequest request)
        {
            await repository.Delete(request);
        }

        public async Task<AccountDisconnectRequest> GetRequestById(int id)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<AccountDisconnectRequest> Save(AccountDisconnectRequest request)
        {
            AccountDisconnectRequest result;
            if (request.Id == 0) result = await repository.Add(request);
            else result = await repository.Update(request);
            return result;
        }
    }
}
