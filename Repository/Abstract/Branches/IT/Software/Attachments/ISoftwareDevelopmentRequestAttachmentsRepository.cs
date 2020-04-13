using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Software.Attachments
{
    public interface ISoftwareDevelopmentRequestAttachmentsRepository
    {
        Task<SoftwareDevelopmentRequestAttachment> Add(SoftwareDevelopmentRequestAttachment attachment);
        Task Delete(SoftwareDevelopmentRequestAttachment attachment);
        Task<List<SoftwareDevelopmentRequestAttachment>> GetAttachments();
    }
}
