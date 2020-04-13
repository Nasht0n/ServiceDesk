using Domain.Models.Requests.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract.Branches.IT.Equipments
{
    public interface IRefillEquipmentsLogic
    {
        Task<RefillEquipments> Add(RefillEquipments equipments);
        Task DeleteEntry(EquipmentRefillRequest request);
    }
}
