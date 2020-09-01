using Domain.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Views
{
    public interface IRepairRequestConsumptionLogic
    {
        Task<List<RepairRequestConsumption>> GetConsumptions(bool descending = true);
    }
}
