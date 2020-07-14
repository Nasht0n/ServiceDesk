using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IConsumableTypeLogic
    {
        Task<ConsumableType> GetConsumableType(int id);
        Task<List<ConsumableType>> GetConsumableTypes(bool descendings = false);
    }
}
