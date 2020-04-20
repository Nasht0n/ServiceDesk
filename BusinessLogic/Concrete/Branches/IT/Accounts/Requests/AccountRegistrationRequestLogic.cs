using BusinessLogic.Abstract.Branches.IT.Accounts.Requests;
using Domain.Models.Requests.Accounts;
using Repository.Abstract.Branches.IT.Accounts.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Accounts.Requests
{
    public class AccountRegistrationRequestLogic : IAccountRegistrationRequestLogic
    {
        private readonly IAccountRegistrationRequestRepository repository;

        public AccountRegistrationRequestLogic(IAccountRegistrationRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(AccountRegistrationRequest request)
        {
            await repository.Delete(request);
        }

        public async Task<AccountRegistrationRequest> GetRequestById(int id)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<AccountRegistrationRequest> Save(AccountRegistrationRequest request)
        {
            AccountRegistrationRequest result;
            if (request.Id == 0) result = await repository.Add(request);
            else result = await repository.Update(request);
            return result;
        }
    }
}
