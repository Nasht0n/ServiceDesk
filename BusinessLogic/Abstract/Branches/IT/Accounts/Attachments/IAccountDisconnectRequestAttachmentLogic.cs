using Domain.Models.ManyToMany;
using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Accounts.Attachments
{
    public interface IAccountDisconnectRequestAttachmentLogic
    {
        Task<AccountDisconnectRequestAttachment> Add(AccountDisconnectRequestAttachment attachment);
        Task Delete(AccountDisconnectRequestAttachment attachment);
        Task<List<AccountDisconnectRequestAttachment>> GetAttachments(AccountDisconnectRequest request);
    }
}
