using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.ViewModels.Equipment
{
    public class EquipmentsListViewModel
    {
        public List<EquipmentViewModel> Equipments { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }

        public int? SelectedEquipmentType { get; set; }
        public SelectList EquipmentTypes { get; set; }
    }
}