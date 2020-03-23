using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.Component
{
    public class ComponentViewModel
    {
        [Required]
        [Display(Name = "Идентификатор компонента")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Наименование компонента")]
        public string Name { get; set; }
    }
}