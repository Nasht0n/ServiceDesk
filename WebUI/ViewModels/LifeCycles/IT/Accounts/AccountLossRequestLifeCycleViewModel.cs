using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Requests.IT.Accounts;

namespace WebUI.ViewModels.LifeCycles.IT.Accounts
{
    public class AccountLossRequestLifeCycleViewModel:LifeCycleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Required]
        public AccountLossRequestViewModel RequestModel { get; set; }
    }
}