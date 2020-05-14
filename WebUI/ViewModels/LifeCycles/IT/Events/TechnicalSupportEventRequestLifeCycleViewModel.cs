using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Requests.IT.Events;

namespace WebUI.ViewModels.LifeCycles.IT.Events
{
    public class TechnicalSupportEventRequestLifeCycleViewModel : LifeCycleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Required]
        public TechnicalSupportEventRequestViewModel RequestModel { get; set; }
    }
}