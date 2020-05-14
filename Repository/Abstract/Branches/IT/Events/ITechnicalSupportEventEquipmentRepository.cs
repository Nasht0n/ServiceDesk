using Domain.Models.Requests.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Events
{
    public interface ITechnicalSupportEventEquipmentRepository
    {
        Task<TechnicalSupportEventEquipments> Add(TechnicalSupportEventEquipments equipments);
        Task<TechnicalSupportEventEquipments> Update(TechnicalSupportEventEquipments equipments);
        Task Delete(TechnicalSupportEventEquipments equipments);
        Task<List<TechnicalSupportEventEquipments>> GetEquipments();
    }
}
