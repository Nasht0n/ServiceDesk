using Domain.Models.Requests.Email;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Emails.Requests
{
    public interface IEmailRegistrationRequestLogic
    {
        Task<EmailRegistrationRequest> Save(EmailRegistrationRequest request);
        Task Delete(EmailRegistrationRequest request);
        Task<EmailRegistrationRequest> GetRequest(int id);
    }
}
