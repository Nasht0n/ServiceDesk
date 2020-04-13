using BusinessLogic.Abstract.Branches.IT.Equipments.LifeCycles;
using Domain.Models.Requests.Equipment;
using Repository.Concrete.Branches.IT.Equipments.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments.LifeCycles
{
    public class EquipmentRefillRequestLifeCycleLogic : IEquipmentRefillRequestLifeCycleLogic
    {
        private readonly EquipmentRefillRequestLifeCycleRepository lifeCycleRepository;

        public EquipmentRefillRequestLifeCycleLogic(EquipmentRefillRequestLifeCycleRepository lifeCycleRepository)
        {
            this.lifeCycleRepository = lifeCycleRepository;
        }

        public async Task<EquipmentRefillRequestLifeCycle> Add(EquipmentRefillRequestLifeCycle lifeCycle)
        {
            return await lifeCycleRepository.Add(lifeCycle);
        }

        public async Task<List<EquipmentRefillRequestLifeCycle>> GetLifeCycles(int requestId)
        {
            var lifeCycles = await lifeCycleRepository.GetLifeCycles();
            return lifeCycles.Where(l => l.RequestId == requestId).ToList();
        }
    }
}
