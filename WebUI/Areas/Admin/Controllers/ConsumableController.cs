using BusinessLogic;
using Domain.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.Consumable;

namespace WebUI.Areas.Admin.Controllers
{
    public class ConsumableController : Controller
    {
        private ConsumableService consumableService = new ConsumableService();
        private readonly int pageSize = 5;

        public ActionResult Consumables(string search = "", int page = 1)
        {
            List<Consumable> consumables = consumableService.GetConsumables();
            ConsumablesListViewModel model = ModelFromData.GetListViewModel(consumables, search, page, pageSize);
            return View(model);
        }

        public ActionResult AddConsumable()
        {
            return View(new ConsumableViewModel());
        }

        [HttpPost]
        public ActionResult AddConsumable(ConsumableViewModel model)
        {
            if (ModelState.IsValid)
            {
                Consumable consumable = DataFromModel.GetData(model);
                consumableService.AddConsumable(consumable);
                return RedirectToAction("Consumables", "Consumable");
            }
            return View();
        }

        public ActionResult EditConsumable(int id)
        {
            Consumable consumable = consumableService.GetConsumableById(id);
            ConsumableViewModel model = ModelFromData.GetViewModel(consumable);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditConsumable(ConsumableViewModel model)
        {
            if (ModelState.IsValid)
            {
                Consumable consumable = DataFromModel.GetData(model);
                consumableService.UpdateConsumable(consumable);
                return RedirectToAction("Consumables", "Consumable");
            }
            return View();
        }
        public ActionResult DeleteConsumable(int id)
        {
            Consumable consumable = consumableService.GetConsumableById(id);
            ConsumableViewModel model = ModelFromData.GetViewModel(consumable);
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteConsumable(int id, ConsumableViewModel model)
        {
            Consumable consumable = consumableService.GetConsumableById(id);
            consumableService.DeleteConsumable(consumable);
            return RedirectToAction("Consumables", "Consumable");
        }
    }
}