using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.Requests.View
{
    public class RequestListViewModel
    {
        public List<RequestViewModel> Requests { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int? CurrentService { get; set; }
        public int? CurrentStatus { get; set; }
    }
}