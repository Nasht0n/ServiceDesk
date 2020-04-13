using Domain.Models.Requests.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Network.LifeCycles
{
    public interface INetworkConnectionRequestLifeCycleRepository
    {
        Task<NetworkConnectionRequestLifeCycle> Add(NetworkConnectionRequestLifeCycle request);
        Task<NetworkConnectionRequestLifeCycle> Update(NetworkConnectionRequestLifeCycle request);
        Task Delete(NetworkConnectionRequestLifeCycle request);
        Task<List<NetworkConnectionRequestLifeCycle>> GetRequests();
    }
}
