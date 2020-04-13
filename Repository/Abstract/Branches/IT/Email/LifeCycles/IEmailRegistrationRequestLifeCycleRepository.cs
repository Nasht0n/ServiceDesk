using Domain.Models.Requests.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Email.LifeCycles
{
    public interface IEmailRegistrationRequestLifeCycleRepository
    {
        Task<EmailRegistrationRequestLifeCycle> Add(EmailRegistrationRequestLifeCycle lifeCycle);
        Task<EmailRegistrationRequestLifeCycle> Update(EmailRegistrationRequestLifeCycle lifeCycle);
        Task Delete(EmailRegistrationRequestLifeCycle lifeCycle);
        Task<List<EmailRegistrationRequestLifeCycle>> GetLifeCycles();
    }
}
