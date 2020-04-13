using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Attachments
{
    public interface IAccountDisconnectRequestAttachmentsRepository
    {
        Task<AccountDisconnectRequestAttachment> Add(AccountDisconnectRequestAttachment attachment);
        Task Delete(AccountDisconnectRequestAttachment attachment);
        Task<List<AccountDisconnectRequestAttachment>> GetAttachments();
    }
}
