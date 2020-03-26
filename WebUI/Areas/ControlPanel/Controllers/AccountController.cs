using BusinessLogic;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using WebUI.Models;
using WebUI.ViewModels.Account;
using WebUI.ViewModels.Permission;
using Domain.Models.ManyToMany;
using System.Threading.Tasks;
using Repository.Abstract;
using BusinessLogic.Abstract;

namespace WebUI.Areas.ControlPanel.Controllers
{
    public class AccountController : Controller
    {
        private AccountService accountService = new AccountService();
        private EmployeeService employeeService = new EmployeeService();
        private SubdivisionService subdvisionService = new SubdivisionService();
        private PermissionService permissionService = new PermissionService();
        private readonly int pageSize = 5;
        private readonly IAccountRepository accountRepository;
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly ISubdivisionRepository subdivisionRepository;

        public AccountController(IAccountRepository accountRepository, IAccountLogic accountLogic,
            IEmployeeRepository employeeRepository, IEmployeeLogic employeeLogic,
            IAccountPermissionRepository accountPermissionRepository, ISubdivisionRepository subdivisionRepository)
        {
            this.accountRepository = accountRepository;
            this.accountLogic = accountLogic;
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

        public async Task<ActionResult> GetAccount(int id)
        {
            var account = await accountLogic.GetAccountByEmployeeId(id);
            if (account != null) return RedirectToAction("Edit", "Account", new { Area = "ControlPanel", id = account.Id });
            else return RedirectToAction("Create", "Account", new { Area = "ControlPanel", employeeId = id });
        }

        public async Task<ActionResult> Create(int employeeId)
        {
            var user = await PopulateAccountInfo();
            AccountViewModel model = new AccountViewModel();
            var employee = await employeeLogic.GetEmployee(employeeId);
            model.EmployeeModel = ModelFromData.GetViewModel(employee);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(AccountViewModel model)
        {
            if(ModelState.IsValid)
            {
                var account = DataFromModel.GetData(model);
                await accountRepository.AddAccount(account);
                return RedirectToAction("Permission","Account", new { Area = "ControlPanel", id = account.Id });
            }
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            var user = await PopulateAccountInfo();
            var account = await accountLogic.GetAccountById(id);
            AccountViewModel model = ModelFromData.GetViewModel(account);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(AccountViewModel model)
        {
            return RedirectToAction("");
        }
    }
    
}