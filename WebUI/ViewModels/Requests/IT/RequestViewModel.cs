using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Employee;
using WebUI.ViewModels.ExecutorGroup;
using WebUI.ViewModels.Priority;
using WebUI.ViewModels.Service;
using WebUI.ViewModels.Status;
using WebUI.ViewModels.Subdivision;

namespace WebUI.ViewModels.Requests.IT
{
    public abstract class RequestViewModel
    {
        [Required]
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
        [Required]
        [Display(Name = "Идентификатор вида работы")]
        public int ServiceId { get; set; }
        [Display(Name = "Вид работы")]
        public ServiceViewModel ServiceModel { get; set; }
        [Required]
        [Display(Name = "Идентификатор статуса работы")]
        public int StatusId { get; set; }
        [Display(Name = "Статус заявки")]
        public StatusViewModel StatusModel { get; set; }
        [Required]
        [Display(Name = "Идентификатор приоритета заявки")]
        public int PriorityId { get; set; }
        [Display(Name = "Приоритет заявки")]
        public PriorityViewModel PriorityModel { get; set; }
        [Required]
        [Display(Name = "Идентификатор клиента заявки")]
        public int ClientId { get; set; }
        [Display(Name = "Клиент заявки")]
        public EmployeeViewModel Client { get; set; }
        [Required]
        [Display(Name = "Идентификатор исполнителя заявки")]
        public int? ExecutorId { get; set; }
        [Display(Name = "Исполнитель заявки")]
        public EmployeeViewModel Executor { get; set; }
        [Required]
        [Display(Name = "Идентификатор группы исполнителей")]
        public int ExecutorGroupId { get; set; }
        [Display(Name = "Группа исполнителей")]
        public ExecutorGroupViewModel ExecutorGroupModel { get; set; }
        [Required]
        [Display(Name = "Идентификатор подразделения")]
        public int SubdivisionId { get; set; }
        [Display(Name = "Подразделение")]
        public SubdivisionViewModel SubdivisionModel { get; set; }
    }
}