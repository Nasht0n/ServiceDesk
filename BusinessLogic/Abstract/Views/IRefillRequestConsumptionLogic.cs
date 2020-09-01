using Domain.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IRefillRequestConsumptionLogic
    {
        Task<List<RefillRequestConsumption>> GetConsumptions(bool descending = true);
    }
}
