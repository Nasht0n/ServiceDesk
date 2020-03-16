using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Campus;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class EquipmentInstallationRequestViewModel : RequestViewModel
    {
        [Required(ErrorMessage = "Укажите место установки оборудования")]
        [Display(Name = "Номер кабинета/аудитории")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Идентификатор учебного корпуса")]
        public int CampusId { get; set; }
        [Display(Name = "Учебный компус")]
        public CampusViewModel CampusModel { get; set; }
        [Display(Name = "Перечень устанавливаемого оборудования")]
        public List<InstallationEquipmentViewModel> Installations { get; set; } = new List<InstallationEquipmentViewModel>();
    }
}