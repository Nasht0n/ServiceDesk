using BusinessLogic.Abstract.Branches.IT.Emails.Requests;
using Domain.Models.Requests.Email;
using Repository.Abstract.Branches.IT.Email.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Emails.Requests
{
    public class EmailSizeIncreaseRequestLogic : IEmailSizeIncreaseRequestLogic
    {
        private readonly IEmailSizeIncreaseRequestRepository repository;

        public EmailSizeIncreaseRequestLogic(IEmailSizeIncreaseRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(EmailSizeIncreaseRequest request)
        {
            await repository.Delete(request);
        }

        public async Task<EmailSizeIncreaseRequest> GetRequestById(int id)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<EmailSizeIncreaseRequest> Save(EmailSizeIncreaseRequest request)
        {
            EmailSizeIncreaseRequest result;
            if (request.Id == 0) result = await repository.Add(request);
            else result = await repository.Update(request);
            return result;
        }
    }
}
