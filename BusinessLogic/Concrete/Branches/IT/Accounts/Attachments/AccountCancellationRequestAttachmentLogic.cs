using BusinessLogic.Abstract.Branches.IT.Accounts.Attachments;
using Domain.Models.ManyToMany;
using Domain.Models.Requests.Accounts;
using Repository.Abstract.Branches.IT.Accounts.Attachments;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Accounts.Attachments
{
    public class AccountCancellationRequestAttachmentLogic : IAccountCancellationRequestAttachmentLogic
    {
        private readonly IAccountCancellationRequestAttachmentsRepository repository;

        public AccountCancellationRequestAttachmentLogic(IAccountCancellationRequestAttachmentsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AccountCancellationRequestAttachment> Add(AccountCancellationRequestAttachment attachment)
        {
            return await repository.Add(attachment);
        }

        public async Task Delete(AccountCancellationRequestAttachment attachment)
        {
            await repository.Delete(attachment);
        }

        public async Task<List<AccountCancellationRequestAttachment>> GetAttachments(AccountCancellationRequest request)
        {
            var attachments = await repository.GetAttachments();
            return attachments.Where(a => a.RequestId == request.Id).ToList();
        }
    }
}
