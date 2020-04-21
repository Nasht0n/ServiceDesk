using Domain.Models.Requests.Communication;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Communications.Requests
{
    public interface IPhoneRepairRequestLogic
    {
        Task<PhoneRepairRequest> Save(PhoneRepairRequest request);
        Task Delete(PhoneRepairRequest request);
        Task<PhoneRepairRequest> GetRequestById(int id);
    }
}
