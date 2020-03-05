using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Models.Requests.Equipment
{
    public class EquipmentRepairRequest:Request
    {
        public string Location { get; set; }
        public string InventoryNumber { get; set; }
        
        public int CampusId { get; set; }
        public Campus Campus { get; set; }

        public IList<RepairEquipments> RepairEquipments { get; set; }
    }
}
