using BusinessLogic.Abstract.Branches.IT.Events;
using Domain.Models.Requests.Events;
using Repository.Abstract.Branches.IT.Events;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Events
{
    public class TechnicalSupportEventEquipmentsLogic : ITechnicalSupportEventEquipmentsLogic
    {
        private readonly ITechnicalSupportEventEquipmentRepository repository;

        public TechnicalSupportEventEquipmentsLogic(ITechnicalSupportEventEquipmentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<TechnicalSupportEventEquipments> Add(TechnicalSupportEventEquipments equipments)
        {
            return await repository.Add(equipments);
        }

        public async Task DeleteEntry(TechnicalSupportEventRequest request)
        {
            var equipments = await repository.GetEquipments();
            foreach (var equipment in equipments.Where(e => e.RequestId == request.Id))
            {
                await repository.Delete(equipment);
            }
        }
    }
}
