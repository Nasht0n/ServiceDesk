using BusinessLogic.Abstract.Branches.IT.Events.Requests;
using Domain.Models.Requests.Events;
using Repository.Abstract.Branches.IT.Events.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Events.Requests
{
    public class TechnicalSupportEventRequestLogic : ITechnicalSupportEventRequestLogic
    {
        private readonly ITechnicalSupportEventRequestRepository repository;

        public TechnicalSupportEventRequestLogic(ITechnicalSupportEventRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(TechnicalSupportEventRequest request)
        {
            await repository.Delete(request);
        }

        public async Task<TechnicalSupportEventRequest> GetRequest(int id)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<TechnicalSupportEventRequest> Save(TechnicalSupportEventRequest request)
        {
            TechnicalSupportEventRequest result;
            if (request.Id == 0) result = await repository.Add(request);
            else result = await repository.Update(request);
            return result;
        }
    }
}
