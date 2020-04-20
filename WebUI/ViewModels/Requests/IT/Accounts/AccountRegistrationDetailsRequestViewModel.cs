using System.Collections.Generic;
using WebUI.ViewModels.AttachmentsModel.IT.Accounts;
using WebUI.ViewModels.LifeCycles.IT.Accounts;

namespace WebUI.ViewModels.Requests.IT.Accounts
{
    public class AccountRegistrationDetailsRequestViewModel:DetailsRequestViewModel
    {
        public AccountRegistrationRequestViewModel RequestModel { get; set; }
        public List<AccountRegistrationRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<AccountRegistrationRequestLifeCycleViewModel>();
        public List<AccountRegistrationRequestAttachmentViewModel> AttachmentsListModel { get; set; } = new List<AccountRegistrationRequestAttachmentViewModel>();
    }
}