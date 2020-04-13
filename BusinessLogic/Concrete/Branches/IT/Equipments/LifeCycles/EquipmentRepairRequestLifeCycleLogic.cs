using BusinessLogic.Abstract.Branches.IT.Equipments.LifeCycles;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments.LifeCycles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments.LifeCycles
{
    public class EquipmentRepairRequestLifeCycleLogic : IEquipmentRepairRequestLifeCycleLogic
    {
        private readonly IEquipmentRepairRequestLifeCycleRepository lifeCycleRepository;

        public EquipmentRepairRequestLifeCycleLogic(IEquipmentRepairRequestLifeCycleRepository lifeCycleRepository)
        {
            this.lifeCycleRepository = lifeCycleRepository;
        }

        public async Task<EquipmentRepairRequestLifeCycle> Add(EquipmentRepairRequestLifeCycle lifeCycle)
        {
            return await lifeCycleRepository.Add(lifeCycle);
        }

        public async Task<List<EquipmentRepairRequestLifeCycle>> GetLifeCycles(int requestId)
        {
            var lifeCycles = await lifeCycleRepository.GetLifeCycles();
            return lifeCycles.Where(r => r.RequestId == requestId).ToList();
        }
    }
}
