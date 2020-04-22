using System.Collections.Generic;
using WebUI.ViewModels.LifeCycles.IT.Communications;

namespace WebUI.ViewModels.Requests.IT.Communications
{
    public class VideoCommunicationDetailsRequestViewModel:DetailsRequestViewModel
    {
        public VideoCommunicationRequestViewModel RequestModel { get; set; }
        public List<VideoCommunicationRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<VideoCommunicationRequestLifeCycleViewModel>();
    }
}