using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.ExecutorGroup;
using WebUI.ViewModels.Service;

namespace WebUI.ViewModels.ServicesExecutorGroups
{
    public class ServicesExecutorGroupsViewModel
    {
        [Display(Name = "Идентификатор вида заявки")]
        public int ServiceId { get; set; }
        [Display(Name = "Идентификатор группы исполнителей")]
        public int ExecutorGroupId { get; set; }
        [Display(Name = "Вид заявки")]
        public ServiceViewModel ServiceModel { get; set; }
        [Display(Name = "Группа исполнителей")]
        public ExecutorGroupViewModel ExecutorGroupModel { get; set; }
    }
}