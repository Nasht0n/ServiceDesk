using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments
{
    public interface IInstallationEquipmentsRepository
    {
        Task<InstallationEquipments> Add(InstallationEquipments installation);
        Task<InstallationEquipments> Update(InstallationEquipments installation);
        Task Delete(InstallationEquipments installation);
        Task<List<InstallationEquipments>> GetInstallations();
    }
}
