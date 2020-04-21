using BusinessLogic.Abstract.Branches.IT.Emails.LifeCycles;
using Domain.Models.Requests.Email;
using Repository.Abstract.Branches.IT.Email.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Emails.LifeCycles
{
    public class EmailSizeIncreaseRequestLifeCycleLogic : IEmailSizeIncreaseRequestLifeCycleLogic
    {
        private readonly IEmailSizeIncreaseRequestLifeCycleRepository repository;

        public EmailSizeIncreaseRequestLifeCycleLogic(IEmailSizeIncreaseRequestLifeCycleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<EmailSizeIncreaseRequestLifeCycle> Add(EmailSizeIncreaseRequestLifeCycle lifeCycle)
        {
            return await repository.Add(lifeCycle);
        }

        public async Task<List<EmailSizeIncreaseRequestLifeCycle>> GetLifeCycles(EmailSizeIncreaseRequest request)
        {
            var lifeCycles = await repository.GetLifeCycles();
            return lifeCycles.Where(l => l.RequestId == request.Id).ToList();
        }
    }
}
