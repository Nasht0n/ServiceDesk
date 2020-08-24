using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.Consumption.IT.Equipments;
using WebUI.ViewModels.LifeCycles.IT.Equipments;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class EquipmentRefillDetailsRequestViewModel : DetailsRequestViewModel
    {
        public EquipmentRefillRequestViewModel RequestModel { get; set; }        
        public List<EquipmentRefillRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<EquipmentRefillRequestLifeCycleViewModel>();
        public List<EquipmentRefillRequestConsumptionViewModel> ConsumptionsListModel { get; set; } = new List<EquipmentRefillRequestConsumptionViewModel>();

        public EquipmentRefillRequestConsumptionViewModel ConsumptionModel { get; set; }

        [Display(Name = "Тип расходного материала")]        
        public int? SelectedConsumableType { get; set; }
        public SelectList ConsumableTypes { get; set; }

        [Display(Name = "Расходный материал")]
        public int? SelectedConsumable { get; set; }
        public SelectList Consumables { get; set; }


    }
}