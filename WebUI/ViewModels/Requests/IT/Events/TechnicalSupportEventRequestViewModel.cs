using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebUI.ViewModels.Requests.IT.Events
{
    public class TechnicalSupportEventRequestViewModel:RequestViewModel
    {
        [Display(Name = "Требуемое оборудование")]
        public List<TechnicalSupportEventEquipmentViewModel> EquipmentModels { get; set; } = new List<TechnicalSupportEventEquipmentViewModel>();
        [Display(Name = "Информация о мероприятии")]
        public List<TechnicalSupportEventInfoViewModel> InfoModels { get; set; } = new List<TechnicalSupportEventInfoViewModel>();

        public SelectList Priorities { get; set; }
        public SelectList Times { get; set; }
        public SelectList Campuses { get; set; }
    }
}