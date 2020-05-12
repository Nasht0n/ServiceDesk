using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.ViewModels.AccountModel;
using WebUI.ViewModels.EmployeeModel;

namespace WebUI.ViewModels
{
    public class ProfileViewModel:DashboardConfigurationViewModel
    {
        public EmployeeViewModel Employee { get; set; }
        public AccountViewModel Account { get; set; }
    }
}