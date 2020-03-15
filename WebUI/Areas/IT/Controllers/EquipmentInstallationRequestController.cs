using BusinessLogic;
using BusinessLogic.LifeCycles;
using BusinessLogic.Requests;
using System.Web.Mvc;
using WebUI.ViewModels.Requests.IT.Equipments;

namespace WebUI.Areas.IT.Controllers
{
    public class EquipmentInstallationRequestController : Controller
    {
        private EquipmentInstallationRequestLifeCycleService lifeCycleService = new EquipmentInstallationRequestLifeCycleService();
        private EquipmentInstallationRequestService requestService = new EquipmentInstallationRequestService();

        private CampusService campusService = new CampusService();
        private PriorityService priorityService = new PriorityService();

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Campuses = campusService.GetCampuses();
            ViewBag.Priorities = priorityService.GetPriorities();
            return View(new EquipmentInstallationRequestViewModel());
        }
        [HttpPost]
        public ActionResult Create(EquipmentInstallationRequestViewModel model)
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View(new EquipmentInstallationRequestViewModel());
        }
        [HttpPost]
        public ActionResult Edit(EquipmentInstallationRequestViewModel model)
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View(new EquipmentInstallationRequestViewModel());
        }
        [HttpPost]
        public ActionResult Delete(EquipmentInstallationRequestViewModel model)
        {
            return View();
        }
    }
}