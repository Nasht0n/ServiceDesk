using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.Consumable
{
    public class ConsumableViewModel
    {
        [Required]
        [Display(Name = "Идентификатор расходного материала")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите наименование расходного материала")]
        [Display(Name = "Наименование расходного материала")]
        public string Name { get; set; }
    }
}