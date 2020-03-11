using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.Employee
{
    public class EmployeesListViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
        public int SubdivisionId { get; set; }
    }
}