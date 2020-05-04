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

        public async Task<List<Priority>> GetPriorities(bool descendings = false)
        {
            var priorities = await priorityRepository.GetPriorities();
            if(descendings) return priorities.OrderByDescending(p => p.Fullname).ToList();
            else return priorities.OrderBy(p => p.Fullname).ToList();
        }

        public async Task<Priority> GetPriority(int id)
        {
            var priorities = await priorityRepository.GetPriorities();
            return priorities.SingleOrDefault(p => p.Id == id);
        }
    }
}
