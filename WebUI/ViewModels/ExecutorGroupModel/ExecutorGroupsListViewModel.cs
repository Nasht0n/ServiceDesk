using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.ExecutorGroupModel
{
    public class ExecutorGroupsListViewModel
    {
        public List<ExecutorGroupViewModel> ExecutorGroups { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
    }
}