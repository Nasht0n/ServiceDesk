using System.Collections.Generic;
using WebUI.ViewModels.AttachmentsModel.IT.Accounts;
using WebUI.ViewModels.LifeCycles.IT.Accounts;

namespace WebUI.ViewModels.Requests.IT.Accounts
{
    public class AccountDisconnectDetailsRequestViewModel:DetailsRequestViewModel
    {
        public AccountDisconnectRequestViewModel RequestModel { get; set; }
        public List<AccountDisconnectRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<AccountDisconnectRequestLifeCycleViewModel>();
        public List<AccountDisconnectRequestAttachmentViewModel> AttachmentsListModel { get; set; } = new List<AccountDisconnectRequestAttachmentViewModel>();
    }
}