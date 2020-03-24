using Domain.Models.Requests.Software;

namespace Domain.Models.ManyToMany
{
    public class SoftwareDevelopmentRequestAttachment
    {
        public int RequestId { get; set; }
        public int AttachmentId { get; set; }

        public virtual SoftwareDevelopmentRequest Request { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
