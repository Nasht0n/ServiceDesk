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
    public class EquipmentReplaceRequestLifeCycleLogic : IEquipmentReplaceRequestLifeCycleLogic
    {
        private readonly IEquipmentReplaceRequestLifeCycleRepository lifeCycleRepository;

        public EquipmentReplaceRequestLifeCycleLogic(IEquipmentReplaceRequestLifeCycleRepository lifeCycleRepository)
        {
            this.lifeCycleRepository = lifeCycleRepository;
        }

        public async Task<EquipmentReplaceRequestLifeCycle> Add(EquipmentReplaceRequestLifeCycle lifeCycle)
        {
            return await lifeCycleRepository.Add(lifeCycle);
        }

        public async Task<List<EquipmentReplaceRequestLifeCycle>> GetLifeCycles(int requestId)
        {
            var lifeCycles = await lifeCycleRepository.GetLifeCycles();
            return lifeCycles.Where(l => l.RequestId == requestId).ToList();
        }
    }
}
