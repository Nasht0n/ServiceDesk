using BusinessLogic;
using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Areas.ControlPanel.Data;

namespace WebUI.Areas.ControlPanel.Controllers
{
    [Authorize]
    public class DeskController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeLogic employeeLogic;

        public DeskController(IAccountRepository accountRepository, IEmployeeRepository employeeRepository, IAccountPermissionRepository accountPermissionRepository, 
            IAccountPermissionLogic accountPermissionLogic, IAccountLogic accountLogic, IEmployeeLogic employeeLogic)
        {
            this.accountRepository = accountRepository;
            this.employeeRepository = employeeRepository;
            this.accountPermissionRepository = accountPermissionRepository;
            this.accountPermissionLogic = accountPermissionLogic;
            this.accountLogic = accountLogic;
            this.employeeLogic = employeeLogic;
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

        public async Task<ActionResult> Index()
        {
            var user = await PopulateAccountInfo();
            return View(new ControlPanelViewModel());
        }
    }
}