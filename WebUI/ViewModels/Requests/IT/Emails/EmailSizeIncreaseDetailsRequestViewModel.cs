using System.Collections.Generic;
using WebUI.ViewModels.LifeCycles.IT.Emails;

namespace WebUI.ViewModels.Requests.IT.Emails
{
    public class EmailSizeIncreaseDetailsRequestViewModel:DetailsRequestViewModel
    {
        public EmailSizeIncreaseRequestViewModel RequestModel { get; set; }
        public List<EmailSizeIncreaseRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<EmailSizeIncreaseRequestLifeCycleViewModel>();
    }
}