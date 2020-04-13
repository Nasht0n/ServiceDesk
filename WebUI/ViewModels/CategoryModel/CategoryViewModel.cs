using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.BranchModel;

namespace WebUI.ViewModels.CategoryModel
{
    public class CategoryViewModel
    {
        [Required]
        [Display(Name = "Идентификатор категории заявки")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите наименование категории заявки")]
        [Display(Name = "Наименование категории заявки")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Идентификатор отрасли службы поддержки")]
        public int? SelectedBranch { get; set; }
        [Display(Name = "Отрасль заявки")]
        public BranchViewModel BranchModel { get; set; }
        [Display(Name = "Отрасль заявки")]
        public SelectList Branches { get; set; }
    }
}