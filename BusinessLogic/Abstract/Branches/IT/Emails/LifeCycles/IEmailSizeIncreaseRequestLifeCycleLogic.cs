using Domain.Models.Requests.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Emails.LifeCycles
{
    public interface IEmailSizeIncreaseRequestLifeCycleLogic
    {
        Task<EmailSizeIncreaseRequestLifeCycle> Add(EmailSizeIncreaseRequestLifeCycle lifeCycle);
        Task<List<EmailSizeIncreaseRequestLifeCycle>> GetLifeCycles(EmailSizeIncreaseRequest request);
    }
}
