using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.ConsumableTypeModel
{
    public class ConsumableTypeViewModel
    {
        [Required]
        [Display(Name = "Идентификатор расходного материала")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите наименование типа расходного материала")]
        [Display(Name = "Наименование типа расходного материала")]
        public string Name { get; set; }
    }
}