using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.CampusModel;

namespace WebUI.ViewModels.Requests.IT.Networks
{
    public class NetworkConnectionRequestViewModel:RequestViewModel
    {
        [Required]
        [Display(Name = "Идентификатор учебного корпуса")]
        public int CampusId { get; set; }
        [Display(Name = "Учебный корпус")]
        public CampusViewModel CampusModel { get; set; }
        [Required]
        [Display(Name = "Аудитория/Кабинет")]
        public string Location { get; set; }
        [Display(Name = "Список подключаемого оборудования")]
        public List<ConnectionEquipmentViewModel> Connections { get; set; } = new List<ConnectionEquipmentViewModel>();

        public SelectList Priorities { get; set; }
        public SelectList Campuses { get; set; }
        public SelectList EquipmentTypes { get; set; }
    }
}