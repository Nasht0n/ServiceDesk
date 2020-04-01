using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.ExecutorGroup;
using WebUI.ViewModels.Subdivision;

namespace WebUI.ViewModels.ExecutorGroupMembers
{
    public class ExecutorGroupMembersListViewModel
    {
        [Display(Name = "Список исполнителей группы исполнителя")]
        public List<ExecutorGroupMemberViewModel> ExecutorGroupMemberModel { get; set; }
        [Display(Name = "Группа исполнителей")]
        public ExecutorGroupViewModel ExecutorGroupModel { get; set; }

        [Display(Name = "Идентификатор выбранного подразделения")]
        public int? SelectedSubdivision { get; set; }
        [Display(Name = "Список подразделений")]
        public SelectList Subdivisions { get; set; }        

        [Display(Name = "Идентификатор выбранного исполнителя")]
        public int? SelectedExecutor { get; set; }
        [Display(Name = "Список исполнителей")]
        public SelectList Executors { get; set; }
    }
}