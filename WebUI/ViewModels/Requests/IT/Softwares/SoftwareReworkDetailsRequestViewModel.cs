using System.Collections.Generic;
using WebUI.ViewModels.AttachmentsModel.IT.Softwares;
using WebUI.ViewModels.LifeCycles.IT.Softwares;

namespace WebUI.ViewModels.Requests.IT.Softwares
{
    public class SoftwareReworkDetailsRequestViewModel:DetailsRequestViewModel
    {
        public SoftwareReworkRequestViewModel RequestModel { get; set; }
        public List<SoftwareReworkRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<SoftwareReworkRequestLifeCycleViewModel>();
        public List<SoftwareReworkRequestAttachmentViewModel> AttachmentsListModel { get; set; } = new List<SoftwareReworkRequestAttachmentViewModel>();
    }
}