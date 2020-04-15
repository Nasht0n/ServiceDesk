using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IRefuelingLimitRepository
    {
        Task<RefuelingLimits> Add(RefuelingLimits limit);
        Task Delete(RefuelingLimits limit);
        Task<List<RefuelingLimits>> GetLimits();
        Task<RefuelingLimits> Update(RefuelingLimits limit);
    }
}
