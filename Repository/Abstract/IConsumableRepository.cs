using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IConsumableRepository
    {
        Task<Consumable> Add(Consumable consumable);
        Task<Consumable> Update(Consumable consumable);
        Task Delete(Consumable consumable);
        Task<List<Consumable>> GetConsumables();
    }
}
