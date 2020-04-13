using BusinessLogic.Abstract;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Abstract;

namespace BusinessLogic.Concrete
{
    public class PriorityLogic : IPriorityLogic
    {
        private readonly IPriorityRepository priorityRepository;

        public PriorityLogic(IPriorityRepository priorityRepository)
        {
            this.priorityRepository = priorityRepository;
        }

        public async Task<List<Priority>> GetPriorities()
        {
            var priorities = await priorityRepository.GetPriorities();
            return priorities.OrderBy(p => p.Id).ToList();
        }

        public async Task<List<Priority>> GetPrioritiesByDescendings()
        {
            var priorities = await priorityRepository.GetPriorities();
            return priorities.OrderByDescending(p => p.Id).ToList();
        }

        public async Task<Priority> GetPriorityById(int id)
        {
            var priorities = await priorityRepository.GetPriorities();
            return priorities.SingleOrDefault(p => p.Id == id);
        }
    }
}
