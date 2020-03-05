using Domain.Abstract;

namespace Domain.Models.Requests.Software
{
    public class SoftwareDevelopmentRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public SoftwareDevelopmentRequest Request { get; set; }
    }
}
