using Domain.Models.Requests.Network;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Networks
{
    public interface IConnectionEquipmentsLogic
    {
        Task<ConnectionEquipments> Add(ConnectionEquipments equipments);
        Task DeleteEntry(NetworkConnectionRequest request);
    }
}
