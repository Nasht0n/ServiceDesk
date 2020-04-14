using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.CampusModel;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class ComponentReplaceRequestViewModel:RequestViewModel
    {
        [Required]
        [Display(Name = "Идентификатор учебного корпуса")]
        public int CampusId { get; set; }
        [Display(Name = "Учебный корпус")]
        public CampusViewModel CampusModel { get; set; }
        [Required]
        [Display(Name = "Аудитория/Кабинет")]
        public string Location { get; set; }
        [Display(Name = "Перечень заменяемых компонентов")]
        public List<ReplaceComponentViewModel> Replaces { get; set; } = new List<ReplaceComponentViewModel>();

        public SelectList Priorities { get; set; }
        public SelectList Campuses { get; set; }
        public SelectList Components { get; set; }
    }
}