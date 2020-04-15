using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class RefuelingLimitsLogic : IRefuelingLimitsLogic
    {
        private readonly IRefuelingLimitRepository limitRepository;

        public RefuelingLimitsLogic(IRefuelingLimitRepository limitRepository)
        {
            this.limitRepository = limitRepository;
        }

        public async Task<RefuelingLimits> GetLimit(Subdivision subdivision)
        {
            var limits = await limitRepository.GetLimits();
            return limits.FirstOrDefault(l => l.SubdivisionId == subdivision.Id);
        }

        public async Task<RefuelingLimits> Save(RefuelingLimits limits)
        {
            RefuelingLimits result;
            if (limits.Id == 0) result = await limitRepository.Add(limits);
            else result = await limitRepository.Update(limits);
            return result;
        }
    }
}
