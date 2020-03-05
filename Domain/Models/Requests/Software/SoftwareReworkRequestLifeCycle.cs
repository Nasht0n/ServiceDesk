using Domain.Abstract;

namespace Domain.Models.Requests.Software
{
    public class SoftwareReworkRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public SoftwareReworkRequest Request { get; set; }
    }
}
