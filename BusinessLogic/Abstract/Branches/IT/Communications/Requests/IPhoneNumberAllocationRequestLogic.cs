using Domain.Models.Requests.Communication;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Communications.Requests
{
    public interface IPhoneNumberAllocationRequestLogic
    {
        Task<PhoneNumberAllocationRequest> Save(PhoneNumberAllocationRequest request);
        Task Delete(PhoneNumberAllocationRequest request);
        Task<PhoneNumberAllocationRequest> GetRequestById(int id);
    }
}
