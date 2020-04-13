using Domain.Models.Requests.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.Requests
{
    public interface IComponentReplaceRequestLogic
    {
        Task<ComponentReplaceRequest> Save(ComponentReplaceRequest request);
        Task Delete(ComponentReplaceRequest request);
        Task<ComponentReplaceRequest> GetRequestById(int id);
    }
}
