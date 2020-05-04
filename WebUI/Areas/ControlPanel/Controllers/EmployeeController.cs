using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.EmployeeModel;

namespace WebUI.Areas.ControlPanel.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly ISubdivisionRepository subdivisionRepository;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly int pageSize = 5;

        public EmployeeController(IAccountRepository accountRepository, IAccountLogic accountLogic,
            IEmployeeRepository employeeRepository, IEmployeeLogic employeeLogic,
            IAccountPermissionRepository accountPermissionRepository, ISubdivisionRepository subdivisionRepository, IAccountPermissionLogic accountPermissionLogic)
        {
            this.accountRepository = accountRepository;
            this.accountLogic = accountLogic;
            this.employeeRepository = employeeRepository;
            this.employeeLogic = employeeLogic;
            this.accountPermissionRepository = accountPermissionRepository;
            this.subdivisionRepository = subdivisionRepository;
            this.accountPermissionLogic = accountPermissionLogic;
        }

        public async Task<Employee> PopulateAccountInfo()
        {
            int id = int.Parse(User.Identity.Name);
            var account = await accountLogic.GetAccount(id);
            var user = await employeeLogic.GetEmployee(account.EmployeeId);
            account.Permissions = await accountPermissionLogic.GetPermissions(account);

            ViewBag.CanAddRequest = account.Permissions.Where(p => p.PermissionId == 1).ToList().Count != 0;
            ViewBag.CanEditRequest = account.Permissions.Where(p => p.PermissionId == 2).ToList().Count != 0;
            ViewBag.CanDeleteRequest = account.Permissions.Where(p => p.PermissionId == 3).ToList().Count != 0;
            ViewBag.AccessToControlPanel = account.Permissions.Where(p => p.PermissionId == 4).ToList().Count != 0;
            ViewBag.ViewRequest = account.Permissions.Where(p => p.PermissionId == 5).ToList().Count != 0;
            ViewBag.ApprovalAllowed = account.Permissions.Where(p => p.PermissionId == 6).ToList().Count != 0;
            ViewBag.GetInWorkRequest = account.Permissions.Where(p => p.PermissionId == 7).ToList().Count != 0;

            ViewBag.ActiveUser = $"{account.Employee.Surname} {account.Employee.Firstname[0]}. {account.Employee.Patronymic[0]}.";
            return user;
        }

        public async Task<ActionResult> Index(string search = "", int page = 1, int subdivision = 0)
        {
            await PopulateAccountInfo();        
            List<Employee> employees = await employeeRepository.GetEmployees();
            EmployeesListViewModel model = ModelFromData.GetListViewModel(employees, search, subdivision, page, pageSize);
            var subdivisions = await subdivisionRepository.GetSubdivisions();
            model.Subdivisions = new SelectList(subdivisions, "Id", "Fullname");
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            await PopulateAccountInfo();
            EmployeeViewModel model = new EmployeeViewModel();
            var subdivisions = await subdivisionRepository.GetSubdivisions();
            model.Subdivisions = new SelectList(subdivisions, "Id", "Fullname");
            return View(model);
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
            await PopulateAccountInfo();            
            Employee employee = await employeeLogic.GetEmployee(id);
            EmployeeViewModel model = ModelFromData.GetViewModel(employee);
            var subdivisions = await subdivisionRepository.GetSubdivisions();
            model.Subdivisions = new SelectList(subdivisions, "Id", "Fullname",model.SelectedSubdivision);
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
            await PopulateAccountInfo();
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

        public async Task<ActionResult> Account(int employeeId)
        {
            var employee = await employeeLogic.GetEmployee(employeeId);
            var account = await accountLogic.GetAccount(employee);
            if(account != null)
            {
                return RedirectToAction("Edit","Account",new { Area = "ControlPanel", accountId = account.Id });
            } else
            {
                return RedirectToAction("Create","Account", new { Area = "ControlPanel", employeeId = employeeId });
            }
        }
    }
}