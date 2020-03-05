using Domain.Abstract;

namespace Domain.Models.Requests.Communication
{
    public class PhoneRepairRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public PhoneRepairRequest Request { get; set; }
    }
}
