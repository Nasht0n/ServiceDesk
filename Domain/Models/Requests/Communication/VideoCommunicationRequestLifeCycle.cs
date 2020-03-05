using Domain.Abstract;

namespace Domain.Models.Requests.Communication
{
    public class VideoCommunicationRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public VideoCommunicationRequest Request { get; set; }
    }
}
