using BusinessLogic.Abstract.Branches.IT.Emails.LifeCycles;
using Domain.Models.Requests.Email;
using Repository.Abstract.Branches.IT.Email.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Emails.LifeCycles
{
    public class EmailRegistrationRequestLifeCycleLogic : IEmailRegistrationRequestLifeCycleLogic
    {
        private readonly IEmailRegistrationRequestLifeCycleRepository repository;

        public EmailRegistrationRequestLifeCycleLogic(IEmailRegistrationRequestLifeCycleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<EmailRegistrationRequestLifeCycle> Add(EmailRegistrationRequestLifeCycle lifeCycle)
        {
            return await repository.Add(lifeCycle);
        }

        public async Task<List<EmailRegistrationRequestLifeCycle>> GetLifeCycles(EmailRegistrationRequest request)
        {
            var lifeCycles = await repository.GetLifeCycles();
            return lifeCycles.Where(l => l.RequestId == request.Id).ToList();
        }
    }
}
