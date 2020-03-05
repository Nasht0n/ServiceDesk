using Domain.Abstract;

namespace Domain.Models.Requests.Accounts
{
    public class AccountRegistrationRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public AccountRegistrationRequest Request { get; set; }
    }
}
