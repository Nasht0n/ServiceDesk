using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.EmployeeModel;
using WebUI.ViewModels.SubdivisionModel;

namespace WebUI.ViewModels.SubdivisionExecutorsModel
{
    public class SubdivisionExecutorViewModel
    {
        [Required]
        [Display(Name = "Идентификатор подразделения")]
        public int SubdivisionId { get; set; }
        [Required]
        [Display(Name = "Идентификатор исполнителя")]
        public int ExecutorId { get; set; }
        [Display(Name = "Подразделение")]
        public SubdivisionViewModel SubdivisionModel { get; set; }
        [Display(Name = "Исполнитель")]
        public EmployeeViewModel ExecutorModel { get; set; }
    }
}