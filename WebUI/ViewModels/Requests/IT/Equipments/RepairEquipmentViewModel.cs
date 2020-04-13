using WebUI.ViewModels.ConsumableModel;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class RepairEquipmentViewModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int ConsumableId { get; set; }
        public ConsumableViewModel ConsumableModel { get; set; }
        public int RequestId { get; set; }
        public EquipmentRepairRequestViewModel RequestModel { get; set; }
    }
}