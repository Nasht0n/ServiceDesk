using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.ConsumableModel;
using WebUI.ViewModels.UnitModel;

namespace WebUI.ViewModels.Consumption.IT.Equipments
{
    public class EquipmentRefillRequestConsumptionViewModel
    {
        public int Id { get; set; }
        public EquipmentRefillRequestConsumptionViewModel RequestModel { get; set; }
        public ConsumableViewModel ConsumableModel { get; set; }
        public UnitViewModel UnitModel { get; set; }
        [Display(Name = "Количество")]
        [Range(0,10000)]
        public int Count { get; set; }
    }
}