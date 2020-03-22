using System.Collections.Generic;
using WebUI.ViewModels.LifeCycles.IT.Equipments;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class EquipmentRepairDetailsRequestViewModel:DetailsRequestViewModel
    {
        public EquipmentRepairRequestViewModel RequestModel { get; set; }
        public List<EquipmentRepairRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<EquipmentRepairRequestLifeCycleViewModel>();
        public List<RepairEquipmentViewModel> Repairs { get; set; } = new List<RepairEquipmentViewModel>();
    }
}