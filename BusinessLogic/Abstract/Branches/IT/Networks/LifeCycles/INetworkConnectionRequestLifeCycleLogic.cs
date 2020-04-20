using Domain.Models.Requests.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Networks.LifeCycles
{
    public interface INetworkConnectionRequestLifeCycleLogic
    {
        Task<NetworkConnectionRequestLifeCycle> Add(NetworkConnectionRequestLifeCycle lifeCycle);
        Task<List<NetworkConnectionRequestLifeCycle>> GetLifeCycles(NetworkConnectionRequest request);
    }
}
