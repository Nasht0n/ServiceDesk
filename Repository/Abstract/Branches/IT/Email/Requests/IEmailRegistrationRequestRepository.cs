using Domain.Models.Requests.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Email.Requests
{
    public interface IEmailRegistrationRequestRepository
    {
        Task<EmailRegistrationRequest> Add(EmailRegistrationRequest request);
        Task<EmailRegistrationRequest> Update(EmailRegistrationRequest request);
        Task Delete(EmailRegistrationRequest request);
        Task<List<EmailRegistrationRequest>> GetRequests();
    }
}
