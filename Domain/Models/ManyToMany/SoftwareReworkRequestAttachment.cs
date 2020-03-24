using Domain.Models.Requests.Software;

namespace Domain.Models.ManyToMany
{
    public class SoftwareReworkRequestAttachment
    {
        public int RequestId { get; set; }
        public int AttachmentId { get; set; }

        public virtual SoftwareReworkRequest Request { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
