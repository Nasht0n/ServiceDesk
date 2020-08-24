using WebUI.ViewModels.ConsumableModel;
using WebUI.ViewModels.EquipmentTypeModel;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class RepairEquipmentViewModel
    {
        public int Id { get; set; }
        public string InventoryNumber { get; set; }
        public int RequestId { get; set; }
        public EquipmentRepairRequestViewModel RequestModel { get; set; }

        public string Model { get; set; }
        public EquipmentTypeViewModel EquipmentTypeModel { get; set; }
    }
}