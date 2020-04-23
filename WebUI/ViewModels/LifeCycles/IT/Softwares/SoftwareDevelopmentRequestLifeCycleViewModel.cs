using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Requests.IT.Softwares;

namespace WebUI.ViewModels.LifeCycles.IT.Softwares
{
    public class SoftwareDevelopmentRequestLifeCycleViewModel:LifeCycleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Required]
        public SoftwareDevelopmentRequestViewModel RequestModel { get; set; }
    }
}