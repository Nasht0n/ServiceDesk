using BusinessLogic.Abstract;
using Domain.Models;
using Domain.Views;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Models.Enum;
using WebUI.ViewModels;
using WebUI.ViewModels.BranchModel;
using WebUI.ViewModels.CategoryModel;
using WebUI.ViewModels.Requests.View;
using WebUI.ViewModels.ServiceModel;

namespace WebUI.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountLogic accountLogic;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IBranchLogic branchLogic;
        private readonly ICategoryLogic categoryLogic;
        private readonly IServiceLogic serviceLogic;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly IRequestsLogic requestsLogic;
        private readonly IStatusLogic statusLogic;

        public DashboardController(IAccountRepository accountRepository, IAccountLogic accountLogic, IAccountPermissionLogic accountPermissionLogic,
            IEmployeeRepository employeeRepository, IEmployeeLogic employeeLogic, IBranchLogic branchLogic, ICategoryLogic categoryLogic, IServiceLogic serviceLogic,
            IAccountPermissionRepository accountPermissionRepository, IRequestsLogic requestsLogic, IStatusLogic statusLogic)
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
            this.requestsLogic = requestsLogic;
            this.statusLogic = statusLogic;
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
            var executorGroups = user.ExecutorGroups;

            DashboardViewModel model = new DashboardViewModel();
            List<Requests> requests = new List<Requests>();
            if (executorGroups != null)
            {
                requests = await requestsLogic.GetRequests(user);
                model.RequestsModel = ModelFromData.GetViewModel(requests);
            }
            var services = await serviceLogic.GetActiveServices();
            List<ServicesStats> stats = new List<ServicesStats>();
            foreach (var service in services)
            {
                ServicesStats item = new ServicesStats();
                item.ServiceModel = ModelFromData.GetViewModel(service);
                item.Count = requests.Where(r => r.ServiceId == service.Id).Count();
                if (item.Count != 0) stats.Add(item);
            }
            model.StatsModel = stats;           

            model.CountCreatedRequest = requests.Where(r => r.ClientId == user.Id).Count();
            model.CountExecutedRequest = requests.Where(r => r.ExecutorId == user.Id).Count();
            model.CountApprovalRequest = requests.Where(r => r.StatusId == (int)RequestStatus.Approval).Count();
            model.CountCompletedRequest = requests.Where(r => r.StatusId == (int)RequestStatus.Done).Count();

            return View(model);
        }

        public async Task<ActionResult> Requests(int serviceId = 0)
        {
            var user = await PopulateAccountInfo();
            var executorGroups = user.ExecutorGroups;
            RequestListViewModel model = new RequestListViewModel();

                var service = await serviceLogic.GetService(serviceId);
                List<Requests> requests = new List<Requests>();
                if (executorGroups != null)
                {
                    requests = await requestsLogic.GetRequests(user, service);
                }
                model = ModelFromData.GetListViewModel(requests, user, service);
            
            return View(model);
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
            var branch = await branchLogic.GetBranch(id);
            var categories = await categoryLogic.GetCategories(branch);
            CategoriesListViewModel model = ModelFromData.GetListViewModel(categories);
            return View(model);
        }

        public async Task<ActionResult> ChooseService(int id)
        {
            await PopulateAccountInfo();

            var services = await serviceLogic.GetActiveServices();
            var category = await categoryLogic.GetCategory(id);

            ServicesListViewModel model = ModelFromData.GetListViewModel(services, category);
            return View(model);
        }
    }
}