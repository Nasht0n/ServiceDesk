using BusinessLogic.Abstract.Branches.IT.Equipments.Requests;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments.Requests
{
    public class ComponentReplaceRequestLogic : IComponentReplaceRequestLogic
    {
        private readonly IComponentReplaceRequestRepository requestRepository;

        public ComponentReplaceRequestLogic(IComponentReplaceRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        public async Task Delete(ComponentReplaceRequest request)
        {
            await requestRepository.Delete(request);
        }

        public async Task<ComponentReplaceRequest> GetRequestById(int id)
        {
            var requests = await requestRepository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<ComponentReplaceRequest> Save(ComponentReplaceRequest request)
        {
            ComponentReplaceRequest result;
            if (request.Id == 0)
            {
                result = await requestRepository.Add(request);
            }
            else
            {
                result = await requestRepository.Update(request);
            }
            return result;
        }
    }
}
