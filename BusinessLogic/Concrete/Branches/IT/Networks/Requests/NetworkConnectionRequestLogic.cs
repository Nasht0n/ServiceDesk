using BusinessLogic.Abstract.Branches.IT.Networks.Requests;
using Domain.Models.Requests.Network;
using Repository.Abstract.Branches.IT.Network.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Networks.Requests
{
    public class NetworkConnectionRequestLogic : INetworkConnectionRequestLogic
    {
        private readonly INetworkConnectionRequestRepository repository;

        public NetworkConnectionRequestLogic(INetworkConnectionRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(NetworkConnectionRequest request)
        {
            await repository.Delete(request);
        }

        public async Task<NetworkConnectionRequest> GetRequestById(int id)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<NetworkConnectionRequest> Save(NetworkConnectionRequest request)
        {
            NetworkConnectionRequest result;
            if (request.Id == 0) result = await repository.Add(request);
            else result = await repository.Update(request);
            return result;
        }
    }
}
