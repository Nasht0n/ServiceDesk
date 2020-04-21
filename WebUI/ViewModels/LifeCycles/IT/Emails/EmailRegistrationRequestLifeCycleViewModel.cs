using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Requests.IT.Emails;

namespace WebUI.ViewModels.LifeCycles.IT.Emails
{
    public class EmailRegistrationRequestLifeCycleViewModel:LifeCycleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Required]
        public EmailRegistrationRequestViewModel RequestModel { get; set; }
    }
}