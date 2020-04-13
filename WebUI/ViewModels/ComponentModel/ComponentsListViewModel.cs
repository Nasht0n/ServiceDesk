using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.ComponentModel
{
    public class ComponentsListViewModel
    {
        public List<ComponentViewModel> Components { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
    }
}