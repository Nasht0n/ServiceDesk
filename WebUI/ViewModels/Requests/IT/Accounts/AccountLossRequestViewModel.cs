using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using WebUI.ViewModels.AttachmentsModel.IT.Accounts;

namespace WebUI.ViewModels.Requests.IT.Accounts
{
    public class AccountLossRequestViewModel:RequestViewModel
    {
        [Required]
        [Display(Name = "Прикрепить файл")]
        public string FilePath { get; set; }
        [Display(Name = "Прикрепленные файлы")]
        public List<AccountLossRequestAttachmentViewModel> AttachmentsModel { get; set; } = new List<AccountLossRequestAttachmentViewModel>();
        public HttpPostedFileBase[] Files { get; set; }
        public SelectList Priorities { get; set; }
    }
}