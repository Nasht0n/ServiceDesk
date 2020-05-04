using BusinessLogic.Abstract.Branches.IT.Communications.Requests;
using Domain.Models.Requests.Communication;
using Repository.Abstract.Branches.IT.Communication.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Communications.Requests
{
    public class PhoneLineRepairRequestLogic : IPhoneLineRepairRequestLogic
    {
        private readonly IPhoneLineRepairRequestRepository repository;

        public PhoneLineRepairRequestLogic(IPhoneLineRepairRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(PhoneLineRepairRequest request)
        {
            await repository.Delete(request);
        }

        public async Task<PhoneLineRepairRequest> GetRequest(int id)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<PhoneLineRepairRequest> Save(PhoneLineRepairRequest request)
        {
            PhoneLineRepairRequest result;
            if (request.Id == 0) result = await repository.Add(request);
            else result = await repository.Update(request);
            return result;
        }
    }
}
