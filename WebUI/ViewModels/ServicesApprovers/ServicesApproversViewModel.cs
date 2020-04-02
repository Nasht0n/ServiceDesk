using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Employee;
using WebUI.ViewModels.Service;

namespace WebUI.ViewModels.ServicesApprovers
{
    public class ServicesApproversViewModel
    {
        [Display(Name = "Идентификатор вида работы")]
        public int ServiceId { get; set; }
        [Display(Name = "Идентификатор сотрудника")]
        public int EmployeeId { get; set; }
        [Display(Name = "Вид заявки")]
        public ServiceViewModel ServiceModel { get; set; }
        [Display(Name = "Сотрудник")]
        public EmployeeViewModel EmployeeModel { get; set; }
    }
}