using BusinessLogic;
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

        public SubdivisionController(IAccountRepository accountRepository, IEmployeeRepository employeeRepository, IAccountPermissionRepository accountPermissionRepository)
        {
            this.accountRepository = accountRepository;
            this.employeeRepository = employeeRepository;
            this.accountPermissionRepository = accountPermissionRepository;
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

        public async Task<ActionResult> Index(string search = "", int page = 1)
        {
            var user = await PopulateAccountInfo();
            List<Subdivision> subdivisions = subdivisionService.GetSubdivisions();
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
            subdivisionService.AddSubdivision(subdivision);
            return RedirectToAction("Index", "Subdivision");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var user = await PopulateAccountInfo();
            Subdivision subdivision = subdivisionService.GetSubdivisionById(id);
            SubdivisionViewModel model = ModelFromData.GetViewModel(subdivision);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(SubdivisionViewModel model)
        {
            var user = await PopulateAccountInfo();
            Subdivision subdivision = DataFromModel.GetData(model);
            subdivisionService.UpdateSubdivision(subdivision);
            return RedirectToAction("Index", "Subdivision");
        }
        public async Task<ActionResult> Delete(int id)
        {
            var user = await PopulateAccountInfo();
            Subdivision subdivision = subdivisionService.GetSubdivisionById(id);
            SubdivisionViewModel model = ModelFromData.GetViewModel(subdivision);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, SubdivisionViewModel model)
        {
            var user = await PopulateAccountInfo();
            Subdivision subdivision = subdivisionService.GetSubdivisionById(id);
            subdivisionService.DeleteSubdivision(subdivision);
            return RedirectToAction("Index", "Subdivision");
        }
    }
}