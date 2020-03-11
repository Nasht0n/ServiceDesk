using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.Campus
{
    public class CampusViewModel
    {
        [Required]
        [Display(Name = "Идентификатор учебного корпуса")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите наименование учебного корпуса")]
        [Display(Name = "Наименование учебного корпуса")]
        public string Name { get; set; }
    }
}