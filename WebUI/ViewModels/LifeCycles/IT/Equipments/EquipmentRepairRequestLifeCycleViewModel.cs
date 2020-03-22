using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.ViewModels.Requests.IT.Equipments;

namespace WebUI.ViewModels.LifeCycles.IT.Equipments
{
    public class EquipmentRepairRequestLifeCycleViewModel:LifeCycleViewModel
    {
        public int RequestId { get; set; }
        public EquipmentRepairRequestViewModel Request { get; set; }
    }
}