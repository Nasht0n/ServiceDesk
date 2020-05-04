using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class ConsumableLogic : IConsumableLogic
    {
        private readonly IConsumableRepository consumableRepository;

        public ConsumableLogic(IConsumableRepository consumableRepository)
        {
            this.consumableRepository = consumableRepository;
        }

        public async Task<Consumable> GetConsumable(int id)
        {
            var consumables = await consumableRepository.GetConsumables();
            return consumables.FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<Consumable>> GetConsumables(bool descendings = false)
        {
            var consumables = await consumableRepository.GetConsumables();
            if(descendings) return consumables.OrderByDescending(c => c.Name).ToList();
            else return consumables.OrderBy(c => c.Name).ToList();
        }
    }
}
