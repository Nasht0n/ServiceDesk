using System.Collections.Generic;
using WebUI.ViewModels.LifeCycles.IT.Events;

namespace WebUI.ViewModels.Requests.IT.Events
{
    public class VideoCommunicationDetailsRequestViewModel:DetailsRequestViewModel
    {
        public VideoCommunicationRequestViewModel RequestModel { get; set; }
        public List<VideoCommunicationRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<VideoCommunicationRequestLifeCycleViewModel>();
    }
}