using System.Collections.Generic;
using WebUI.ViewModels.LifeCycles.IT.Equipments;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class EquipmentInstallationDetailsRequestViewModel:DetailsRequestViewModel
    {
        public EquipmentInstallationRequestViewModel RequestModel { get; set; }
        public List<EquipmentInstallationRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<EquipmentInstallationRequestLifeCycleViewModel>();
    }
}