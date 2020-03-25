using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.ViewModels.Employee;

namespace WebUI.ViewModels.Subdivision
{
    public class SubdivisionExecutorViewModel
    {
        public int SubdivisionId { get; set; }
        public SubdivisionViewModel SubdvisionModel { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeViewModel Employee { get; set; }
    }
}