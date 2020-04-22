using System.Collections.Generic;
using WebUI.ViewModels.LifeCycles.IT.Communications;

namespace WebUI.ViewModels.Requests.IT.Communications
{
    public class PhoneLineRepairDetailsRequestViewModel:DetailsRequestViewModel
    {
        public PhoneLineRepairRequestViewModel RequestModel { get; set; }
        public List<PhoneLineRepairRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<PhoneLineRepairRequestLifeCycleViewModel>();
    }
}