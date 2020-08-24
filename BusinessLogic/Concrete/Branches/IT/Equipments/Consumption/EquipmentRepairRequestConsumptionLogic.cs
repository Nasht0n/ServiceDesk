using BusinessLogic.Abstract.Branches.IT.Equipments.Consumption;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments.Consumptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments.Consumption
{
    public class EquipmentRepairRequestConsumptionLogic : IEquipmentRepairRequestConsumptionLogic
    {
        private readonly IEquipmentRepairRequestConsumptionRepository repository;

        public EquipmentRepairRequestConsumptionLogic(IEquipmentRepairRequestConsumptionRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(EquipmentRepairRequestConsumption consumption)
        {
            await repository.Delete(consumption);
        }

        public async Task<EquipmentRepairRequestConsumption> GetConsumption(int id)
        {
            var consumption = await repository.GetRequestConsumptions();
            return consumption.SingleOrDefault(r => r.Id == id);
        }

        public async Task<List<EquipmentRepairRequestConsumption>> GetConsumptions(EquipmentRepairRequest request)
        {
            var consumtions = await repository.GetRequestConsumptions();
            return consumtions.Where(c => c.RequestId == request.Id).ToList();
        }

        public async Task<EquipmentRepairRequestConsumption> Save(EquipmentRepairRequestConsumption consumption)
        {
            EquipmentRepairRequestConsumption result;
            if (consumption.Id == 0)
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
