using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.ConsumableTypeModel;
using WebUI.ViewModels.UnitModel;

namespace WebUI.ViewModels.ConsumableModel
{
    public class ConsumableViewModel
    {
        [Required]
        [Display(Name = "Идентификатор расходного материала")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите наименование расходного материала")]
        [Display(Name = "Наименование расходного материала")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Инвентарный номер")]
        public string InventoryNumber { get; set; }
        [Required]
        [Display(Name ="Идентификатор типа расходного материала")]
        public int TypeId { get; set; }
        public ConsumableTypeViewModel ConsumableTypeModel { get; set; }
        [Required]
        [Display(Name="Идентификатор еденицы измерения")]
        public int UnitId { get; set; }
        public UnitViewModel UnitModel { get; set; }
    }
}