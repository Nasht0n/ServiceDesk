using Domain.Models.ManyToMany;
using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Softwares.Attachments
{
    public interface ISoftwareDevelopmentRequestAttachmentLogic
    {
        Task<SoftwareDevelopmentRequestAttachment> Add(SoftwareDevelopmentRequestAttachment attachment);
        Task Delete(SoftwareDevelopmentRequestAttachment attachment);
        Task<List<SoftwareDevelopmentRequestAttachment>> GetAttachments(SoftwareDevelopmentRequest request);
    }
}
