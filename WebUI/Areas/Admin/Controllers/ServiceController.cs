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
        private ServiceService serviceService = new ServiceService();
        private CategoryService categoryService = new CategoryService();
        private readonly int pageSize = 5;

        public ActionResult Services(string search = "", int page = 1, int category = 0)
        {
            ViewBag.Categories = categoryService.GetCategories();
            List<Service> services = serviceService.GetServices();
            ServicesListViewModel model = ModelFromData.GetListViewModel(services, search, category, page, pageSize);
            return View(model);
        }

        public ActionResult AddService()
        {
            ViewBag.Categories = categoryService.GetCategories();
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