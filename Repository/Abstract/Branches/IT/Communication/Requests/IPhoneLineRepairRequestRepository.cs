using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.Requests
{
    public interface IPhoneLineRepairRequestRepository
    {
        Task<PhoneLineRepairRequest> Add(PhoneLineRepairRequest request);
        Task<PhoneLineRepairRequest> Update(PhoneLineRepairRequest request);
        Task Delete(PhoneLineRepairRequest request);
        Task<List<PhoneLineRepairRequest>> GetRequests();
    }
}
