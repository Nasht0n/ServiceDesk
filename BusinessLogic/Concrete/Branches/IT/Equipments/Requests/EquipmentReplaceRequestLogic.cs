using BusinessLogic.Abstract.Branches.IT.Equipments.Requests;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments.Requests
{
    public class EquipmentReplaceRequestLogic : IEquipmentReplaceRequestLogic
    {
        private readonly IEquipmentReplaceRequestRepository requestRepository;

        public EquipmentReplaceRequestLogic(IEquipmentReplaceRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        public async Task Delete(EquipmentReplaceRequest request)
        {
            await requestRepository.Delete(request);
        }

        public async Task<EquipmentReplaceRequest> GetRequestById(int id)
        {
            var requests = await requestRepository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<EquipmentReplaceRequest> Save(EquipmentReplaceRequest request)
        {
            EquipmentReplaceRequest result;
            if (request.Id == 0) result = await requestRepository.Add(request);
            else result = await requestRepository.Update(request);
            return result;
        }
    }
}
