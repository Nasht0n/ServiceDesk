using BusinessLogic.Abstract.Branches.IT.Equipments;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments
{
    public class ReplaceEquipmentsLogic : IReplaceEquipmentsLogic
    {
        private readonly IReplaceEquipmentsRepository equipmentsRepository;

        public ReplaceEquipmentsLogic(IReplaceEquipmentsRepository equipmentsRepository)
        {
            this.equipmentsRepository = equipmentsRepository;
        }

        public async Task<ReplaceEquipments> Add(ReplaceEquipments equipment)
        {
            return await equipmentsRepository.Add(equipment);
        }

        public async Task DeleteEntry(EquipmentReplaceRequest request)
        {
            var equipments = await equipmentsRepository.GetEquipments();
            foreach(var equipment in equipments.Where(e=>e.RequestId == request.Id))
            {
                await equipmentsRepository.Delete(equipment);
            }
        }
    }
}
