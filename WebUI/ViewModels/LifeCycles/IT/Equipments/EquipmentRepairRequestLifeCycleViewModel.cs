using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Requests.IT.Equipments;

namespace WebUI.ViewModels.LifeCycles.IT.Equipments
{
    public class EquipmentRepairRequestLifeCycleViewModel:LifeCycleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Required]
        [Display(Name = "Заявка на ремонт оборудования")]
        public EquipmentRepairRequestViewModel Request { get; set; }
    }
}