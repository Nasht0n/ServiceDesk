using System.Collections.Generic;
using WebUI.ViewModels.AttachmentsModel.IT.Accounts;
using WebUI.ViewModels.LifeCycles.IT.Accounts;

namespace WebUI.ViewModels.Requests.IT.Accounts
{
    public class AccountCancellationDetailsRequestViewModel: DetailsRequestViewModel
    {
        public AccountCancellationRequestViewModel RequestModel { get; set; }
        public List<AccountCancellationRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<AccountCancellationRequestLifeCycleViewModel>();
        public List<AccountCancellationRequestAttachmentViewModel> AttachmentsListModel { get; set; } = new List<AccountCancellationRequestAttachmentViewModel>();
    }
}