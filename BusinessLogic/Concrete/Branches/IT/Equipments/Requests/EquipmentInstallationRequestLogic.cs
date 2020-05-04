using BusinessLogic.Abstract.Branches.IT.Equipments.Requests;
using Domain.Models.Requests.Equipment;
using Repository.Concrete.Branches.IT.Equipments.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments.Requests
{
    public class EquipmentInstallationRequestLogic : IEquipmentInstallationRequestLogic
    {
        private readonly EquipmentInstallationRequestRepository requestRepository;

        public EquipmentInstallationRequestLogic(EquipmentInstallationRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        public async Task Delete(EquipmentInstallationRequest request)
        {
            await requestRepository.Delete(request);
        }

        public async Task<EquipmentInstallationRequest> GetRequest(int id)
        {
            var requests = await requestRepository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<EquipmentInstallationRequest> Save(EquipmentInstallationRequest request)
        {
            EquipmentInstallationRequest result;
            if (request.Id == 0) result = await requestRepository.Add(request);
            else result = await requestRepository.Update(request);
            return result;
        }
    }
}
