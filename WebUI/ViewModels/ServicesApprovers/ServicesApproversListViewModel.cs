using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.Service;

namespace WebUI.ViewModels.ServicesApprovers
{
    public class ServicesApproversListViewModel
    {
        [Display(Name = "Список лиц согласования заявки")]
        public List<ServicesApproversViewModel> ApproversListModel { get; set; }
        [Display(Name = "Текущий вид заявки")]
        public ServiceViewModel ServiceModel { get; set; }
        [Display(Name = "Выбранное подразделение")]
        public int? SelectedSubdivision { get; set; }
        [Display(Name = "Список видов заявки")]
        public SelectList Subdivisions { get; set; }
        [Display(Name = "Выбранный сотрудник")]
        public int? SelectedEmployee { get; set; }
        [Display(Name = "Список сотрудников")]
        public SelectList Employees { get; set; }
    }
}