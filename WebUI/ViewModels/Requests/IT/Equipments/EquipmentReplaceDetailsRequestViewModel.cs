using System.Collections.Generic;
using WebUI.ViewModels.LifeCycles.IT.Equipments;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class EquipmentReplaceDetailsRequestViewModel : DetailsRequestViewModel
    {
        public EquipmentReplaceRequestViewModel RequestModel { get; set; }
        public List<EquipmentReplaceRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<EquipmentReplaceRequestLifeCycleViewModel>();
    }
}