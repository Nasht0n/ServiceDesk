using Domain.Abstract;

namespace Domain.Models.Requests.Communication
{
    public class PhoneNumberAllocationRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public PhoneNumberAllocationRequest Request { get; set; }
    }
}
