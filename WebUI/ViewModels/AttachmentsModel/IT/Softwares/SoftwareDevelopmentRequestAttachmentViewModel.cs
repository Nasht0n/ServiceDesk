using WebUI.ViewModels.Requests.IT.Softwares;

namespace WebUI.ViewModels.AttachmentsModel.IT.Softwares
{
    public class SoftwareDevelopmentRequestAttachmentViewModel:AttachmentViewModel
    {
        public SoftwareDevelopmentRequestViewModel RequestModel { get; set; }
        public AttachmentViewModel AttachmentModel { get; set; }
    }
}