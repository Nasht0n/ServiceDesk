using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Requests.IT.Accounts;

namespace WebUI.ViewModels.LifeCycles.IT.Accounts
{
    public class AccountRegistrationRequestLifeCycleViewModel:LifeCycleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Required]
        public AccountRegistrationRequestViewModel RequestModel { get; set; }
    }
}