using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.ConsumableModel;
using WebUI.ViewModels.Requests.IT.Equipments;

namespace WebUI.ViewModels.Consumption.IT.Equipments
{
    public class EquipmentRepairRequestConsumptionViewModel
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public EquipmentRepairRequestViewModel RequestModel { get; set; }
        public int ConsumableId { get; set; }
        public ConsumableViewModel ConsumableModel { get; set; }
        [Display(Name = "Количество")]
        [Range(0, 10000)]
        public int Count { get; set; }
    }
}