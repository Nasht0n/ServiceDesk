using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<Consumable> GetConsumableById(int id)
        {
            var consumables = await consumableRepository.GetConsumables();
            return consumables.FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<Consumable>> GetConsumables()
        {
            var consumables = await consumableRepository.GetConsumables();
            return consumables.OrderBy(c => c.Name).ToList();
        }
    }
}
