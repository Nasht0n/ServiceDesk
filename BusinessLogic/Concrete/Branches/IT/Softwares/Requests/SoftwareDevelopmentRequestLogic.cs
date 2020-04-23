using BusinessLogic.Abstract.Branches.IT.Softwares.Requests;
using Domain.Models.Requests.Software;
using Repository.Abstract.Branches.IT.Software.Requests;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Softwares.Requests
{
    public class SoftwareDevelopmentRequestLogic : ISoftwareDevelopmentRequestLogic
    {
        private readonly ISoftwareDevelopmentRequestRepository repository;

        public SoftwareDevelopmentRequestLogic(ISoftwareDevelopmentRequestRepository repository)
        {
            this.repository = repository;
        }

        public async Task Delete(SoftwareDevelopmentRequest request)
        {
            await repository.Delete(request);
        }

        public async Task<SoftwareDevelopmentRequest> GetRequestById(int id)
        {
            var requests = await repository.GetRequests();
            return requests.SingleOrDefault(r => r.Id == id);
        }

        public async Task<SoftwareDevelopmentRequest> Save(SoftwareDevelopmentRequest request)
        {
            SoftwareDevelopmentRequest result;
            if (request.Id == 0) result = await repository.Add(request);
            else result = await repository.Update(request);
            return result;
        }
    }
}
