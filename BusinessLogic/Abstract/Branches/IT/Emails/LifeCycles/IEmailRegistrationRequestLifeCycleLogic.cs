using Domain.Models.Requests.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Emails.LifeCycles
{
    public interface IEmailRegistrationRequestLifeCycleLogic
    {
        Task<EmailRegistrationRequestLifeCycle> Add(EmailRegistrationRequestLifeCycle lifeCycle);
        Task<List<EmailRegistrationRequestLifeCycle>> GetLifeCycles(EmailRegistrationRequest request);
    }
}
