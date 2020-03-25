using System.Collections.Generic;
using WebUI.ViewModels.Employee;

namespace WebUI.ViewModels.Subdivision
{
    public class ListSubdivisionExecutorsViewModel
    {
        public int SubdivisionId { get; set; }
        public SubdivisionViewModel SubdivisionModel { get; set; }

        public EmployeesListViewModel Employees { get; set; }
        public List<SubdivisionExecutorViewModel> ExecutorsModel { get; set; }
    }
}