using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.ViewModels.LifeCycles.IT.Emails;

namespace WebUI.ViewModels.Requests.IT.Emails
{
    public class EmailRegistrationDetailsRequestViewModel:DetailsRequestViewModel
    {
        public EmailRegistrationRequestViewModel RequestModel { get; set; }
        public List<EmailRegistrationRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<EmailRegistrationRequestLifeCycleViewModel>();
    }
}