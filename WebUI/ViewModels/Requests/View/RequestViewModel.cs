using System;
using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.EmployeeModel;
using WebUI.ViewModels.ExecutorGroupModel;
using WebUI.ViewModels.PriorityModel;
using WebUI.ViewModels.ServiceModel;
using WebUI.ViewModels.StatusModel;
using WebUI.ViewModels.SubdivisionModel;

namespace WebUI.ViewModels.Requests.View
{
    public class RequestViewModel
    {
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Required(ErrorMessage = "Введите заголовок заявки")]
        [Display(Name = "Заголовок заявки")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Введите обоснование заявки")]
        [Display(Name = "Обоснование заявки")]
        public string Justification { get; set; }
        [Required(ErrorMessage = "Введите описание заявки")]
        [Display(Name = "Описание заявки")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Идентификатор вида работы")]
        public int ServiceId { get; set; }
        [Display(Name = "Вид работы")]
        public ServiceViewModel ServiceModel { get; set; }
        [Required]
        [Display(Name = "Идентификатор статуса заявки")]
        public int StatusId { get; set; }
        [Display(Name = "Статус заявки")]
        public StatusViewModel StatusModel { get; set; }
        [Required]
        [Display(Name = "Идентификатор приоритета заявки")]
        public int PriorityId { get; set; }
        [Display(Name = "Приоритет заявки")]
        public PriorityViewModel PriorityModel { get; set; }
        [Required]
        [Display(Name = "Идентификатор клиента")]
        public int ClientId { get; set; }
        [Display(Name = "Клиент")]
        public EmployeeViewModel ClientModel { get; set; }
        [Required]
        [Display(Name = "Идентификатор исполнителя заявки")]
        public int ExecutorId { get; set; }
        [Display(Name = "Исполнитель")]
        public EmployeeViewModel ExecutorModel { get; set; }
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
        [Required]
        [Display(Name = "Дата регистрации заявки")]
        public DateTime Date { get; set; }
        [Display(Name = "Наименование контроллера")]
        public string Source { get; set; }
    }
}