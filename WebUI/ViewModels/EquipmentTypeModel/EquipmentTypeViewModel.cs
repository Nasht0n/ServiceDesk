using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.EquipmentTypeModel
{
    public class EquipmentTypeViewModel
    {
        [Required]
        [Display(Name = "Идентификатор типа оборудования")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите наименование типа оборудования")]
        [Display(Name = "Наименование типа оборудования")]
        public string Name { get; set; }
    }
}