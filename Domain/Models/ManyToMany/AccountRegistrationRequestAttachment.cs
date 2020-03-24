using Domain.Models.Requests.Accounts;

namespace Domain.Models.ManyToMany
{
    public class AccountRegistrationRequestAttachment
    {
        public int RequestId { get; set; }
        public int AttachmentId { get; set; }

        public virtual AccountRegistrationRequest Request { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
