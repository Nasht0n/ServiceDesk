using Domain.Abstract;

namespace Domain.Models.Requests.Email
{
    public class EmailRegistrationRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public EmailRegistrationRequest Request { get; set; }
    }
}
