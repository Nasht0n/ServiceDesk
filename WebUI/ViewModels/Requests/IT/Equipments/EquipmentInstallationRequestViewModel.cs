using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Campus;
using WebUI.ViewModels.Priority;
using WebUI.ViewModels.Service;
using WebUI.ViewModels.Status;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class EquipmentInstallationRequestViewModel
    {
        [Display(Name = "Идентификатор заявки на установку оборудования")]        
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите тему заявки")]
        [Display(Name = "Тема заявки")]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Укажите обоснование заявки")]
        [Display(Name = "Обоснование заявки")]
        [DataType(DataType.MultilineText)]
        public string Justification { get; set; }
        [Required(ErrorMessage = "Укажите описание заявки")]
        [Display(Name = "Описание заявки")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Укажите место установки оборудования") ]
        [Display(Name = "Место установки оборудования")]
        public string Location { get; set; }

        public int CampusId { get; set; }
        public CampusViewModel CampusModel { get; set; }
        public int ServiceId { get; set; }
        public ServiceViewModel ServiceModel { get; set; }
        public int StatusId { get; set; }
        public StatusViewModel StatusModel { get; set; }
        public int PriorityId { get; set; }
        public PriorityViewModel PriorityModel { get; set; }
        public int ExecutorId { get; set; }

        public int ExecutorGroupId { get; set; }
    }
}