using BusinessLogic.Abstract.Branches.IT.Networks.LifeCycles;
using Domain.Models.Requests.Network;
using Repository.Abstract.Branches.IT.Network.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Networks.LifeCycles
{
    public class NetworkConnectionRequestLifeCycleLogic : INetworkConnectionRequestLifeCycleLogic
    {
        private readonly INetworkConnectionRequestLifeCycleRepository repository;

        public NetworkConnectionRequestLifeCycleLogic(INetworkConnectionRequestLifeCycleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<NetworkConnectionRequestLifeCycle> Add(NetworkConnectionRequestLifeCycle lifeCycle)
        {
            return await repository.Add(lifeCycle);
        }

        public async Task<List<NetworkConnectionRequestLifeCycle>> GetLifeCycles(NetworkConnectionRequest request)
        {
            var lifeCycles = await repository.GetRequests();
            return lifeCycles.Where(lc => lc.RequestId == request.Id).ToList();
        }
    }
}
