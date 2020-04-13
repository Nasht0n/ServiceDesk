using Domain.Models.Requests.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments.Requests
{
    public interface IEquipmentReplaceRequestLogic
    {
        Task<EquipmentReplaceRequest> Save(EquipmentReplaceRequest request);
        Task Delete(EquipmentReplaceRequest request);
        Task<EquipmentReplaceRequest> GetRequestById(int id);

    }
}
