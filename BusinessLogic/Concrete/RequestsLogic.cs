using BusinessLogic.Abstract;
using Domain.Models;
using Domain.Views;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class RequestsLogic : IRequestsLogic
    {
        private readonly IRequestRepository requestRepository;

        public RequestsLogic(IRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        public async Task<List<Requests>> GetRequests()
        {
            var requests = await requestRepository.GetRequests();
            return requests.OrderBy(r => r.Date).ToList();
        }

        public async Task<List<Requests>> GetRequests(Employee employee, bool descending = true)
        {
            List<Requests> result = new List<Requests>();
            var requests = await requestRepository.GetRequests();
            if (employee != null)
            {
                requests = requests.Where(r => r.ClientId == employee.Id || r.ExecutorId == employee.Id || r.ExecutorId == null).ToList();
            }
            result = result.Concat(requests).ToList();

            var executorGroups = employee.ExecutorGroups;
            if (executorGroups != null)
            {
                foreach (var group in executorGroups)
                {
                    var temp = requests.Where(r => r.ExecutorGroupId == group.ExecutorGroupId).ToList();
                    if (temp.Count != 0) result = result.Concat(requests).ToList();
                }
            }
            return result;
        }

        public async Task<List<Requests>> GetRequestsByDescending()
        {
            var requests = await requestRepository.GetRequests();
            return requests.OrderByDescending(r => r.Date).ToList();
        }
    }
}
