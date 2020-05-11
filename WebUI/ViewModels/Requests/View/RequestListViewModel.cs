using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.Requests.View
{
    public class RequestListViewModel: DashboardConfigurationViewModel
    {
        public List<RequestViewModel> RequestsModel { get; set; }
        //public PagingInfo PagingInfo { get; set; }
        public int? CurrentService { get; set; }
        public int? CurrentStatus { get; set; }
    }
}