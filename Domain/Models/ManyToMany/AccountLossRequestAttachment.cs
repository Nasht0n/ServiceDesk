using Domain.Models.Requests.Accounts;

namespace Domain.Models.ManyToMany
{
    public class AccountLossRequestAttachment
    {
        public int RequestId { get; set; }
        public int AttachmentId { get; set; }

        public virtual AccountLossRequest Request { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
