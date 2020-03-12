using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.Service
{
    public class ServicesListViewModel
    {
        public List<ServiceViewModel> Services { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
        public int BranchId { get; set; }
        public int CategoryId { get; set; }
    }
}