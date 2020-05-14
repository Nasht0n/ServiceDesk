using System.Collections.Generic;
using WebUI.ViewModels.LifeCycles.IT.Events;

namespace WebUI.ViewModels.Requests.IT.Events
{
    public class TechnicalSupportEventDetailsRequestViewModel : DetailsRequestViewModel
    {
        public TechnicalSupportEventRequestViewModel RequestModel { get; set; }
        public List<TechnicalSupportEventRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<TechnicalSupportEventRequestLifeCycleViewModel>();
    }
}