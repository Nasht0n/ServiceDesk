using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.CategoryModel;

namespace WebUI.Areas.ControlPanel.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IBranchRepository branchRepository;
        private readonly IBranchLogic branchLogic;
        private readonly ICategoryRepository categoryRepository;
        private readonly ICategoryLogic categoryLogic;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly int pageSize = 5;

        public CategoryController
            (
            IAccountRepository accountRepository, IAccountLogic accountLogic,
            IEmployeeRepository employeeRepository, IEmployeeLogic employeeLogic,
            IBranchRepository branchRepository, IBranchLogic branchLogic,
            ICategoryRepository categoryRepository, ICategoryLogic categoryLogic,
            IAccountPermissionRepository accountPermissionRepository, IAccountPermissionLogic accountPermissionLogic
            )
        {
            this.accountRepository = accountRepository;
            this.accountLogic = accountLogic;
            this.employeeRepository = employeeRepository;
            this.employeeLogic = employeeLogic;
            this.branchRepository = branchRepository;
            this.branchLogic = branchLogic;
            this.categoryRepository = categoryRepository;
            this.categoryLogic = categoryLogic;
            this.accountPermissionRepository = accountPermissionRepository;
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

        public async Task<ActionResult> Index(string search = "", int page = 1, int branch = 0)
        {
            await PopulateAccountInfo();
            var categories = await categoryRepository.GetCategories();
            CategoriesListViewModel model = ModelFromData.GetListViewModel(categories, search, branch, page, pageSize);
            var branches = await branchRepository.GetBranches();
            model.Branches = new SelectList(branches,"Id", "Fullname");
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            await PopulateAccountInfo();
            CategoryViewModel model = new CategoryViewModel();
            var branches = await branchRepository.GetBranches();
            model.Branches = new SelectList(branches, "Id", "Fullname");
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = DataFromModel.GetData(model);
                await categoryRepository.AddCategory(category);
                return RedirectToAction("Index", "Category", new { Area = "ControlPanel" });
            }
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            await PopulateAccountInfo();
            var category = await categoryLogic.GetCategory(id);
            CategoryViewModel model = ModelFromData.GetViewModel(category);
            var branches = await branchRepository.GetBranches();
            model.Branches = new SelectList(branches, "Id", "Fullname",model.SelectedBranch);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = DataFromModel.GetData(model);
                await categoryRepository.UpdateCategory(category);
                return RedirectToAction("Index", "Category", new { Area = "ControlPanel" });
            }
            return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            await PopulateAccountInfo();
            var category = await categoryLogic.GetCategory(id);
            CategoryViewModel model = ModelFromData.GetViewModel(category);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, CategoryViewModel model)
        {
            var category = await categoryLogic.GetCategory(id);
            await categoryRepository.DeleteCategory(category);
            return RedirectToAction("Index", "Category", new { Area = "ControlPanel" });
        }
    }
}