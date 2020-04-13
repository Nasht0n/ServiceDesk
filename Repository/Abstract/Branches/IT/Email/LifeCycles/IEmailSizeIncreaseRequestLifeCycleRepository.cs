using Domain.Models.Requests.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Email.LifeCycles
{
    public interface IEmailSizeIncreaseRequestLifeCycleRepository
    {
        Task<EmailSizeIncreaseRequestLifeCycle> Add(EmailSizeIncreaseRequestLifeCycle lifeCycle);
        Task<EmailSizeIncreaseRequestLifeCycle> Update(EmailSizeIncreaseRequestLifeCycle lifeCycle);
        Task Delete(EmailSizeIncreaseRequestLifeCycle lifeCycle);
        Task<List<EmailSizeIncreaseRequestLifeCycle>> GetLifeCycles();
    }
}
