using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.Subdivision
{
    public class SubdivisionViewModel
    {
        [Required]
        [Display(Name = "Идентификатор подразделения")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите полное наименование подразделения")]
        [Display(Name = "Полное наименование подразделения")]
        [DataType(DataType.Text)]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Введите сокращенное наименование подразделения")]
        [Display(Name = "Сокращенное наименование подразделения")]
        [DataType(DataType.Text)]
        public string Shortname { get; set; }
    }
}