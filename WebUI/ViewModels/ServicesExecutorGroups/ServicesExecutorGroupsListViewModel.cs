using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.Service;

namespace WebUI.ViewModels.ServicesExecutorGroups
{
    public class ServicesExecutorGroupsListViewModel
    {
        [Display(Name = "Список групп исполнителей, выполняющих данный вид заявки")]
        public List<ServicesExecutorGroupsViewModel> ExecutorGroupsListModel { get; set; }
        [Display(Name = "Текущий вид заявки")]
        public ServiceViewModel ServiceModel { get; set; }
        [Display(Name = "Выбранная группа исполнителей")]
        public int? SelectedExecutorGroup { get; set; }
        [Display(Name = "Список групп исполнителей")]
        public SelectList ExecutorGroups { get; set; }
    }
}