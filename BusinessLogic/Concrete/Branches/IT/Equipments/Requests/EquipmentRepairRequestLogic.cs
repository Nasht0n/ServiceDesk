using BusinessLogic.Abstract.Branches.IT.Equipments.Requests;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments.Requests
{
    public class EquipmentRepairRequestLogic : IEquipmentRepairRequestLogic
    {
        private readonly IEquipmentRepairRequestRepository requestRepository;

        public EquipmentRepairRequestLogic(IEquipmentRepairRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        public async Task Delete(EquipmentRepairRequest request)
        {
            await requestRepository.Delete(request);
        }

        public async Task<EquipmentRepairRequest> GetRequestById(int id)
        {
            var requests = await requestRepository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<List<EquipmentRepairRequest>> GetRequests()
        {
            var requests = await requestRepository.GetRequests();
            return requests.OrderBy(r => r.Id).ToList();
        }

        public async Task<List<EquipmentRepairRequest>> GetRequestsByDescending()
        {
            var requests = await requestRepository.GetRequests();
            return requests.OrderByDescending(r => r.Id).ToList();
        }

        public async Task<EquipmentRepairRequest> Save(EquipmentRepairRequest request)
        {
            EquipmentRepairRequest result;
            if (request.Id == 0) result = await requestRepository.Add(request);
            else result = await requestRepository.Update(request);
            return result;
        }
    }
}
