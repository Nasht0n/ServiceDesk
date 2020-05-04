using Domain.Models.Requests.Network;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Networks.Requests
{
    public interface INetworkConnectionRequestLogic
    {
        Task<NetworkConnectionRequest> Save(NetworkConnectionRequest request);
        Task Delete(NetworkConnectionRequest request);
        Task<NetworkConnectionRequest> GetRequest(int id);
    }
}
