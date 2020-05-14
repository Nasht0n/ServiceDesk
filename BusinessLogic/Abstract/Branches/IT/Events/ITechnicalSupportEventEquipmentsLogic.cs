using Domain.Models.Requests.Events;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Events
{
    public interface ITechnicalSupportEventEquipmentsLogic
    {
        Task<TechnicalSupportEventEquipments> Add(TechnicalSupportEventEquipments equipments);
        Task DeleteEntry(TechnicalSupportEventRequest request);
    }
}
