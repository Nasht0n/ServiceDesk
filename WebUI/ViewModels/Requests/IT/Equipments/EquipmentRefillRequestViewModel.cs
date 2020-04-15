using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.CampusModel;
using WebUI.ViewModels.RefuelingLimitsModel;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class EquipmentRefillRequestViewModel:RequestViewModel
    {
        [Required(ErrorMessage = "Укажите место установки оборудования")]
        [Display(Name = "Место установки оборудования")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Идентификатор учебного корпуса")]
        public int CampusId { get; set; }
        [Display(Name = "Учебный компус")]
        public CampusViewModel CampusModel { get; set; }
        [Display(Name = "Перечень заправляемого оборудования")]
        public List<RefillEquipmentViewModel> Refills { get; set; } = new List<RefillEquipmentViewModel>();
        public List<RefuelingLimitViewModel> Limits { get; set; } = new List<RefuelingLimitViewModel>();
        public SelectList Priorities { get; set; }
        public SelectList Campuses { get; set; }
    }
}