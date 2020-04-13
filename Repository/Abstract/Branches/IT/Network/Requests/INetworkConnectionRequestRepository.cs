using Domain.Models.Requests.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Network.Requests
{
    public interface INetworkConnectionRequestRepository
    {
        Task<NetworkConnectionRequest> Add(NetworkConnectionRequest request);
        Task<NetworkConnectionRequest> Update(NetworkConnectionRequest request);
        Task Delete(NetworkConnectionRequest request);
        Task<List<NetworkConnectionRequest>> GetRequests();
    }
}
