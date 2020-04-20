using System.Collections.Generic;
using WebUI.ViewModels.AttachmentsModel.IT.Accounts;
using WebUI.ViewModels.LifeCycles.IT.Accounts;

namespace WebUI.ViewModels.Requests.IT.Accounts
{
    public class AccountLossDetailsRequestViewModel:DetailsRequestViewModel
    {
        public AccountLossRequestViewModel RequestModel { get; set; }
        public List<AccountLossRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<AccountLossRequestLifeCycleViewModel>();
        public List<AccountLossRequestAttachmentViewModel> AttachmentsListModel { get; set; } = new List<AccountLossRequestAttachmentViewModel>();
    }
}