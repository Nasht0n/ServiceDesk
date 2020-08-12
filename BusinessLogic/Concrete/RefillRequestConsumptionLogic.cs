using BusinessLogic.Abstract;
using Domain.Views;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class RefillRequestConsumptionLogic : IRefillRequestConsumptionLogic
    {
        private readonly IRefillRequestConsumptionRepository repository;

        public RefillRequestConsumptionLogic(IRefillRequestConsumptionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<RefillRequestConsumption>> GetConsumptions(bool descending = true)
        {
            var consumptions = await repository.GetConsumptions();
            if (descending) return consumptions.OrderByDescending(j => j.Id).ToList();
            else return consumptions.OrderBy(j => j.Id).ToList();
        }
    }
}
