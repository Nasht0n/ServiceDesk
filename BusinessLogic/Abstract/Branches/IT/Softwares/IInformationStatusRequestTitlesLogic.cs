using Domain.Models.Requests.Software;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Softwares
{
    public interface IInformationStatusRequestTitlesLogic
    {
        Task<InformationStatusRequestTitle> Add(InformationStatusRequestTitle equipments);
        Task DeleteEntry(InformationStatusRequest request);
    }
}
