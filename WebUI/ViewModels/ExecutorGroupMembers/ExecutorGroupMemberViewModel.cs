using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Employee;
using WebUI.ViewModels.ExecutorGroup;

namespace WebUI.ViewModels.ExecutorGroupMembers
{
    public class ExecutorGroupMemberViewModel
    {
        [Required]
        [Display(Name = "Идентификатор группы исполниетелей")]
        public int ExecutorGroupId { get; set; }
        [Required]
        [Display(Name = "Идентификатор сотрудника")]
        public int EmployeeId { get; set; }
        [Display(Name = "Группа исполнителей")]
        public ExecutorGroupViewModel ExecutorGroupModel { get; set; }
        [Display(Name = "Сотрудник")]
        public EmployeeViewModel EmployeeModel { get; set; }
    }
}