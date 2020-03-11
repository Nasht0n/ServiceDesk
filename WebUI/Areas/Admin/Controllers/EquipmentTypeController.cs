using BusinessLogic;
using Domain.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.EquipmentType;

namespace WebUI.Areas.Admin.Controllers
{
    public class EquipmentTypeController : Controller
    {
        private EquipmentTypeService equipmentTypeService = new EquipmentTypeService();
        private readonly int pageSize = 5;

        public ActionResult EquipmentTypes(string search = "", int page = 1)
        {
            List<EquipmentType> equipmentTypes = equipmentTypeService.GetEquipmentTypes();
            EquipmentTypesListViewModel model = ModelFromData.GetListViewModel(equipmentTypes, search, page, pageSize);
            return View(model);
        }

        public ActionResult AddEquipmentType()
        {
            return View(new EquipmentTypeViewModel());
        }

        [HttpPost]
        public ActionResult AddEquipmentType(EquipmentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                EquipmentType equipmentType = DataFromModel.GetData(model);
                equipmentTypeService.AddEquipmentType(equipmentType);
                return RedirectToAction("EquipmentTypes", "EquipmentType");
            }
            return View();
        }

        public ActionResult EditEquipmentType(int id)
        {
            EquipmentType equipmentType = equipmentTypeService.GetEquipmentTypeById(id);
            EquipmentTypeViewModel model = ModelFromData.GetViewModel(equipmentType);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEquipmentType(EquipmentTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                EquipmentType equipmentType = DataFromModel.GetData(model);
                equipmentTypeService.UpdateEquipmentType(equipmentType);
                return RedirectToAction("EquipmentTypes", "EquipmentType");
            }
            return View();
        }
        public ActionResult DeleteEquipmentType(int id)
        {
            EquipmentType equipmentType = equipmentTypeService.GetEquipmentTypeById(id);
            EquipmentTypeViewModel model = ModelFromData.GetViewModel(equipmentType);
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteEquipmentType(int id, EquipmentTypeViewModel model)
        {
            EquipmentType equipmentType = equipmentTypeService.GetEquipmentTypeById(id);
            equipmentTypeService.DeleteEquipmentType(equipmentType);
            return RedirectToAction("EquipmentTypes", "EquipmentType");
        }
    }
}