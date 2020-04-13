using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.BranchModel;

namespace WebUI.Areas.ControlPanel.Controllers
{
    [Authorize]
    public class BranchController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IAccountLogic accountLogic;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly ISubdivisionRepository subdivisionRepository;
        private readonly IBranchRepository branchRepository;
        private readonly IBranchLogic branchLogic;
        private readonly int pageSize = 5;

        public BranchController(IAccountRepository accountRepository, IEmployeeRepository employeeRepository, IEmployeeLogic employeeLogic, IAccountLogic accountLogic,
            IAccountPermissionRepository accountPermissionRepository, ISubdivisionRepository subdivisionRepository, IBranchRepository branchRepository, IBranchLogic branchLogic)
        {
            this.accountRepository = accountRepository;
            this.employeeRepository = employeeRepository;
            this.employeeLogic = employeeLogic;
            this.accountLogic = accountLogic;
            this.accountPermissionRepository = accountPermissionRepository;
            this.subdivisionRepository = subdivisionRepository;
            this.branchRepository = branchRepository;
            this.branchLogic = branchLogic;
        }

        public async Task<Employee> PopulateAccountInfo()
        {
            int id = int.Parse(User.Identity.Name);
            var account = await accountLogic.GetAccountById(id);
            var user = await employeeLogic.GetEmployeeById(account.EmployeeId);
            account.Permissions = (await accountPermissionRepository.GetAccountPermissions()).Where(ap => ap.AccountId == account.Id).ToList();
            ViewBag.CanAddRequest = account.Permissions.Where(p => p.PermissionId == 1).ToList().Count != 0;
            ViewBag.AccessToControlPanel = account.Permissions.Where(p => p.PermissionId == 4).ToList().Count != 0;
            ViewBag.ActiveUser = $"{account.Employee.Surname} {account.Employee.Firstname[0]}. {account.Employee.Patronymic[0]}.";
            return user;
        }

        public async Task<ActionResult> Index(string search = "", int page = 1)
        {
            await PopulateAccountInfo();
            var branches = await branchRepository.GetBranches();
            BranchesListViewModel model = ModelFromData.GetListViewModel(branches, search, page, pageSize);
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            await PopulateAccountInfo();
            return View(new BranchViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(BranchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var branch = DataFromModel.GetData(model);
                await branchRepository.AddBranch(branch);
                return RedirectToAction("Index", "Branch", new { Area = "ControlPanel" });
            }
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            await PopulateAccountInfo();
            var branch = await branchLogic.GetBranchById(id);
            BranchViewModel model = ModelFromData.GetViewModel(branch);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(BranchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var branch = DataFromModel.GetData(model);
                await branchRepository.UpdateBranch(branch);
                return RedirectToAction("Index", "Branch", new { Area = "ControlPanel" });
            }
            return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            await PopulateAccountInfo();
            var branch = await branchLogic.GetBranchById(id);
            BranchViewModel model = ModelFromData.GetViewModel(branch);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, BranchViewModel model)
        {
            var branch = await branchLogic.GetBranchById(id);
            await branchRepository.DeleteBranch(branch);
            return RedirectToAction("Index", "Branch", new { Area = "ControlPanel" });
        }
    }
}