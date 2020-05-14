using System.Collections.Generic;
using System.Web.Mvc;

namespace WebUI.ViewModels.Requests.IT.Events
{
    public class TechnicalSupportEventRequestViewModel:RequestViewModel
    {
        public List<TechnicalSupportEventEquipmentViewModel> EquipmentModels { get; set; } = new List<TechnicalSupportEventEquipmentViewModel>();
        public List<TechnicalSupportEventInfoViewModel> InfoModels { get; set; } = new List<TechnicalSupportEventInfoViewModel>();

        public SelectList Priorities { get; set; }
        public SelectList Times { get; set; }
        public SelectList Campuses { get; set; }
    }
}