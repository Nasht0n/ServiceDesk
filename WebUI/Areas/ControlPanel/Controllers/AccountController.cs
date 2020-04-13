using BusinessLogic.Abstract;
using Domain.Models;
using Domain.Models.ManyToMany;
using Repository.Abstract;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.AccountModel;

namespace WebUI.Areas.ControlPanel.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly IPermissionRepository permissionRepository;

        public AccountController(IAccountRepository accountRepository, IAccountLogic accountLogic, 
            IEmployeeRepository employeeRepository, IEmployeeLogic employeeLogic,
            IAccountPermissionRepository accountPermissionRepository, IAccountPermissionLogic accountPermissionLogic,
            IPermissionRepository permissionRepository)
        {
            this.accountRepository = accountRepository;
            this.accountLogic = accountLogic;
            this.employeeRepository = employeeRepository;
            this.employeeLogic = employeeLogic;
            this.accountPermissionRepository = accountPermissionRepository;
            this.accountPermissionLogic = accountPermissionLogic;
            this.permissionRepository = permissionRepository;
        }

        public async Task<Employee> PopulateAccountInfo()
        {
            int id = int.Parse(User.Identity.Name);
            var account = (await accountRepository.GetAccounts()).Where(a => a.Id == id).FirstOrDefault();
            var user = await employeeLogic.GetEmployeeById(account.EmployeeId);
            account.Permissions = await accountPermissionLogic.GetPermissions(account.Id);
            ViewBag.CanAddRequest = account.Permissions.Where(p => p.PermissionId == 1).ToList().Count != 0;
            ViewBag.AccessToControlPanel = account.Permissions.Where(p => p.PermissionId == 4).ToList().Count != 0;
            ViewBag.ActiveUser = $"{account.Employee.Surname} {account.Employee.Firstname[0]}. {account.Employee.Patronymic[0]}.";
            return user;
        }

        public async Task<ActionResult> Create(int employeeId)
        {
            await PopulateAccountInfo();
            AccountViewModel model = new AccountViewModel();
            var employee = await employeeLogic.GetEmployeeById(employeeId);
            var permissions = await permissionRepository.GetPermissions();
            model.EmployeeModel = ModelFromData.GetViewModel(employee);
            model.Permissions = ModelFromData.GetListViewModel(permissions);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(AccountViewModel model)
        {
            // update account
            var account = DataFromModel.GetData(model);
            account.DateRegistration = DateTime.Now;
            account.DateChangePassword = DateTime.Now;
            account.LastEnterDateTime = DateTime.Now;
            await accountRepository.AddAccount(account);
           // var permissions = await accountPermissionLogic.GetPermissions(account.Id);
            foreach (var permission in model.Permissions)
            {
                // var temp = permissions.SingleOrDefault(p => p.PermissionId == permission.Id);
                AccountPermission accountPermission = new AccountPermission { AccountId = account.Id, PermissionId = permission.Id };
                if (permission.IsChecked)
                {
                    await accountPermissionRepository.AddAccountPermission(accountPermission);
                }
                else if (!permission.IsChecked)
                {
                    await accountPermissionRepository.DeleteAccountPermission(accountPermission);
                }
            }
            return RedirectToAction("Index", "Employee", new { Area = "ControlPanel" });
        }

        public async Task<ActionResult> Edit(int accountId)
        {
            await PopulateAccountInfo();
            var account = await accountLogic.GetAccountById(accountId);
            AccountViewModel model = ModelFromData.GetViewModel(account);
            var permissions = await permissionRepository.GetPermissions();
            var accountPermissions = await accountPermissionLogic.GetPermissions(account.Id);
            model.Permissions = ModelFromData.GetListViewModel(permissions, accountPermissions);
            
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(AccountViewModel model)
        {
            // update account
            var account = DataFromModel.GetData(model);
            await accountRepository.UpdateAccount(account);
            var permissions = await accountPermissionLogic.GetPermissions(account.Id);            
            foreach(var permission in model.Permissions)
            {
                var temp = permissions.SingleOrDefault(p => p.PermissionId == permission.Id);
                AccountPermission accountPermission = new AccountPermission { AccountId = account.Id, PermissionId = permission.Id };
                if (permission.IsChecked && temp==null)
                {                    
                    await accountPermissionRepository.AddAccountPermission(accountPermission);
                } else if (!permission.IsChecked && temp != null)
                {
                    await accountPermissionRepository.DeleteAccountPermission(accountPermission);
                }
            }
            return RedirectToAction("Index","Employee",new { Area = "ControlPanel" });
        }
    }
}