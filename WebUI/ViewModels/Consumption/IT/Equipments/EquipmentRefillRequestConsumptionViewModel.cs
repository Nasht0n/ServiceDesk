using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.ConsumableModel;
using WebUI.ViewModels.Requests.IT.Equipments;
using WebUI.ViewModels.UnitModel;

namespace WebUI.ViewModels.Consumption.IT.Equipments
{
    public class EquipmentRefillRequestConsumptionViewModel
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public EquipmentRefillRequestViewModel RequestModel { get; set; }
        public int ConsumableId { get; set; }
        public ConsumableViewModel ConsumableModel { get; set; }
        [Display(Name = "Количество")]
        [Range(0,10000)]
        public int Count { get; set; }
    }
}