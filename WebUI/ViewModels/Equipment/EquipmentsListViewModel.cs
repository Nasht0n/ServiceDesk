using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.Equipment
{
    public class EquipmentsListViewModel
    {
        public List<EquipmentViewModel> Equipments { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
        public int EquipmentTypeId { get; set; }
    }
}