using Domain.Models.Requests.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Network
{
    public interface IConnectionEquipmentsRepository
    { 
        Task<ConnectionEquipments> Add(ConnectionEquipments equipments);
        Task<ConnectionEquipments> Update(ConnectionEquipments equipments);
        Task Delete(ConnectionEquipments equipments);
        Task<List<ConnectionEquipments>> GetEquipments();
    }
}
