using BusinessLogic;
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
using WebUI.ViewModels.Subdivision;

namespace WebUI.Areas.ControlPanel.Controllers
{
    public class SubdivisionController : Controller
    {
        private AccountService accountService = new AccountService();
        private EmployeeService employeeService = new EmployeeService();
        private SubdivisionService subdivisionService = new SubdivisionService();
        private readonly int pageSize = 5;
        private readonly IAccountRepository accountRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly ISubdivisionRepository subdivisionRepository;
        private readonly ISubdivisionLogic subdivisionLogic;

        public SubdivisionController(IAccountRepository accountRepository, IEmployeeRepository employeeRepository, IAccountPermissionRepository accountPermissionRepository, 
            ISubdivisionRepository subdivisionRepository, ISubdivisionLogic subdivisionLogic)
        {
            this.accountRepository = accountRepository;
            this.employeeRepository = employeeRepository;
            this.accountPermissionRepository = accountPermissionRepository;
            this.subdivisionRepository = subdivisionRepository;
            this.subdivisionLogic = subdivisionLogic;
        }

        public async Task<Employee> PopulateAccountInfo()
        {
            int id = int.Parse(User.Identity.Name);
            var account = (await accountRepository.GetAccounts()).Where(a => a.Id == id).FirstOrDefault();
            var user = (await employeeRepository.GetEmployees()).Where(e => e.Id == account.EmployeeId).FirstOrDefault();
            account.Permissions = (await accountPermissionRepository.GetAccountPermissions()).Where(ap => ap.AccountId == account.Id).ToList();
            ViewBag.CanAddRequest = account.Permissions.Where(p => p.PermissionId == 1).ToList().Count != 0;
            ViewBag.AccessToControlPanel = account.Permissions.Where(p => p.PermissionId == 4).ToList().Count != 0;
            ViewBag.ActiveUser = $"{account.Employee.Surname} {account.Employee.Firstname[0]}. {account.Employee.Patronymic[0]}.";
            return user;
        }

        public async Task PopulateDropDownList(bool filter = false)
        {
            List<Subdivision> subdivisions = new List<Subdivision>();
            if (filter)
            {
                subdivisions.Add(new Subdivision { Id = 0, Fullname = "Все подразделения", Shortname = "Все" });
            }
            subdivisions.AddRange(await subdivisionRepository.GetSubdivisions());
            ViewBag.Subdivisions = subdivisions;
        }

        public async Task<ActionResult> Index(string search = "", int page = 1)
        {
            var user = await PopulateAccountInfo();
            var subdivisions = await subdivisionRepository.GetSubdivisions();
            SubdivisionsListViewModel model = ModelFromData.GetListViewModel(subdivisions, search, page, pageSize);
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var user = await PopulateAccountInfo();
            return View(new SubdivisionViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(SubdivisionViewModel model)
        {
            var user = await PopulateAccountInfo();
            Subdivision subdivision = DataFromModel.GetData(model);
            await subdivisionRepository.AddSubdivision(subdivision);
            return RedirectToAction("Index", "Subdivision", new { Area = "ControlPanel" });
        }

        public async Task<ActionResult> Edit(int id)
        {
            var user = await PopulateAccountInfo();            
            var subdivision = await subdivisionLogic.GetSubdivision(id);
            SubdivisionViewModel model = ModelFromData.GetViewModel(subdivision);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(SubdivisionViewModel model)
        {
            var user = await PopulateAccountInfo();
            Subdivision subdivision = DataFromModel.GetData(model);
            await subdivisionRepository.UpdateSubdivision(subdivision);
            return RedirectToAction("Index", "Subdivision", new { Area = "ControlPanel" });
        }
        public async Task<ActionResult> Delete(int id)
        {
            var user = await PopulateAccountInfo();
            var subdivision = await subdivisionLogic.GetSubdivision(id);
            SubdivisionViewModel model = ModelFromData.GetViewModel(subdivision);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, SubdivisionViewModel model)
        {
            var user = await PopulateAccountInfo();
            var subdivision = await subdivisionLogic.GetSubdivision(id);
            await subdivisionRepository.DeleteSubdivision(subdivision);
            return RedirectToAction("Index", "Subdivision", new { Area = "ControlPanel" });
        }

        public async Task<ActionResult> SubdivisionExecutors(int id, string search = "", int subdivisionId = 0)
        {
            var user = await PopulateAccountInfo();
            PopulateDropDownList(true);
            var subdivision = await subdivisionLogic.GetSubdivision(id);
            ListSubdivisionExecutorsViewModel model = ModelFromData.GetListViewModel(subdivision);

            var employees = await employeeRepository.GetEmployees();
            
            model.Employees = ModelFromData.GetListViewModel(employees);

            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> AddExecutor(int subdivisionId, int employeeId)
        {

            return View();
        }
    }
}