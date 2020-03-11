using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.Branch
{
    public class BranchViewModel
    {
        [Required]
        [Display(Name = "Идентификатор отрасли службы поддержки")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите наименование отрасли службы поддержки")]
        [Display(Name = "Наименование отрасли службы поддержки")]
        public string Name { get; set; }
    }
}