using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels.Requests.IT.Accounts
{
    public class AccountRegistrationRequestViewModel:RequestViewModel
    {
        public HttpPostedFileBase[] Files { get; set; }
    }
}