using BusinessLogic.Abstract.Views;
using Domain.Views;
using Repository.Abstract.Views;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Views
{
    public class RepairRequestConsumptionLogic : IRepairRequestConsumptionLogic
    {
        private readonly IRepairRequestConsumptionRepository repository;

        public RepairRequestConsumptionLogic(IRepairRequestConsumptionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<RepairRequestConsumption>> GetConsumptions(bool descending = true)
        {
            var consumptions = await repository.GetConsumptions();
            if (descending) return consumptions.OrderByDescending(j => j.Id).ToList();
            else return consumptions.OrderBy(j => j.Id).ToList();
        }
    }
}
