using Domain.Abstract;

namespace Domain.Models.Requests.Communication
{
    public class PhoneLineRepairRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public PhoneLineRepairRequest Request { get; set; }
    }
}
