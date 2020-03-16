using System.Collections.Generic;
using WebUI.ViewModels.LifeCycles.IT.Equipments;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class EquipmentInstallationDetailsRequestViewModel
    {
        public EquipmentInstallationRequestViewModel RequestModel { get; set; }
        public List<EquipmentInstallationRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<EquipmentInstallationRequestLifeCycleViewModel>();
        public string Message { get; set; }
        public bool IsApprovers { get; set; }
        public bool IsExecutor { get; set; }
        public bool IsClient { get; set; }
    }
}