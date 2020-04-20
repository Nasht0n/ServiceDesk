using Domain.Models.ManyToMany;
using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Accounts.Attachments
{
    public interface IAccountRegistrationRequestAttachmentLogic
    {
        Task<AccountRegistrationRequestAttachment> Add(AccountRegistrationRequestAttachment attachment);
        Task Delete(AccountRegistrationRequestAttachment attachment);
        Task<List<AccountRegistrationRequestAttachment>> GetAttachments(AccountRegistrationRequest request);
    }
}
