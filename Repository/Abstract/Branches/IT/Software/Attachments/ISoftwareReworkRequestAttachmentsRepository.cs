using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Software.Attachments
{
    public interface ISoftwareReworkRequestAttachmentsRepository
    {
        Task<SoftwareReworkRequestAttachment> Add(SoftwareReworkRequestAttachment attachment);
        Task Delete(SoftwareReworkRequestAttachment attachment);
        Task<List<SoftwareReworkRequestAttachment>> GetAttachments();
    }
}
