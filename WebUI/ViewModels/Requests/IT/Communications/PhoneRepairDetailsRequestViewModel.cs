using System.Collections.Generic;
using WebUI.ViewModels.LifeCycles.IT.Communications;

namespace WebUI.ViewModels.Requests.IT.Communications
{
    public class PhoneRepairDetailsRequestViewModel:DetailsRequestViewModel
    {
        public PhoneRepairRequestViewModel RequestModel { get; set; }
        public List<PhoneRepairRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<PhoneRepairRequestLifeCycleViewModel>();
    }
}