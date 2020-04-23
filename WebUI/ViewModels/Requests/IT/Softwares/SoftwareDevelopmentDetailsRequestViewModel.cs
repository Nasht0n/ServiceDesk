using System.Collections.Generic;
using WebUI.ViewModels.AttachmentsModel.IT.Softwares;
using WebUI.ViewModels.LifeCycles.IT.Softwares;

namespace WebUI.ViewModels.Requests.IT.Softwares
{
    public class SoftwareDevelopmentDetailsRequestViewModel:DetailsRequestViewModel
    {
        public SoftwareDevelopmentRequestViewModel RequestModel { get; set; }
        public List<SoftwareDevelopmentRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<SoftwareDevelopmentRequestLifeCycleViewModel>();
        public List<SoftwareDevelopmentRequestAttachmentViewModel> AttachmentsListModel { get; set; } = new List<SoftwareDevelopmentRequestAttachmentViewModel>();
    }
}