using Domain.Abstract;

namespace Domain.Models.Requests.Accounts
{
    public class AccountDisconnectRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public AccountDisconnectRequest Request { get; set; }
    }
}
