using BusinessLogic.Abstract.Branches.IT.Communications.Requests;
using Domain.Models.Requests.Communication;
using Repository.Abstract.Branches.IT.Communication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Communications.Requests
{
    public class PhoneRepairRequestLogic : IPhoneRepairRequestLogic
    {
        private readonly IPhoneRepairRequestRepository repository;

        public PhoneRepairRequestLogic(IPhoneRepairRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(PhoneRepairRequest request)
        {
            await repository.Delete(request);
        }

        public async Task<PhoneRepairRequest> GetRequestById(int id)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<PhoneRepairRequest> Save(PhoneRepairRequest request)
        {
            PhoneRepairRequest result;
            if (request.Id == 0) result = await repository.Add(request);
            else result = await repository.Update(request);
            return result;
        }
    }
}
