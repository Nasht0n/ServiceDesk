using Domain.Models.Requests.Email;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Emails.Requests
{
    public interface IEmailSizeIncreaseRequestLogic
    {
        Task<EmailSizeIncreaseRequest> Save(EmailSizeIncreaseRequest request);
        Task Delete(EmailSizeIncreaseRequest request);
        Task<EmailSizeIncreaseRequest> GetRequestById(int id);
    }
}
