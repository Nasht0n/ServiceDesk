using System;
using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.CampusModel;

namespace WebUI.ViewModels.Requests.IT.Events
{
    public class TechnicalSupportEventInfoViewModel
    {
        [Display(Name = "Идентификатор информации о дате и месте проведения мероприятия")]
        public int Id { get; set; }
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Display(Name = "Идентификатор учебного корпуса")]
        public int CampusId { get; set; }
        [Display(Name = "Место проведения мероприятия")]
        public string Location { get; set; }
        [Display(Name = "Дата проведения мероприятия")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }
        [Display(Name = "Время начала мероприятия")]
        public string StartTime { get; set; }
        [Display(Name = "Время окончания мероприятия")]
        public string EndTime { get; set; }
        [Display(Name = "Заявка на техническое обеспечение мероприятия")]
        public TechnicalSupportEventRequestViewModel RequestModel { get; set; }
        [Display(Name = "Учебный корпус")]
        public CampusViewModel CampusModel { get; set; }
    }
}