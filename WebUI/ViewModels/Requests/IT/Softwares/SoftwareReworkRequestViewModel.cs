using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using WebUI.ViewModels.AttachmentsModel.IT.Softwares;

namespace WebUI.ViewModels.Requests.IT.Softwares
{
    public class SoftwareReworkRequestViewModel:RequestViewModel
    {
        [Required]
        [Display(Name = "Прикрепить файл")]
        public string FilePath { get; set; }
        [Display(Name = "Прикрепленные файлы")]
        public List<SoftwareReworkRequestAttachmentViewModel> AttachmentsModel { get; set; } = new List<SoftwareReworkRequestAttachmentViewModel>();
        public HttpPostedFileBase[] Files { get; set; }

        public SelectList Priorities { get; set; }
    }
}