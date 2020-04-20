using BusinessLogic.Abstract.Branches.IT.Accounts.Attachments;
using Domain.Models.ManyToMany;
using Domain.Models.Requests.Accounts;
using Repository.Abstract.Branches.IT.Accounts.Attachments;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Accounts.Attachments
{
    public class AccountDisconnectRequestAttachmentLogic : IAccountDisconnectRequestAttachmentLogic
    {
        private readonly IAccountDisconnectRequestAttachmentsRepository repository;

        public AccountDisconnectRequestAttachmentLogic(IAccountDisconnectRequestAttachmentsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<AccountDisconnectRequestAttachment> Add(AccountDisconnectRequestAttachment attachment)
        {
            return await repository.Add(attachment);
        }

        public async Task Delete(AccountDisconnectRequestAttachment attachment)
        {
            await repository.Delete(attachment);
        }

        public async Task<List<AccountDisconnectRequestAttachment>> GetAttachments(AccountDisconnectRequest request)
        {
            var attachments = await repository.GetAttachments();
            return attachments.Where(a => a.RequestId == request.Id).ToList();
        }
    }
}
