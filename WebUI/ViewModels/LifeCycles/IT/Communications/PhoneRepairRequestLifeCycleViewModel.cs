using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Requests.IT.Communications;

namespace WebUI.ViewModels.LifeCycles.IT.Communications
{
    public class PhoneRepairRequestLifeCycleViewModel : LifeCycleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Required]
        public PhoneRepairRequestViewModel RequestModel { get; set; }
    }
}