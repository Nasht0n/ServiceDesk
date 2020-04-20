using System.Collections.Generic;
using WebUI.ViewModels.LifeCycles.IT.Networks;

namespace WebUI.ViewModels.Requests.IT.Networks
{
    public class NetworkConnectionDetailsRequestViewModel:DetailsRequestViewModel
    {
        public NetworkConnectionRequestViewModel RequestModel { get; set; }
        public List<NetworkConnectionRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<NetworkConnectionRequestLifeCycleViewModel>();
    }
}