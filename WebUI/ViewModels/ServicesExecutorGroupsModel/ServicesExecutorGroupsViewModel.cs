using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.ExecutorGroupModel;
using WebUI.ViewModels.ServiceModel;

namespace WebUI.ViewModels.ServicesExecutorGroupsModel
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