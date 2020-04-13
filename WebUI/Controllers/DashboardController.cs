using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.BranchModel;
using WebUI.ViewModels.CategoryModel;
using WebUI.ViewModels.ServiceModel;

namespace WebUI.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        //private readonly int pageSize = 6;
        private readonly IAccountRepository accountRepository;
        private readonly IAccountLogic accountLogic;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IBranchLogic branchLogic;
        private readonly ICategoryLogic categoryLogic;
        private readonly IServiceLogic serviceLogic;
        private readonly IAccountPermissionRepository accountPermissionRepository;

        public DashboardController(IAccountRepository accountRepository, IAccountLogic accountLogic, IAccountPermissionLogic accountPermissionLogic,
            IEmployeeRepository employeeRepository, IEmployeeLogic employeeLogic, IBranchLogic branchLogic, ICategoryLogic categoryLogic, IServiceLogic serviceLogic,
            IAccountPermissionRepository accountPermissionRepository)
        {
            this.accountRepository = accountRepository;
            this.accountLogic = accountLogic;
            this.accountPermissionLogic = accountPermissionLogic;
            this.employeeRepository = employeeRepository;
            this.employeeLogic = employeeLogic;
            this.branchLogic = branchLogic;
            this.categoryLogic = categoryLogic;
            this.serviceLogic = serviceLogic;
            this.accountPermissionRepository = accountPermissionRepository;
        }

        public async Task<Employee> PopulateAccountInfo()
        {
            int id = int.Parse(User.Identity.Name);
            var account = await accountLogic.GetAccountById(id);
            var user = await employeeLogic.GetEmployeeById(account.EmployeeId);
            account.Permissions = await accountPermissionLogic.GetPermissions(account.Id);
            ViewBag.CanAddRequest = account.Permissions.Where(p => p.PermissionId == 1).ToList().Count != 0;
            ViewBag.AccessToControlPanel = account.Permissions.Where(p => p.PermissionId == 4).ToList().Count != 0;
            ViewBag.ActiveUser = $"{account.Employee.Surname} {account.Employee.Firstname[0]}. {account.Employee.Patronymic[0]}.";
            return user;
        }

        public async Task<ActionResult> Index()
        {                   
            await PopulateAccountInfo();          
            return View();
        }

        public async Task<ActionResult> Requests(int service = 0, int page = 1)
        {
            await PopulateAccountInfo();
            // var requests = requestService.GetRequests();
            // RequestListViewModel model = ModelFromData.GetListViewModel(requests, user, service, page, pageSize);            
            // return View(model);
            return View();                
        }


        public async Task<ActionResult> ChooseBranch()
        {
            await PopulateAccountInfo();
            var branches = await branchLogic.GetBranches();
            BranchesListViewModel model = ModelFromData.GetListViewModel(branches);
            return View(model);
        }

        public async Task<ActionResult> ChooseCategory(int id)
        {
            await PopulateAccountInfo();
            var categories = await categoryLogic.GetCategoriesByBranchId(id);
            CategoriesListViewModel model = ModelFromData.GetListViewModel(categories);
            return View(model);
        }

        public async Task<ActionResult> ChooseService(int id)
        {
            await PopulateAccountInfo();
            var services = await serviceLogic.GetActiveServices();
            var category = await categoryLogic.GetCategoryById(id);
            ServicesListViewModel model = ModelFromData.GetListViewModel(services, category);
            return View(model);
        }
    }
}