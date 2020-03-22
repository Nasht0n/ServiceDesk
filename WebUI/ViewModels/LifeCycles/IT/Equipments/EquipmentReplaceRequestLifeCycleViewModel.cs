using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Requests.IT.Equipments;

namespace WebUI.ViewModels.LifeCycles.IT.Equipments
{
    public class EquipmentReplaceRequestLifeCycleViewModel:LifeCycleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Required]
        [Display(Name = "Заявка на замену оборудования")]
        public EquipmentReplaceRequestViewModel Request { get; set; }
    }
}