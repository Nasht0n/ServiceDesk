using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.BranchModel
{
    public class BranchViewModel
    {
        [Required]
        [Display(Name = "Идентификатор отрасли службы поддержки")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите наименование отрасли службы поддержки")]
        [Display(Name = "Наименование отрасли службы поддержки")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Укажите наименование области заявки")]
        [Display(Name = "Наименование области заявки")]
        public string AreaName { get; set; }
    }
}