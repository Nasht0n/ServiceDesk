using BusinessLogic.LifeCycles;
using BusinessLogic.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.ViewModels.Requests.IT.Equipments;

namespace WebUI.Areas.IT.Controllers
{
    public class EquipmentInstallationRequestController : Controller
    {
        private EquipmentInstallationRequestLifeCycleService lifeCycleService = new EquipmentInstallationRequestLifeCycleService();
        private EquipmentInstallationRequestService requestService = new EquipmentInstallationRequestService();

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Create()
        {
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