using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.Requests
{
    public interface IPhoneRepairRequestRepository
    {
        Task<PhoneRepairRequest> Add(PhoneRepairRequest request);
        Task<PhoneRepairRequest> Update(PhoneRepairRequest request);
        Task Delete(PhoneRepairRequest request);
        Task<List<PhoneRepairRequest>> GetRequests();
    }
}
