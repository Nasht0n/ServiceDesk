using Domain.Models.Requests.Communication;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Communications.Requests
{
    public interface IPhoneLineRepairRequestLogic
    {
        Task<PhoneLineRepairRequest> Save(PhoneLineRepairRequest request);
        Task Delete(PhoneLineRepairRequest request);
        Task<PhoneLineRepairRequest> GetRequestById(int id);
    }
}
