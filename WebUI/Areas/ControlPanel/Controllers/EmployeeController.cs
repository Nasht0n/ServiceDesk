using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.Employee;

namespace WebUI.Areas.ControlPanel.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly ISubdivisionRepository subdivisionRepository;
        private readonly int pageSize = 5;

        public EmployeeController(IAccountRepository accountRepository, IEmployeeRepository employeeRepository, IEmployeeLogic employeeLogic,
            IAccountPermissionRepository accountPermissionRepository, ISubdivisionRepository subdivisionRepository)
        {
            this.accountRepository = accountRepository;
            this.employeeRepository = employeeRepository;
            this.employeeLogic = employeeLogic;
            this.accountPermissionRepository = accountPermissionRepository;
            this.subdivisionRepository = subdivisionRepository;
        }

        public async Task<Employee> PopulateAccountInfo()
        {
            int id = int.Parse(User.Identity.Name);
            var account = (await accountRepository.GetAccounts()).Where(a => a.Id == id).FirstOrDefault();
            var user = await employeeLogic.GetEmployee(account.EmployeeId);
            account.Permissions = (await accountPermissionRepository.GetAccountPermissions()).Where(ap => ap.AccountId == account.Id).ToList();
            ViewBag.CanAddRequest = account.Permissions.Where(p => p.PermissionId == 1).ToList().Count != 0;
            ViewBag.AccessToControlPanel = account.Permissions.Where(p => p.PermissionId == 4).ToList().Count != 0;
            ViewBag.ActiveUser = $"{account.Employee.Surname} {account.Employee.Firstname[0]}. {account.Employee.Patronymic[0]}.";
            return user;
        }

        public async Task PopulateDropDownList()
        {
            ViewBag.Subdivisions = await subdivisionRepository.GetSubdivisions();
        }

        public async Task<ActionResult> Index(string search = "", int page = 1, int subdivision = 0)
        {
            var user = await PopulateAccountInfo();
            await PopulateDropDownList();            
            List<Employee> employees = await employeeRepository.GetEmployees();
            EmployeesListViewModel model = ModelFromData.GetListViewModel(employees, search, subdivision, page, pageSize);
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var user = await PopulateAccountInfo();
            await PopulateDropDownList();
            return View(new EmployeeViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = DataFromModel.GetData(model);
                await employeeRepository.AddEmployee(employee);
                return RedirectToAction("Index", "Employee", new { Area = "ControlPanel" });
            }
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            var user = await PopulateAccountInfo();
            await PopulateDropDownList();
            Employee employee = await employeeLogic.GetEmployee(id);
            EmployeeViewModel model = ModelFromData.GetViewModel(employee);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = DataFromModel.GetData(model);
                await employeeRepository.UpdateEmployee(employee);
                return RedirectToAction("Index", "Employee", new { Area = "ControlPanel" });
            }
            return View();
        }
        public async  Task<ActionResult> Delete(int id)
        {
            var user = await PopulateAccountInfo();
            Employee employee = await employeeLogic.GetEmployee(id);
            EmployeeViewModel model = ModelFromData.GetViewModel(employee);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, EmployeeViewModel model)
        {
            Employee employee = await employeeLogic.GetEmployee(id);
            await employeeRepository.DeleteEmployee(employee);
            return RedirectToAction("Index", "Employee", new { Area = "ControlPanel" });
        }
    }
}