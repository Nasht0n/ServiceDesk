using Domain.Models.Requests.Equipment;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments
{
    public interface IInstallationEquipmentsLogic
    {
        Task<InstallationEquipments> Add(InstallationEquipments equipments);
        Task DeleteEntry(EquipmentInstallationRequest request);
    }
}
