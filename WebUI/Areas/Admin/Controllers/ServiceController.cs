using BusinessLogic;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.Service;

namespace WebUI.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        private BranchService branchService = new BranchService();
        private ServiceService serviceService = new ServiceService();
        private CategoryService categoryService = new CategoryService();
        private readonly int pageSize = 5;

        public ActionResult Services(string search = "", int page = 1, int category = 0, int branch=0)
        {
            var branches = branchService.GetBranches();
            ViewBag.Branches = branches;      
            if(branch == 0) ViewBag.Categories = categoryService.GetCategories().Where(c => c.BranchId == branches[0].Id);
            else ViewBag.Categories = categoryService.GetCategories().Where(c => c.BranchId == branch);
            List<Service> services = serviceService.GetServices();
            ServicesListViewModel model = ModelFromData.GetListViewModel(services, search, category, branch, page, pageSize);
            return View(model);
        }

        public ActionResult GetCategory(int branch)
        {
            var categories = categoryService.GetCategories().Where(c => c.BranchId == branch).OrderBy(c=>c.Name).ToList();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddService()
        {
            var branches = branchService.GetBranches();
            var categories = categoryService.GetCategories().Where(c => c.BranchId == branches[0].Id);
            ViewBag.Branches = branches;
            ViewBag.Categories = categories;
            return View(new ServiceViewModel());
        }

        [HttpPost]
        public ActionResult AddService(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Service service = DataFromModel.GetData(model);
                serviceService.AddService(service);
                return RedirectToAction("Services", "Service");
            }
            return View();
        }

        public ActionResult EditService(int id)
        {
            ViewBag.Categories = categoryService.GetCategories();
            ViewBag.Branches = branchService.GetBranches();
            Service service = serviceService.GetServiceById(id);
            ServiceViewModel model = ModelFromData.GetViewModel(service);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditService(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                Service service = DataFromModel.GetData(model);
                serviceService.UpdateService(service);
                return RedirectToAction("Services", "Service");
            }
            return View();
        }
        public ActionResult DeleteService(int id)
        {
            Service service = serviceService.GetServiceById(id);
            ServiceViewModel model = ModelFromData.GetViewModel(service);
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteService(int id, ServiceViewModel model)
        {
            Service service = serviceService.GetServiceById(id);
            serviceService.DeleteService(service);
            return RedirectToAction("Services", "Service");
        }
    }
}