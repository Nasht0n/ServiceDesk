using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Requests.IT.Networks;

namespace WebUI.ViewModels.LifeCycles.IT.Networks
{
    public class NetworkConnectionRequestLifeCycleViewModel:LifeCycleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Required]
        public NetworkConnectionRequestViewModel RequestModel { get; set; }
    }
}