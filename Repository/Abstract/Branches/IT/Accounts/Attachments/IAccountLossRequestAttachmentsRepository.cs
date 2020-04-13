using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Attachments
{
    public interface IAccountLossRequestAttachmentsRepository
    {
        Task<AccountLossRequestAttachment> Add(AccountLossRequestAttachment attachment);
        Task Delete(AccountLossRequestAttachment attachment);
        Task<List<AccountLossRequestAttachment>> GetAttachments();
    }
}
