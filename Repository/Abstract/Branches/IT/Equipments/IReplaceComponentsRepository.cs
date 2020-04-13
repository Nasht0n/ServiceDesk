using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments
{
    public interface IReplaceComponentsRepository
    {
        Task<ReplaceComponents> Add(ReplaceComponents components);
        Task<ReplaceComponents> Update(ReplaceComponents components);
        Task Delete(ReplaceComponents components);
        Task<List<ReplaceComponents>> GetComponents();
    }
}
