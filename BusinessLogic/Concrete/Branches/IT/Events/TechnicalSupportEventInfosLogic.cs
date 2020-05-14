using BusinessLogic.Abstract.Branches.IT.Events;
using Domain.Models.Requests.Events;
using Repository.Abstract.Branches.IT.Events;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Events
{
    public class TechnicalSupportEventInfosLogic : ITechnicalSupportEventInfosLogic
    {
        private readonly ITechnicalSupportEventInfoRepository repository;

        public TechnicalSupportEventInfosLogic(ITechnicalSupportEventInfoRepository repository)
        {
            this.repository = repository;
        }

        public async Task<TechnicalSupportEventInfos> Add(TechnicalSupportEventInfos equipments)
        {
            return await repository.Add(equipments);
        }

        public async Task DeleteEntry(TechnicalSupportEventRequest request)
        {
            var list = await repository.GetEquipments();
            foreach (var info in list.Where(e => e.RequestId == request.Id))
            {
                await repository.Delete(info);
            }
        }
    }
}
