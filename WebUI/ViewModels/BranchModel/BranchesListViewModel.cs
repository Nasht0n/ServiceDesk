using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.BranchModel
{
    public class BranchesListViewModel: DashboardConfigurationViewModel
    {
        public List<BranchViewModel> Branches { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
    }
}