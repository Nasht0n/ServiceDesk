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
    public class PhoneNumberAllocationRequestLogic : IPhoneNumberAllocationRequestLogic
    {
        private readonly IPhoneNumberAllocationRequestRepository repository;

        public PhoneNumberAllocationRequestLogic(IPhoneNumberAllocationRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(PhoneNumberAllocationRequest request)
        {
            await repository.Delete(request);
        }

        public async Task<PhoneNumberAllocationRequest> GetRequestById(int id)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<PhoneNumberAllocationRequest> Save(PhoneNumberAllocationRequest request)
        {
            PhoneNumberAllocationRequest result;
            if (request.Id == 0) result = await repository.Add(request);
            else result = await repository.Update(request);
            return result;
        }
    }
}
