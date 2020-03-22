using System.Collections.Generic;
using WebUI.ViewModels.Campus;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class EquipmentRepairRequestViewModel:RequestViewModel
    {
        public int CampusId { get; set; }
        public CampusViewModel CampusModel { get; set; }
        public string InventoryNumber { get; set; }
        public string Location { get; set; }

        public List<RepairEquipmentViewModel> Repairs { get; set; } = new List<RepairEquipmentViewModel>();
    }
}