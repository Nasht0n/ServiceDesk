using BusinessLogic.Abstract.Branches.IT.Equipments.LifeCycles;
using Domain.Models.Requests.Equipment;
using Repository.Concrete.Branches.IT.Equipments.LifeCycles;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments.LifeCycles
{
    public class EquipmentInstallationRequestLifeCycleLogic : IEquipmentInstallationRequestLifeCycleLogic
    {
        private readonly EquipmentInstallationRequestLifeCycleRepository lifeCycleRepository;

        public EquipmentInstallationRequestLifeCycleLogic(EquipmentInstallationRequestLifeCycleRepository lifeCycleRepository)
        {
            this.lifeCycleRepository = lifeCycleRepository;
        }

        public async Task<EquipmentInstallationRequestLifeCycle> Add(EquipmentInstallationRequestLifeCycle lifeCycle)
        {
            return await lifeCycleRepository.Add(lifeCycle);
        }

        public async Task<List<EquipmentInstallationRequestLifeCycle>> GetLifeCycles(EquipmentInstallationRequest request)
        {
            var lifeCycles = await lifeCycleRepository.GetLifeCycles();
            return lifeCycles.Where(l => l.RequestId == request.Id).ToList();
        }
    }
}
