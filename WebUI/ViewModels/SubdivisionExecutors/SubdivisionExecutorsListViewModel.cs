using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.Subdivision;

namespace WebUI.ViewModels.SubdivisionExecutors
{
    public class SubdivisionExecutorsListViewModel
    {
        [Display(Name = "Список исполнителей")]
        public List<SubdivisionExecutorViewModel> ExecutorsModel { get; set; }

        [Display(Name = "Идентификатор выбранного подразделения")]
        public int? SelectedSubdivision { get; set; }
        [Display(Name = "Список подразделений")]
        public SelectList Subdivisions { get; set; }

        [Display(Name = "Подразделение")]
        public SubdivisionViewModel SubdivisionModel { get; set; }
        [Display(Name = "Идентификатор выбранного исполнителя")]
        public int? SelectedExecutor { get; set; }
        [Display(Name = "Список исполнителей")]
        public SelectList Executors { get; set; }
    }
}