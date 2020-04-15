using BusinessLogic.Abstract.Branches.IT.Equipments.Requests;
using Domain.Models;
using Domain.Models.Requests.Equipment;
using Repository.Concrete.Branches.IT.Equipments.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments.Requests
{
    public class EquipmentRefillRequestLogic : IEquipmentRefillRequestLogic
    {
        private readonly EquipmentRefillRequestRepository requestRepository;

        public EquipmentRefillRequestLogic(EquipmentRefillRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        public async Task Delete(EquipmentRefillRequest request)
        {
            await requestRepository.Delete(request);
        }

        public async Task<EquipmentRefillRequest> GetRequestById(int id)
        {
            var requests = await requestRepository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<List<EquipmentRefillRequest>> GetRequests(Subdivision subdivision)
        {
            var requests = await requestRepository.GetRequests();
            return requests.Where(r => r.SubdivisionId == subdivision.Id).OrderBy(r => r.Id).ToList();
        }

        public async Task<EquipmentRefillRequest> Save(EquipmentRefillRequest request)
        {
            EquipmentRefillRequest result;
            if (request.Id == 0) result = await requestRepository.Add(request);
            else result = await requestRepository.Update(request);
            return result;
        }
    }
}
