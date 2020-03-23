using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class RefillEquipmentViewModel
    {        
        [Required]
        [Display(Name = "Идентификатор")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Инвентарный номер")]
        public string InventoryNumber { get; set; }
        [Required]
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Display(Name = "Заявка на заправку оборудования")]
        public EquipmentRefillRequestViewModel RequestModel { get; set; }
    }
}