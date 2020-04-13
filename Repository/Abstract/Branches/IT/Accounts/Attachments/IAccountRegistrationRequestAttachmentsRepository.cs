using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Attachments
{
    public interface IAccountRegistrationRequestAttachmentsRepository
    {
        Task<AccountRegistrationRequestAttachment> Add(AccountRegistrationRequestAttachment attachment);
        Task Delete(AccountRegistrationRequestAttachment attachment);
        Task<List<AccountRegistrationRequestAttachment>> GetAttachments();
    }
}
