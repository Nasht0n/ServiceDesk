using Domain.Models.ManyToMany;
using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Accounts.Attachments
{
    public interface IAccountCancellationRequestAttachmentLogic
    {
        Task<AccountCancellationRequestAttachment> Add(AccountCancellationRequestAttachment attachment);
        Task Delete(AccountCancellationRequestAttachment attachment);
        Task<List<AccountCancellationRequestAttachment>> GetAttachments(AccountCancellationRequest request);
    }
}
