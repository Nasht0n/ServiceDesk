using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.EquipmentType;

namespace WebUI.ViewModels.Equipment
{
    public class EquipmentViewModel
    {
        [Required]
        [Display(Name = "Идентификатор оборудования")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите наименование оборудования")]
        [Display(Name = "Наименование оборудования")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите инвентарный номер оборудования")]
        [Display(Name = "Инвентарный номер оборудования")]
        public string InventoryNumber { get; set; }

        [Display(Name = "Тип оборудования")]
        public EquipmentTypeViewModel EquipmentTypeModel { get; set; }
        public int? SelectedEquipmentType { get; set; }
        public SelectList EquipmentTypes { get; set; }
    }
}