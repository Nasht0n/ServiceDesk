using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.EquipmentTypeModel
{
    public class EquipmentTypesListViewModel
    {
        public List<EquipmentTypeViewModel> EquipmentTypes { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
    }
}