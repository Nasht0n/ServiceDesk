using System.Collections.Generic;
using WebUI.ViewModels.LifeCycles.IT.Equipments;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class EquipmentRefillDetailsRequestViewModel : DetailsRequestViewModel
    {
        public EquipmentRefillRequestViewModel RequestModel { get; set; }
        public List<EquipmentRefillRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<EquipmentRefillRequestLifeCycleViewModel>();
    }
}