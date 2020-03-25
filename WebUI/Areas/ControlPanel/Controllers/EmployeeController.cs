using Domain.Models;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.ControlPanel.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly int pageSize = 5;

        public EmployeeController(IAccountRepository accountRepository, IEmployeeRepository employeeRepository, IAccountPermissionRepository accountPermissionRepository)
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

        public async Task<ActionResult> Index(string search = "", int page = 1, int subdivision = 0)
        {
            var user = await PopulateAccountInfo();
            return View();
        }

    }
}