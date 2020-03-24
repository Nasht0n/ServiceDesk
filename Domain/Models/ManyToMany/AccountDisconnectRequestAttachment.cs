using Domain.Models.Requests.Accounts;

namespace Domain.Models.ManyToMany
{
    public class AccountDisconnectRequestAttachment
    {
        public int RequestId { get; set; }
        public int AttachmentId { get; set; }

        public virtual AccountDisconnectRequest Request { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
