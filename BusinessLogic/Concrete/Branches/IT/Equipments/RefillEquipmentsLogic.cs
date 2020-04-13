using BusinessLogic.Abstract.Branches.IT.Equipments;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments
{
    public class RefillEquipmentsLogic : IRefillEquipmentsLogic
    {
        private readonly IRefillEquipmentsRepository equipmentsRepository;

        public RefillEquipmentsLogic(IRefillEquipmentsRepository equipmentsRepository)
        {
            this.equipmentsRepository = equipmentsRepository;
        }

        public async Task<RefillEquipments> Add(RefillEquipments equipment)
        {
            return await equipmentsRepository.Add(equipment);
        }

        public async Task DeleteEntry(EquipmentRefillRequest request)
        {
            var equipments = await equipmentsRepository.GetRefills();
            foreach(var equipment in equipments.Where(r=>r.RequestId == request.Id))
            {
                await equipmentsRepository.Delete(equipment);
            }
        }
    }
}
