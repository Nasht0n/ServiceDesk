using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Requests.IT.Communications;

namespace WebUI.ViewModels.LifeCycles.IT.Communications
{
    public class PhoneNumberAllocationRequestLifeCycleViewModel : LifeCycleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Required]
        public PhoneNumberAllocationRequestViewModel RequestModel { get; set; }
    }
}