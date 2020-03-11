using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.Branch
{
    public class BranchesListViewModel
    {
        public List<BranchViewModel> Branches { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
    }
}