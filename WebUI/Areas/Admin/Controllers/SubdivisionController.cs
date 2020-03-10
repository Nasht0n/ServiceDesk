using BusinessLogic;
using Domain.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.Subdivision;

namespace WebUI.Areas.Admin.Controllers
{
    public class SubdivisionController : Controller
    {
        private SubdvisionService subdvisionService = new SubdvisionService();
        private readonly int pageSize = 5;

        public ActionResult AddSubdivision()
        {
            return View(new SubdivisionViewModel());
        }

        public ActionResult Subdivisions(string search = "", int page = 1)
        {             
            List<Subdivision> subdivisions = subdvisionService.GetSubdivisions();
            SubdivisionsListViewModel model = ModelFromData.GetListViewModel(subdivisions, search, page, pageSize);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSubdivision(SubdivisionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Subdivision subdivision = DataFromModel.GetData(model);
                subdvisionService.AddSubdivision(subdivision);
                return RedirectToAction("Subdivisions", "Subdivision");
            }
            return View();
        }

        public ActionResult EditSubdivision(int id)
        {
            Subdivision subdivision = subdvisionService.GetSubdivisionById(id);
            SubdivisionViewModel model = ModelFromData.GetViewModel(subdivision);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditSubdivision(SubdivisionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Subdivision subdivision = DataFromModel.GetData(model);
                subdvisionService.UpdateSubdivision(subdivision);
                return RedirectToAction("Subdivisions", "Subdivision");
            }
            return View();
        }
        public ActionResult DeleteSubdivision(int id)
        {
            Subdivision subdivision = subdvisionService.GetSubdivisionById(id);
            SubdivisionViewModel model = ModelFromData.GetViewModel(subdivision);
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteSubdivision(int id, SubdivisionViewModel model)
        {
            Subdivision subdivision = subdvisionService.GetSubdivisionById(id);
            subdvisionService.DeleteSubdivision(subdivision);
            return RedirectToAction("Subdivisions", "Subdivision");
        }
    }
}