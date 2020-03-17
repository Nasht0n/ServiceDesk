using BusinessLogic;
using Domain.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.Employee;

namespace WebUI.Areas.ControlPanel.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService employeeService = new EmployeeService();
        private SubdvisionService subdvisionService = new SubdvisionService();
        private readonly int pageSize = 5;

        private void PopulateDropDownList()
        {
            List<Subdivision> subdivsions = new List<Subdivision>();
            subdivsions.Add(new Subdivision { Id = 0, Fullname = "Все подразделения", Shortname = "Все" });
            subdivsions.AddRange(subdvisionService.GetSubdivisions());
            ViewBag.Subdivisions = subdivsions;
        }

        public ActionResult Index(string search = "", int page = 1, int subdivision = 0)
        {
            var employees = employeeService.GetEmployees();
            PopulateDropDownList();
            EmployeesListViewModel model = ModelFromData.GetListViewModel(employees, search, subdivision, page, pageSize);
            return View(model);
        }
    }
}