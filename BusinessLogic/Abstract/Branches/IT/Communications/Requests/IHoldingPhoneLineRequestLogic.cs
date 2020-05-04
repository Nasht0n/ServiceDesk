using Domain.Models.Requests.Communication;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Communications.Requests
{
    public interface IHoldingPhoneLineRequestLogic
    {
        Task<HoldingPhoneLineRequest> Save(HoldingPhoneLineRequest request);
        Task Delete(HoldingPhoneLineRequest request);
        Task<HoldingPhoneLineRequest> GetRequest(int id);
    }
}
