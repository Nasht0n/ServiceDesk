using BusinessLogic;
using Domain.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.Campus;

namespace WebUI.Areas.Admin.Controllers
{
    public class CampusController : Controller
    {
        private CampusService campusService = new CampusService();
        private readonly int pageSize = 5;

        public ActionResult Campuses(string search = "", int page = 1)
        {
            List<Campus> campuses = campusService.GetCampuses();
            CampusesListViewModel model = ModelFromData.GetListViewModel(campuses, search, page, pageSize);
            return View(model);
        }

        public ActionResult AddCampus()
        {
            return View(new CampusViewModel());
        }

        [HttpPost]
        public ActionResult AddCampus(CampusViewModel model)
        {
            if (ModelState.IsValid)
            {
                Campus campus = DataFromModel.GetData(model);
                campusService.AddCampus(campus);
                return RedirectToAction("Campuses", "Campus");
            }
            return View();
        }

        public ActionResult EditCampus(int id)
        {
            Campus campus = campusService.GetCampusById(id);
            CampusViewModel model = ModelFromData.GetViewModel(campus);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditCampus(CampusViewModel model)
        {
            if (ModelState.IsValid)
            {
                Campus campus = DataFromModel.GetData(model);
                campusService.UpdateCampus(campus);
                return RedirectToAction("Campuses", "Campus");
            }
            return View();
        }
        public ActionResult DeleteCampus(int id)
        {
            Campus campus = campusService.GetCampusById(id);
            CampusViewModel model = ModelFromData.GetViewModel(campus);
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteCampus(int id, CampusViewModel model)
        {
            Campus campus = campusService.GetCampusById(id);
            campusService.DeleteCampus(campus);
            return RedirectToAction("Campuses", "Campus");
        }
    }
}