using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.ConsumableModel
{
    public class ConsumablesListViewModel
    {
        public List<ConsumableViewModel> Consumables { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
    }
}