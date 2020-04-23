using Domain.Models.ManyToMany;
using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Softwares.Attachments
{
    public interface ISoftwareReworkRequestAttachmentLogic
    {
        Task<SoftwareReworkRequestAttachment> Add(SoftwareReworkRequestAttachment attachment);
        Task Delete(SoftwareReworkRequestAttachment attachment);
        Task<List<SoftwareReworkRequestAttachment>> GetAttachments(SoftwareReworkRequest request);
    }
}
