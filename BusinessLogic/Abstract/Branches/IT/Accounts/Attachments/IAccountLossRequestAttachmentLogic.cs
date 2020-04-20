using Domain.Models.ManyToMany;
using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Accounts.Attachments
{
    public interface IAccountLossRequestAttachmentLogic
    {
        Task<AccountLossRequestAttachment> Add(AccountLossRequestAttachment attachment);
        Task Delete(AccountLossRequestAttachment attachment);
        Task<List<AccountLossRequestAttachment>> GetAttachments(AccountLossRequest request);
    }
}
