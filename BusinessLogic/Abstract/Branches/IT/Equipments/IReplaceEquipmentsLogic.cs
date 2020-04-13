using Domain.Models.Requests.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments
{
    public interface IReplaceEquipmentsLogic
    {
        Task<ReplaceEquipments> Add(ReplaceEquipments equipment);
        Task DeleteEntry(EquipmentReplaceRequest request);
    }
}
