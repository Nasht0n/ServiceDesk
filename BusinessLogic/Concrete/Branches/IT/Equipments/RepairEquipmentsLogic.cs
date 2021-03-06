using BusinessLogic.Abstract.Branches.IT.Equipments;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments
{
    public class RepairEquipmentsLogic : IRepairEquipmentsLogic
    {
        private readonly IRepairEquipmentsRepository repairEquipmentsRepository;

        public RepairEquipmentsLogic(IRepairEquipmentsRepository repairEquipmentsRepository)
        {
            this.repairEquipmentsRepository = repairEquipmentsRepository;
        }

        public async Task<RepairEquipments> Add(RepairEquipments repair)
        {
            return await repairEquipmentsRepository.Add(repair);
        }

        public async Task DeleteEntry(EquipmentRepairRequest request)
        {
            var equipments = await repairEquipmentsRepository.GetRepairs();
            foreach (var equipment in equipments.Where(r => r.RequestId == request.Id))
            {
                await repairEquipmentsRepository.Delete(equipment);
            }
        }
    }
}
