using BusinessLogic.Abstract.Branches.IT.Communications.Requests;
using Domain.Models.Requests.Communication;
using Repository.Abstract.Branches.IT.Communication.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Communications.Requests
{
    public class HoldingPhoneLineRequestLogic : IHoldingPhoneLineRequestLogic
    {
        private readonly IHoldingPhoneLineRequestRepository repository;

        public HoldingPhoneLineRequestLogic(IHoldingPhoneLineRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(HoldingPhoneLineRequest request)
        {
            await repository.Delete(request);
        }

        public async Task<HoldingPhoneLineRequest> GetRequest(int id)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<HoldingPhoneLineRequest> Save(HoldingPhoneLineRequest request)
        {
            HoldingPhoneLineRequest result;
            if (request.Id == 0) result = await repository.Add(request);
            else result = await repository.Update(request);
            return result;
        }
    }
}
