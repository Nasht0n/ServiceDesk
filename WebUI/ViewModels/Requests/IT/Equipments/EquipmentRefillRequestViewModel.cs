using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.CampusModel;

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

        public int? SelectedPriority { get; set; }
        public SelectList Priorities { get; set; }

        public int? SelectedCampus { get; set; }
        public SelectList Campuses { get; set; }

        public int? SelectedEquipmentType { get; set; }
        public SelectList EquipmentTypes { get; set; }
        [Display(Name = "Перечень заправляемого оборудования")]
        public List<RefillEquipmentViewModel> Refills { get; set; } = new List<RefillEquipmentViewModel>();
    }
}