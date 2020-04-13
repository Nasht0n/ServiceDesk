using BusinessLogic.Abstract.Branches.IT.Equipments;
using Domain.Models.Requests.Equipment;
using Repository.Concrete.Branches.IT.Equipments;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments
{
    public class InstallationEquipmentsLogic : IInstallationEquipmentsLogic
    {
        private readonly InstallationEquipmentsRepository equipmentsRepository;

        public InstallationEquipmentsLogic(InstallationEquipmentsRepository equipmentsRepository)
        {
            this.equipmentsRepository = equipmentsRepository;
        }

        public async Task<InstallationEquipments> Add(InstallationEquipments equipments)
        {
            return await equipmentsRepository.Add(equipments);
        }

        public async Task DeleteEntry(EquipmentInstallationRequest request)
        {
            var equipments = await equipmentsRepository.GetEquipments();
            foreach (var equipment in equipments.Where(e => e.RequestId == request.Id))
            {
                await equipmentsRepository.Delete(equipment);
            }
        }
    }
}
