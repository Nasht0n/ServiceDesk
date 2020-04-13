using Domain.Models.Requests.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Communication.Requests
{
    public interface IHoldingPhoneLineRequestRepository
    {
        Task<HoldingPhoneLineRequest> Add(HoldingPhoneLineRequest request);
        Task<HoldingPhoneLineRequest> Update(HoldingPhoneLineRequest request);
        Task Delete(HoldingPhoneLineRequest request);
        Task<List<HoldingPhoneLineRequest>> GetRequests();
    }
}
