using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.Requests
{
    public interface IPhoneNumberAllocationRequestRepository
    {
        Task<PhoneNumberAllocationRequest> Add(PhoneNumberAllocationRequest request);
        Task<PhoneNumberAllocationRequest> Update(PhoneNumberAllocationRequest request);
        Task Delete(PhoneNumberAllocationRequest request);
        Task<List<PhoneNumberAllocationRequest>> GetRequests();
    }
}
