using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Requests.IT.Equipments;

namespace WebUI.ViewModels.LifeCycles.IT.Equipments
{
    public class EquipmentRefillRequestLifeCycleViewModel:LifeCycleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Required]
        [Display(Name = "Заявка на заправку оборудования")]
        public EquipmentRefillRequestViewModel RequestModel { get; set; }
    }
}