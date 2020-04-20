using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using WebUI.ViewModels.AttachmentsModel.IT.Accounts;

namespace WebUI.ViewModels.Requests.IT.Accounts
{
    public class AccountRegistrationRequestViewModel:RequestViewModel
    {
        [Required]
        [Display(Name = "Прикрепить файл")]
        public string FilePath { get; set; }
        [Display(Name = "Прикрепленные файлы")]
        public List<AccountRegistrationRequestAttachmentViewModel> AttachmentsModel { get; set; } = new List<AccountRegistrationRequestAttachmentViewModel>();
        public HttpPostedFileBase[] Files { get; set; }
        public SelectList Priorities { get; set; }
    }
}