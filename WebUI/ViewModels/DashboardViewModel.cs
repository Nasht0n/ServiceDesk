using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.ViewModels.EmployeeModel;
using WebUI.ViewModels.Requests.View;

namespace WebUI.ViewModels
{
    public class DashboardViewModel
    {
        public List<RequestViewModel> Requests { get; set; }
        public EmployeeViewModel EmployeeModel { get; set; }

        public int CountCreatedRequest
        {
            get
            {
                return Requests.Where(r => r.ClientId == EmployeeModel.Id).ToList().Count();
            }
        }
        public int CountExecutedRequest
        {
            get
            {
                return Requests.Where(r => r.ExecutorId == EmployeeModel.Id).ToList().Count();
            }
        }
        public int CountCompletedRequest { get; set; }
    }
}