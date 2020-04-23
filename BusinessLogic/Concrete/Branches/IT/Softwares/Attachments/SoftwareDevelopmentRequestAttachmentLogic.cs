using BusinessLogic.Abstract.Branches.IT.Softwares.Attachments;
using Domain.Models.ManyToMany;
using Domain.Models.Requests.Software;
using Repository.Abstract.Branches.IT.Software.Attachments;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Softwares.Attachments
{
    public class SoftwareDevelopmentRequestAttachmentLogic : ISoftwareDevelopmentRequestAttachmentLogic
    {
        private readonly ISoftwareDevelopmentRequestAttachmentsRepository repository;

        public SoftwareDevelopmentRequestAttachmentLogic(ISoftwareDevelopmentRequestAttachmentsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<SoftwareDevelopmentRequestAttachment> Add(SoftwareDevelopmentRequestAttachment attachment)
        {
            return await repository.Add(attachment);
        }

        public async Task Delete(SoftwareDevelopmentRequestAttachment attachment)
        {
            await repository.Delete(attachment);
        }

        public async Task<List<SoftwareDevelopmentRequestAttachment>> GetAttachments(SoftwareDevelopmentRequest request)
        {
            var attachments = await repository.GetAttachments();
            return attachments.Where(a => a.RequestId == request.Id).ToList();
        }
    }
}
