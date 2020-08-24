using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.Consumption.IT.Equipments;
using WebUI.ViewModels.LifeCycles.IT.Equipments;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class EquipmentRepairDetailsRequestViewModel:DetailsRequestViewModel
    {
        public EquipmentRepairRequestViewModel RequestModel { get; set; }
        public List<EquipmentRepairRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<EquipmentRepairRequestLifeCycleViewModel>();
        public List<EquipmentRepairRequestConsumptionViewModel> ConsumptionsListModel { get; set; } = new List<EquipmentRepairRequestConsumptionViewModel>();

        public EquipmentRepairRequestConsumptionViewModel ConsumptionModel { get; set; }

        [Display(Name = "Тип расходного материала")]
        public int? SelectedConsumableType { get; set; }
        public SelectList ConsumableTypes { get; set; }

        [Display(Name = "Расходный материал")]
        public int? SelectedConsumable { get; set; }
        public SelectList Consumables { get; set; }
    }
}