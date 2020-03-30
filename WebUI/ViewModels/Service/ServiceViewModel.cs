using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.Branch;
using WebUI.ViewModels.Category;

namespace WebUI.ViewModels.Service
{
    public class ServiceViewModel
    {
        [Display(Name = "Идентификатор типа работы")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите наименование типа работы")]
        [Display(Name = "Наименование типа работы")]
        public string Name { get; set; }
        [Display(Name = "Активный тип работы?")]
        public bool Visible { get; set; }
        [Display(Name = "Требуется согласование")]
        public bool ApprovalRequired { get; set; }
        [Required(ErrorMessage = "Введите наименование контроллера типа заявки")]
        [Display(Name = "Контроллер типа заявки")]
        public string Controller { get; set; }



        public int? SelectedCategory { get; set; }
        [Display(Name = "Категория заявки")]
        public CategoryViewModel CategoryModel { get; set; }
        public SelectList CategoryList { get; set; }
        public int? SelectedBranch { get; set; }
        [Display(Name = "Отрасль заявки")]
        public BranchViewModel BranchModel { get; set; }
        public SelectList BranchList { get; set; }
    }
}