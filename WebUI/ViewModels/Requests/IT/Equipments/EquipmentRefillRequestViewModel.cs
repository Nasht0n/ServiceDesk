using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Campus;

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
    }
}