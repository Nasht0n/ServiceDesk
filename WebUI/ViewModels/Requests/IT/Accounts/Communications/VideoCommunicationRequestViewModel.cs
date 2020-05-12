using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.CampusModel;

namespace WebUI.ViewModels.Requests.IT.Communications
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
        [Display(Name = "Дата проведения")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}",ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } 

        public SelectList Priorities { get; set; }
        public SelectList Campuses { get; set; }
    }
}