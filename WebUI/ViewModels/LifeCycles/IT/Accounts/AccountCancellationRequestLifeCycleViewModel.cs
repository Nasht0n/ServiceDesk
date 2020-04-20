using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Requests.IT.Accounts;

namespace WebUI.ViewModels.LifeCycles.IT.Accounts
{
    public class AccountCancellationRequestLifeCycleViewModel : LifeCycleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Required]
        public AccountCancellationRequestViewModel RequestModel { get; set; }
    }
}