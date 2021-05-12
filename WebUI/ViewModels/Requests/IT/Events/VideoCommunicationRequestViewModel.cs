using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.CampusModel;

namespace WebUI.ViewModels.Requests.IT.Events
{
    public class VideoCommunicationRequestViewModel:RequestViewModel
    {
        [Required]
        [Display(Name = "Идентификатор учебного корпуса")]
        public int CampusId { get; set; }
        [Display(Name = "Учебный корпус")]
        public CampusViewModel CampusModel { get; set; }
        [Required]
        [Display(Name = "Аудитория/Кабинет")]
        public string Location { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        [Display(Name = "Начало мероприятия")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}")]
        [Display(Name = "Окончание мероприятия")]
        public DateTime EndDate { get; set; }

        public SelectList Priorities { get; set; }
        public SelectList Campuses { get; set; }
        public SelectList Times { get; set; }
    }
}