using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class StatusLogic : IStatusLogic
    {
        private readonly IStatusRepository repository;

        public StatusLogic(IStatusRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Status> GetStatus(int id)
        {
            var statuses = await repository.GetStatuses();
            return statuses.SingleOrDefault(s => s.Id == id);
        }

        public async Task<List<Status>> GetStatuses(bool descending = true)
        {
            var statuses = await repository.GetStatuses();
            if (descending) return statuses.OrderByDescending(s => s.Id).ToList();
            else return statuses.OrderBy(s => s.Id).ToList();
        }
    }
}
