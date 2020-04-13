using Domain.Models.Requests.Equipment;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments
{
    public interface IReplaceComponentsLogic
    {
        Task<ReplaceComponents> Add(ReplaceComponents component);
        Task DeleteEntry(ComponentReplaceRequest request);
    }
}
