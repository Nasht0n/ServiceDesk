using System.Collections.Generic;
using System.Linq;
using WebUI.Models.Enum;
using WebUI.ViewModels.CategoryModel;
using WebUI.ViewModels.ServiceModel;
using WebUI.ViewModels.StatusModel;

namespace WebUI.ViewModels.Requests.View
{
    public class RequestListViewModel : DashboardConfigurationViewModel
    {
        public CategoryViewModel CategoryModel { get; set; }
        public ServiceViewModel ServiceModel { get; set; }
        public StatusViewModel StatusModel { get; set; }
        public bool InWork { get; set; }
        public bool Approver { get; set; }


        public List<RequestViewModel> RequestsList
        {
            get
            {
                List<RequestViewModel> result = Requests;
                if (CategoryModel != null) result = result.Where(r => r.ServiceModel.CategoryModel.Id == CategoryModel.Id).ToList();
                if (ServiceModel != null) result = result.Where(r => r.ServiceId == ServiceModel.Id).ToList();
                if (StatusModel != null) result = result.Where(r => r.StatusId == StatusModel.Id).ToList();
                if (InWork) result = result.Where(r => r.StatusId == (int)RequestStatus.Open || r.StatusId == (int)RequestStatus.Agreed).ToList();
                if (Approver) result = result.Where(r => r.StatusId != (int)RequestStatus.Open && r.StatusId != (int)RequestStatus.Approval).ToList();
                return result;
            }
        }
    }
}