using System.Collections.Generic;
using System.Linq;
using WebUI.ViewModels.Requests.View;
using WebUI.ViewModels.ServiceModel;

namespace WebUI.ViewModels
{
    public class DashboardViewModel
    {
        private readonly int LastRequestCount = 3;

        public List<RequestViewModel> RequestsModel { get; set; }
        public List<ServicesStats> StatsModel { get; set; }
        public List<RequestViewModel> LastRequests {
            get
            {
                return RequestsModel.Take(LastRequestCount).OrderBy(r => r.Date).ToList();
            }
        }

        public int CountCreatedRequest { get; set; }
        public int CountExecutedRequest { get; set; }
        public int CountCompletedRequest { get; set; }
        public int CountApprovalRequest { get; set; }
    }

    public class ServicesStats
    {
        public ServiceViewModel ServiceModel { get; set; }
        public int Count { get; set; }
    }
}