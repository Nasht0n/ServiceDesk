using Domain.Abstract;

namespace Domain.Models.Requests.Email
{
    public class EmailSizeIncreaseRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public EmailSizeIncreaseRequest Request { get; set; }
    }
}
