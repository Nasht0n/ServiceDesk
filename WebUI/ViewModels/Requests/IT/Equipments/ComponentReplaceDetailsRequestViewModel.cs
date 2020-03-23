using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.ViewModels.LifeCycles.IT.Equipments;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class ComponentReplaceDetailsRequestViewModel:DetailsRequestViewModel
    {
        public ComponentReplaceRequestViewModel RequestModel { get; set; }
        public List<ComponentReplaceRequestLifeCycleViewModel> LifeCyclesListModel { get; set; } = new List<ComponentReplaceRequestLifeCycleViewModel>();
    }
}