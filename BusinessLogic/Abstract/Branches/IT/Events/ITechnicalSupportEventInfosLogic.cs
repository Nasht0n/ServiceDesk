using Domain.Models.Requests.Events;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Events
{
    public interface ITechnicalSupportEventInfosLogic
    {
        Task<TechnicalSupportEventInfos> Add(TechnicalSupportEventInfos equipments);
        Task DeleteEntry(TechnicalSupportEventRequest request);
    }
}
