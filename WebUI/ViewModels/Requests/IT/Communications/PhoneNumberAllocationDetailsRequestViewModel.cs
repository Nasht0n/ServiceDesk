using System.Collections.Generic;
using WebUI.ViewModels.LifeCycles.IT.Communications;

namespace WebUI.ViewModels.Requests.IT.Communications
{
    public class PhoneNumberAllocationDetailsRequestViewModel:DetailsRequestViewModel
    {
        public PhoneNumberAllocationRequestViewModel RequestModel { get; set; }
        public List<PhoneNumberAllocationRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<PhoneNumberAllocationRequestLifeCycleViewModel>();
    }
}