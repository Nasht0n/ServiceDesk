using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class ConsumableTypeLogic : IConsumableTypeLogic
    {
        private readonly IConsumableTypeRepository repository;

        public ConsumableTypeLogic(IConsumableTypeRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ConsumableType> GetConsumableType(int id)
        {
            var types = await repository.GetConsumableTypes();
            return types.FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<ConsumableType>> GetConsumableTypes(bool descendings = false)
        {
            var types = await repository.GetConsumableTypes();
            if (descendings) return types.OrderByDescending(c => c.Name).ToList();
            else return types.OrderBy(c => c.Name).ToList();
        }
    }
}
