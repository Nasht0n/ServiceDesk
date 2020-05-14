using Domain.Models.Requests.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Events
{
    public interface ITechnicalSupportEventInfoRepository
    {
        Task<TechnicalSupportEventInfos> Add(TechnicalSupportEventInfos equipments);
        Task<TechnicalSupportEventInfos> Update(TechnicalSupportEventInfos equipments);
        Task Delete(TechnicalSupportEventInfos equipments);
        Task<List<TechnicalSupportEventInfos>> GetEquipments();
    }
}
