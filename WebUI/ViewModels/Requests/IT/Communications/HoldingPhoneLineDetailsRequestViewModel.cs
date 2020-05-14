using System.Collections.Generic;
using WebUI.ViewModels.LifeCycles.IT.Communications;

namespace WebUI.ViewModels.Requests.IT.Communications
{
    public class HoldingPhoneLineDetailsRequestViewModel:DetailsRequestViewModel
    {
        public HoldingPhoneLineRequestViewModel RequestModel { get; set; }
        public List<HoldingPhoneLineRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<HoldingPhoneLineRequestLifeCycleViewModel>();
    }
}