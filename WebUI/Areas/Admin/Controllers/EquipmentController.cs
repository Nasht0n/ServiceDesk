using BusinessLogic;
using Domain.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.Equipment;

namespace WebUI.Areas.Admin.Controllers
{
    public class EquipmentController : Controller
    {
        private EquipmentService equipmentService = new EquipmentService();
        private EquipmentTypeService equipmentTypeService = new EquipmentTypeService();
        private readonly int pageSize = 5;

        public ActionResult Equipments(string search = "", int page = 1, int equipmentType = 0)
        {
            ViewBag.EquipmentTypes = equipmentTypeService.GetEquipmentTypes();
            List<Equipment> equipments = equipmentService.GetEquipments();
            EquipmentsListViewModel model = ModelFromData.GetListViewModel(equipments, search, equipmentType, page, pageSize);
            return View(model);
        }

        public ActionResult AddEquipment()
        {
            ViewBag.EquipmentTypes = equipmentTypeService.GetEquipmentTypes();
            return View(new EquipmentViewModel());
        }

        [HttpPost]
        public ActionResult AddEquipment(EquipmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Equipment equipment = DataFromModel.GetData(model);
                equipmentService.AddEquipment(equipment);
                return RedirectToAction("Equipments", "Equipment");
            }
            return View();
        }

        public ActionResult EditEquipment(int id)
        {
            ViewBag.EquipmentTypes = equipmentTypeService.GetEquipmentTypes();
            Equipment equipment = equipmentService.GetEquipmentById(id);
            EquipmentViewModel model = ModelFromData.GetViewModel(equipment);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEquipment(EquipmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Equipment equipment = DataFromModel.GetData(model);
                equipmentService.UpdateEquipment(equipment);
                return RedirectToAction("Equipments", "Equipment");
            }
            return View();
        }
        public ActionResult DeleteEquipment(int id)
        {
            Equipment equipment = equipmentService.GetEquipmentById(id);
            EquipmentViewModel model = ModelFromData.GetViewModel(equipment);
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteEquipment(int id, EquipmentViewModel model)
        {
            Equipment equipment = equipmentService.GetEquipmentById(id);
            equipmentService.DeleteEquipment(equipment);
            return RedirectToAction("Equipments", "Equipment");
        }
    }
}