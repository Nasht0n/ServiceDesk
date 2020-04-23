using WebUI.ViewModels.Requests.IT.Softwares;

namespace WebUI.ViewModels.AttachmentsModel.IT.Softwares
{
    public class SoftwareReworkRequestAttachmentViewModel:AttachmentViewModel
    {
        public SoftwareReworkRequestViewModel RequestModel { get; set; }
        public AttachmentViewModel AttachmentModel { get; set; }
    }
}