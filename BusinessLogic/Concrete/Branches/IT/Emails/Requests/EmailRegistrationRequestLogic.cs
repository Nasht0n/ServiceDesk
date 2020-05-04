using BusinessLogic.Abstract.Branches.IT.Emails.Requests;
using Domain.Models.Requests.Email;
using Repository.Abstract.Branches.IT.Email.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Emails.Requests
{
    public class EmailRegistrationRequestLogic : IEmailRegistrationRequestLogic
    {
        private readonly IEmailRegistrationRequestRepository repository;

        public EmailRegistrationRequestLogic(IEmailRegistrationRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(EmailRegistrationRequest request)
        {
            await repository.Delete(request);
        }

        public async Task<EmailRegistrationRequest> GetRequest(int id)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<EmailRegistrationRequest> Save(EmailRegistrationRequest request)
        {
            EmailRegistrationRequest result;
            if (request.Id == 0) result = await repository.Add(request);
            else result = await repository.Update(request);
            return result;
        }
    }
}
