using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.Branch;
using WebUI.ViewModels.Category;
using WebUI.ViewModels.Service;

namespace WebUI.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private BranchService branchService = new BranchService();
        private CategoryService categoryService = new CategoryService();
        private ServiceService serviceService = new ServiceService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChooseBranch()
        {
            var branches = branchService.GetBranches();
            BranchesListViewModel model = ModelFromData.GetListViewModel(branches);
            return View(model);
        }

        public ActionResult ChooseCategory(int id)
        {
            var categories = categoryService.GetCategories(id);
            CategoriesListViewModel model = ModelFromData.GetListViewModel(categories);
            return View(model);
        }

        public ActionResult ChooseService(int id)
        {
            var services = serviceService.GetServices();
            ServicesListViewModel model = ModelFromData.GetListViewModel(services);
            return View(model);
        }
    }
}