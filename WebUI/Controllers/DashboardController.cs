using BusinessLogic;
using BusinessLogic.Requests;
using Domain.Models;
using Domain.Views;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.Account;
using WebUI.ViewModels.Branch;
using WebUI.ViewModels.Category;
using WebUI.ViewModels.Requests.View;
using WebUI.ViewModels.Service;

namespace WebUI.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        //private readonly int pageSize = 6;
        private AccountService accountService = new AccountService();
        private BranchService branchService = new BranchService();
        private EmployeeService employeeService = new EmployeeService();
        private CategoryService categoryService = new CategoryService();
        private ServiceService serviceService = new ServiceService();
        private RequestService requestService = new RequestService();
        private readonly IAccountRepository accountRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IAccountPermissionRepository accountPermissionRepository;

        public DashboardController(IAccountRepository accountRepository, IEmployeeRepository employeeRepository, IAccountPermissionRepository accountPermissionRepository)
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

        public async Task<ActionResult> Index()
        {                   
            var user = await PopulateAccountInfo();          
            return View();
        }

        public async Task<ActionResult> Requests(int service = 0, int page = 1)
        {
            var user = await PopulateAccountInfo();
            // var requests = requestService.GetRequests();
            // RequestListViewModel model = ModelFromData.GetListViewModel(requests, user, service, page, pageSize);            
            // return View(model);
            return View();                
        }


        public ActionResult ChooseBranch()
        {
            var user = PopulateAccountInfo();
            var branches = branchService.GetBranches();
            BranchesListViewModel model = ModelFromData.GetListViewModel(branches);
            return View(model);
        }

        public ActionResult ChooseCategory(int id)
        {
            var user = PopulateAccountInfo();
            var categories = categoryService.GetCategories(id);
            CategoriesListViewModel model = ModelFromData.GetListViewModel(categories);
            return View(model);
        }

        public ActionResult ChooseService(int id)
        {
            var user = PopulateAccountInfo();
            var services = serviceService.GetServices().Where(s=>s.Visible).ToList();
            var category = categoryService.GetCategoryById(id);
            ServicesListViewModel model = ModelFromData.GetListViewModel(services, category);
            return View(model);
        }
    }
}