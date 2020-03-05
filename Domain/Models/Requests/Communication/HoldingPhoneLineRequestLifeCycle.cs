using Domain.Abstract;

namespace Domain.Models.Requests.Communication
{
    public class HoldingPhoneLineRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public HoldingPhoneLineRequest Request { get; set; }
    }
}
