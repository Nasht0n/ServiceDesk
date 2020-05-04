using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IConsumableLogic
    {
        Task<Consumable> GetConsumable(int id);
        Task<List<Consumable>> GetConsumables(bool descendings = false);
    }
}
