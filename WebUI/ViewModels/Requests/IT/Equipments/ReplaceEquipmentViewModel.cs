using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.EquipmentType;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class ReplaceEquipmentViewModel
    {
        [Required]
        [Display(Name = "Идентификатор заменяемого оборудования")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Инвентарный номер оборудования")]
        public string InventoryNumber { get; set; }
        [Required]
        [Display(Name = "Идентификатор заявки на замену оборудования")]
        public int RequestId { get; set; }
        [Display(Name = "Заявка на замену оборудования")]
        public EquipmentReplaceRequestViewModel RequestModel { get; set; }
        [Required]
        [Display(Name = "Идентификатор типа оборудования")]
        public int EquipmentTypeId { get; set; }
        [Display(Name = "Тип оборудования")]
        public EquipmentTypeViewModel EquipmentTypeModel { get; set; }
    }
}