using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Attachments
{
    public interface IAccountCancellationRequestAttachmentsRepository
    {
        Task<AccountCancellationRequestAttachment> Add(AccountCancellationRequestAttachment attachment);
        Task Delete(AccountCancellationRequestAttachment attachment);
        Task<List<AccountCancellationRequestAttachment>> GetAttachments();
    }
}
