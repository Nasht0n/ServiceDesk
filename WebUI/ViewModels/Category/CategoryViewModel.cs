using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Branch;

namespace WebUI.ViewModels.Category
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
        public int BranchId { get; set; }
        [Display(Name = "Отрасль службы поддержки")]
        public BranchViewModel BranchModel { get; set; }
    }
}