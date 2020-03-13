using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.ExecutorGroup
{
    public class ExecutorGroupsListViewModel
    {
        public List<ExecutorGroupViewModel> ExecutorGroups { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
    }
}