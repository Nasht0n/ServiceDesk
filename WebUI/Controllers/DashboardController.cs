using BusinessLogic;
using BusinessLogic.Requests;
using Domain.Models;
using Domain.Views;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private int pageSize = 6;

        private AccountService accountService = new AccountService();
        private BranchService branchService = new BranchService();
        private EmployeeService employeeService = new EmployeeService();
        private CategoryService categoryService = new CategoryService();
        private ServiceService serviceService = new ServiceService();
        private RequestService requestService = new RequestService();

        public Employee PopulateAccountInfo()
        {
            int id = int.Parse(User.Identity.Name);
            var account = accountService.GetAccountById(id);
            var user = employeeService.GetEmployeeById(account.EmployeeId);
            ViewBag.CanAddRequest = account.Permissions.Where(p => p.Title == "CanAddRequest").ToList().Count != 0;
            ViewBag.AccessToControlPanel = account.Permissions.Where(p => p.Title == "AccessToControlPanel").ToList().Count != 0;
            ViewBag.ActiveUser = $"{account.Employee.Surname} {account.Employee.Firstname[0]}. {account.Employee.Patronymic[0]}.";
            return user;
        }

        public ActionResult Index()
        {                   
            var user = PopulateAccountInfo();          
            return View();
        }

        public ActionResult Requests(int service = 0, int page = 1)
        {
            var user = PopulateAccountInfo();
            var requests = requestService.GetRequests();
            RequestListViewModel model = ModelFromData.GetListViewModel(requests, user, service, page, pageSize);
            
            return View(model);
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