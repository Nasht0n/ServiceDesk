using BusinessLogic.Abstract.Branches.IT.Accounts.Attachments;
using Domain.Models.ManyToMany;
using Domain.Models.Requests.Accounts;
using Repository.Abstract.Branches.IT.Accounts.Attachments;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Accounts.Attachments
{
    public class AccountRegistrationRequestAttachmentLogic : IAccountRegistrationRequestAttachmentLogic
    {
        private readonly IAccountRegistrationRequestAttachmentsRepository repository;

        public AccountRegistrationRequestAttachmentLogic(IAccountRegistrationRequestAttachmentsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AccountRegistrationRequestAttachment> Add(AccountRegistrationRequestAttachment attachment)
        {
            return await repository.Add(attachment);
        }

        public async Task Delete(AccountRegistrationRequestAttachment attachment)
        {
            await repository.Delete(attachment);
        }

        public async Task<List<AccountRegistrationRequestAttachment>> GetAttachments(AccountRegistrationRequest request)
        {
            var attachments = await repository.GetAttachments();
            return attachments.Where(a => a.RequestId == request.Id).ToList();
        }
    }
}
