using BusinessLogic.Abstract.Branches.IT.Softwares;
using Domain.Models.Requests.Software;
using Repository.Abstract.Branches.IT.Software;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Softwares
{
    public class InformationStatusRequestTitlesLogic : IInformationStatusRequestTitlesLogic
    {
        private readonly IInformationStatusRequestTitlesRepository repository;

        public InformationStatusRequestTitlesLogic(IInformationStatusRequestTitlesRepository repository)
        {
            this.repository = repository;
        }

        public async Task<InformationStatusRequestTitle> Add(InformationStatusRequestTitle equipments)
        {
            return await repository.Add(equipments);
        }

        public async Task DeleteEntry(InformationStatusRequest request)
        {
            var titles = await repository.GetTitles();
            foreach (var title in titles.Where(e => e.RequestId == request.Id))
            {
                await repository.Delete(title);
            }
        }
    }
}
