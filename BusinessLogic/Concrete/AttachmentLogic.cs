using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class AttachmentLogic : IAttachmentLogic
    {
        private readonly IAttachmentRepository attachmentRepository;

        public AttachmentLogic(IAttachmentRepository attachmentRepository)
        {
            this.attachmentRepository = attachmentRepository;
        }

        public async Task Delete(Attachment attachment)
        {
            await attachmentRepository.Delete(attachment);
        }

        public async Task<Attachment> GetAttachment(int id)
        {
            var attachments = await attachmentRepository.GetAttachments();
            return attachments.SingleOrDefault(a => a.Id == id);
        }

        public async Task<Attachment> GetAttachment(string path)
        {
            var attachments = await attachmentRepository.GetAttachments();
            return attachments.SingleOrDefault(a => a.Path == path);
        }

        public async Task<List<Attachment>> GetAttachments()
        {
            var attachments = await attachmentRepository.GetAttachments();
            return attachments.OrderBy(a => a.Id).ToList();
        }

        public async Task<Attachment> Save(Attachment attachment)
        {
            Attachment result;
            if (attachment.Id == 0) result = await attachmentRepository.Add(attachment);
            else result = await attachmentRepository.Update(attachment);
            return result;
        }
    }
}
