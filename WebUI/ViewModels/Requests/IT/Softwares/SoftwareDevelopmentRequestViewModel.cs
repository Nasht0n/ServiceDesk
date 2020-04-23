using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using WebUI.ViewModels.AttachmentsModel.IT.Softwares;

namespace WebUI.ViewModels.Requests.IT.Softwares
{
    public class SoftwareDevelopmentRequestViewModel:RequestViewModel
    {
        [Required]
        [Display(Name = "Прикрепить файл")]
        public string FilePath { get; set; }
        [Display(Name = "Прикрепленные файлы")]
        public List<SoftwareDevelopmentRequestAttachmentViewModel> AttachmentsModel { get; set; } = new List<SoftwareDevelopmentRequestAttachmentViewModel>();
        public HttpPostedFileBase[] Files { get; set; }

        public SelectList Priorities { get; set; }
    }
}