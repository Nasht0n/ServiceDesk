using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IRefuelingLimitsLogic
    {
        Task<RefuelingLimits> Save(RefuelingLimits limits);
        Task<RefuelingLimits> GetLimit(Subdivision subdivision);
        
    }
}
