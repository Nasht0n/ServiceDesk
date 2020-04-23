using BusinessLogic.Abstract.Branches.IT.Softwares.Attachments;
using Domain.Models.ManyToMany;
using Domain.Models.Requests.Software;
using Repository.Abstract.Branches.IT.Software.Attachments;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Softwares.Attachments
{
    public class SoftwareReworkRequestAttachmentLogic : ISoftwareReworkRequestAttachmentLogic
    {
        private readonly ISoftwareReworkRequestAttachmentsRepository repository;

        public SoftwareReworkRequestAttachmentLogic(ISoftwareReworkRequestAttachmentsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SoftwareReworkRequestAttachment> Add(SoftwareReworkRequestAttachment attachment)
        {
            return await repository.Add(attachment);
        }

        public async Task Delete(SoftwareReworkRequestAttachment attachment)
        {
            await repository.Delete(attachment);
        }

        public async Task<List<SoftwareReworkRequestAttachment>> GetAttachments(SoftwareReworkRequest request)
        {
            var attachments = await repository.GetAttachments();
            return attachments.Where(a => a.RequestId == request.Id).ToList();
        }
    }
}
