using Domain.Models.Requests.Accounts;

namespace Domain.Models.ManyToMany
{
    public class AccountCancellationRequestAttachment
    {
        public int RequestId { get; set; }
        public int AttachmentId { get; set; }

        public virtual AccountCancellationRequest Request { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
