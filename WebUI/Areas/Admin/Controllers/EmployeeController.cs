using BusinessLogic;
using Domain.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.Employee;

namespace WebUI.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService employeeService = new EmployeeService();
        private SubdivisionService subdvisionService = new SubdivisionService();
        private readonly int pageSize = 5;

        public ActionResult Employees(string search = "", int page = 1, int subdivision = 0)
        {
            ViewBag.Subdivisions = subdvisionService.GetSubdivisions();
            List<Employee> employees = employeeService.GetEmployees();
            EmployeesListViewModel model = ModelFromData.GetListViewModel(employees, search, subdivision, page, pageSize);
            return View(model);
        }

        public ActionResult AddEmployee()
        {
            ViewBag.Subdivisions = subdvisionService.GetSubdivisions();
            return View(new EmployeeViewModel());
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = DataFromModel.GetData(model);
                employeeService.AddEmployee(employee);
                return RedirectToAction("Employees", "Employee");
            }
            return View();
        }

        public ActionResult EditEmployee(int id)
        {            
            Employee employee = employeeService.GetEmployeeById(id);
            EmployeeViewModel model = ModelFromData.GetViewModel(employee);
            ViewBag.Subdivisions = subdvisionService.GetSubdivisions();
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEmployee(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = DataFromModel.GetData(model);
                employeeService.UpdateEmployee(employee);
                return RedirectToAction("Employees", "Employee");
            }
            return View();
        }
        public ActionResult DeleteEmployee(int id)
        {
            Employee employee = employeeService.GetEmployeeById(id);
            EmployeeViewModel model = ModelFromData.GetViewModel(employee);
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteEmployee(int id, EmployeeViewModel model)
        {
            Employee employee = employeeService.GetEmployeeById(id);
            employeeService.DeleteEmployee(employee);
            return RedirectToAction("Employees", "Employee");
        }
    }
}