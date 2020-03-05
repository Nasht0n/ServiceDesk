using Domain.Abstract;

namespace Domain.Models.Requests.Network
{
    public class NetworkConnectionRequestLifeCycle:LifeCycle
    {
        public int RequestId { get; set; }
        public NetworkConnectionRequest Request { get; set; }
    }
}
