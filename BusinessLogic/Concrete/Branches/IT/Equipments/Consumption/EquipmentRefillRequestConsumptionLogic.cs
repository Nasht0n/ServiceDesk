using BusinessLogic.Abstract.Branches.IT.Equipments.Consumption;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments.Consumptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments.Consumption
{
    public class EquipmentRefillRequestConsumptionLogic : IEquipmentRefillRequestConsumptionLogic
    {
        private readonly IEquipmentRefillRequestConsumptionRepository repository;

        public EquipmentRefillRequestConsumptionLogic(IEquipmentRefillRequestConsumptionRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(EquipmentRefillRequestConsumption consumption)
        {
            await repository.Delete(consumption);
        }

        public async Task<EquipmentRefillRequestConsumption> GetConsumption(int id)
        {
            var consumption = await repository.GetRequestConsumptions();
            return consumption.SingleOrDefault(r => r.Id == id);
        }

        public async Task<List<EquipmentRefillRequestConsumption>> GetConsumptions(EquipmentRefillRequest request)
        {
            var consumtions = await repository.GetRequestConsumptions();
            return consumtions.Where(c => c.RequestId == request.Id).ToList();
        }

        public async Task<EquipmentRefillRequestConsumption> Save(EquipmentRefillRequestConsumption consumption)
        {
            EquipmentRefillRequestConsumption result;
            if(consumption.Id == 0)
            {
                result = await repository.Add(consumption);
            }
            else
            {
                result = await repository.Update(consumption);
            }
            return result;
        }
    }
}
