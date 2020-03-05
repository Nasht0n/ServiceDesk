using Domain.Abstract;

namespace Domain.Models.Requests.Accounts
{
    public class AccountCancellationRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public AccountCancellationRequest Request { get; set; }
    }
}
