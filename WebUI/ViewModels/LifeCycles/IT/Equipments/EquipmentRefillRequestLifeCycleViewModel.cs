using WebUI.ViewModels.Requests.IT.Equipments;

namespace WebUI.ViewModels.LifeCycles.IT.Equipments
{
    public class EquipmentRefillRequestLifeCycleViewModel:LifeCycleViewModel
    {
        public int RequestId { get; set; }
        public EquipmentRefillRequestViewModel RequestModel { get; set; }
    }
}