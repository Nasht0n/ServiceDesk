using System;
using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Employee;

namespace WebUI.ViewModels.LifeCycles.IT
{
    public abstract class LifeCycleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор записи жизненного цикла заявки")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите дату и время создания записи")]
        [Display(Name = "Дата и время создания записи жизенного цикла заявки")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Укажите текст сообщения")]
        [Display(Name = "Текст сообщения жизненного цикла заявки")]
        public string Message { get; set; }
        [Required]
        [Display(Name = "Идентификатор сотрудника")]
        public int EmployeeId { get; set; }
        [Display(Name = "Сотрудник, создавший запись жизненного цикла заявки")]
        public EmployeeViewModel Employee { get; set; }
    }
}