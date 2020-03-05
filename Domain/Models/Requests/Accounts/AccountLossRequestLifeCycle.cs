using Domain.Abstract;

namespace Domain.Models.Requests.Accounts
{
    public class AccountLossRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public AccountLossRequest Request { get; set; }
    }
}
