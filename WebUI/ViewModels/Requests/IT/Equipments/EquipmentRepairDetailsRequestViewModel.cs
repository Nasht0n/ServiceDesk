using Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.LifeCycles.IT.Equipments;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class EquipmentRepairDetailsRequestViewModel:DetailsRequestViewModel
    {
        public EquipmentRepairRequestViewModel RequestModel { get; set; }
        public List<EquipmentRepairRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<EquipmentRepairRequestLifeCycleViewModel>();
        [Display(Name = "Информация о ремонте")]
        public List<RepairEquipmentViewModel> Repairs { get; set; } = new List<RepairEquipmentViewModel>();

        public RepairEquipmentViewModel RepairModel { get; set; } = new RepairEquipmentViewModel();
        public int SelectedConsumable { get; set; }
        public SelectList Consumables { get; set; }
    }
}