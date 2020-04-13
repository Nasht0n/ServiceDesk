using Domain.Models.Requests.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Email.Requests
{
    public interface IEmailSizeIncreaseRequestRepository
    {
        Task<EmailSizeIncreaseRequest> Add(EmailSizeIncreaseRequest request);
        Task<EmailSizeIncreaseRequest> Update(EmailSizeIncreaseRequest request);
        Task Delete(EmailSizeIncreaseRequest request);
        Task<List<EmailSizeIncreaseRequest>> GetRequests();
    }
}
