using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.Service;

namespace WebUI.Areas.ControlPanel.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IBranchRepository branchRepository;
        private readonly IBranchLogic branchLogic;
        private readonly ICategoryRepository categoryRepository;
        private readonly ICategoryLogic categoryLogic;
        private readonly IServiceRepository serviceRepository;
        private readonly IServiceLogic serviceLogic;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly int pageSize = 5;

        public ServiceController(IAccountRepository accountRepository, IAccountLogic accountLogic,
            IEmployeeRepository employeeRepository, IEmployeeLogic employeeLogic,
            IBranchRepository branchRepository, IBranchLogic branchLogic,
            ICategoryRepository categoryRepository, ICategoryLogic categoryLogic,
            IServiceRepository serviceRepository, IServiceLogic serviceLogic,
            IAccountPermissionRepository accountPermissionRepository)
        {
            this.accountRepository = accountRepository;
            this.accountLogic = accountLogic;
            this.employeeRepository = employeeRepository;
            this.employeeLogic = employeeLogic;
            this.branchRepository = branchRepository;
            this.branchLogic = branchLogic;
            this.categoryRepository = categoryRepository;
            this.categoryLogic = categoryLogic;
            this.serviceRepository = serviceRepository;
            this.serviceLogic = serviceLogic;
            this.accountPermissionRepository = accountPermissionRepository;
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
        [HttpGet]
        public async Task<JsonResult> PopulateCategories(int branchId)
        {
            var categories = (await categoryRepository.GetCategories())
                .Where(c => c.BranchId == branchId)
                .Select(c => new { Value = c.Id, Text = c.Name });
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Index(string search = "", int page = 1, int branch = 0, int category = 0)
        {
            var user = await PopulateAccountInfo();
            var services = await serviceRepository.GetServices();
            ServicesListViewModel model = ModelFromData.GetListViewModel(services, search, page, branch, category, pageSize);
            var branches = await branchRepository.GetBranches();
            model.BranchList = new SelectList(branches, "Id","Fullname");            
            if (model.SelectedBranch.HasValue)
            {
                var categories = await categoryLogic.GetCategoriesByBranchId(model.SelectedBranch.Value);
                model.CategoryList = new SelectList(categories, "Id", "Name");
            } else
            {
                model.CategoryList = new SelectList(Enumerable.Empty<SelectListItem>());
            }
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var user = await PopulateAccountInfo();
            ServiceViewModel model = new ServiceViewModel();
            var branches = await branchRepository.GetBranches();
            model.BranchList = new SelectList(branches, "Id", "Fullname");
            if (model.SelectedBranch.HasValue)
            {
                var categories = await categoryLogic.GetCategoriesByBranchId(model.SelectedBranch.Value);
                model.CategoryList = new SelectList(categories, "Id", "Name");
            }
            else
            {
                model.CategoryList = new SelectList(Enumerable.Empty<SelectListItem>());
            }
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Create(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = DataFromModel.GetData(model);
                await serviceRepository.AddService(service);
                return RedirectToAction("Index", "Service", new { Area = "ControlPanel" });
            }
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            var user = await PopulateAccountInfo();
            var service = await serviceLogic.GetServiceById(id);
            ServiceViewModel model = ModelFromData.GetViewModel(service);

            var branches = await branchRepository.GetBranches();
            model.BranchList = new SelectList(branches, "Id", "Fullname", model.SelectedBranch);            
            var categories = await categoryLogic.GetCategoriesByBranchId(model.SelectedBranch.Value);
            model.CategoryList = new SelectList(categories, "Id", "Name", model.SelectedCategory);
            
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = DataFromModel.GetData(model);
                await serviceRepository.UpdateService(service);
                return RedirectToAction("Index", "Service", new { Area = "ControlPanel" });
            }
            return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            var user = await PopulateAccountInfo();
            var service = await serviceLogic.GetServiceById(id);
            ServiceViewModel model = ModelFromData.GetViewModel(service);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, ServiceViewModel model)
        {
            var service = await serviceLogic.GetServiceById(id);
            await serviceRepository.DeleteService(service);
            return RedirectToAction("Index", "Service", new { Area = "ControlPanel" });
        }
    }
}