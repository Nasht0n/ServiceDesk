using WebUI.ViewModels.ConsumableModel;

namespace WebUI.ViewModels.Consumption.IT.Equipments
{
    public class EquipmentRefillRequestConsumptionViewModel
    {
        public int Id { get; set; }
        public EquipmentRefillRequestConsumptionViewModel RequestModel { get; set; }
        public ConsumableViewModel ConsumableModel { get; set; }
        public int Count { get; set; }
        public string Unit { get; set; }
    }
}