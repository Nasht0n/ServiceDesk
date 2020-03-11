using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.EquipmentType
{
    public class EquipmentTypesListViewModel
    {
        public List<EquipmentTypeViewModel> EquipmentTypes { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
    }
}