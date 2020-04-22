using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Requests.IT.Communications;

namespace WebUI.ViewModels.LifeCycles.IT.Communications
{
    public class PhoneLineRepairRequestLifeCycleViewModel : LifeCycleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Required]
        public PhoneLineRepairRequestViewModel RequestModel { get; set; }
    }
}