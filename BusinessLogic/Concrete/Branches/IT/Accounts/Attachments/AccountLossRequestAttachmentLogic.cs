using BusinessLogic.Abstract.Branches.IT.Accounts.Attachments;
using Domain.Models.ManyToMany;
using Domain.Models.Requests.Accounts;
using Repository.Abstract.Branches.IT.Accounts.Attachments;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Accounts.Attachments
{
    public class AccountLossRequestAttachmentLogic : IAccountLossRequestAttachmentLogic
    {
        private readonly IAccountLossRequestAttachmentsRepository repository;

        public AccountLossRequestAttachmentLogic(IAccountLossRequestAttachmentsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AccountLossRequestAttachment> Add(AccountLossRequestAttachment attachment)
        {
            return await repository.Add(attachment);
        }

        public async Task Delete(AccountLossRequestAttachment attachment)
        {
            await repository.Delete(attachment);
        }

        public async Task<List<AccountLossRequestAttachment>> GetAttachments(AccountLossRequest request)
        {
            var attachments = await repository.GetAttachments();
            return attachments.Where(a => a.RequestId == request.Id).ToList();
        }
    }
}
