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
        private SubdivisionService subdivisionService = new SubdivisionService();
        private readonly int pageSize = 5;

        public ActionResult AddSubdivision()
        {
            return View(new SubdivisionViewModel());
        }

        public ActionResult Subdivisions(string search = "", int page = 1)
        {             
            List<Subdivision> subdivisions = subdivisionService.GetSubdivisions();
            SubdivisionsListViewModel model = ModelFromData.GetListViewModel(subdivisions, search, page, pageSize);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddSubdivision(SubdivisionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Subdivision subdivision = DataFromModel.GetData(model);
                subdivisionService.AddSubdivision(subdivision);
                return RedirectToAction("Subdivisions", "Subdivision");
            }
            return View();
        }

        public ActionResult EditSubdivision(int id)
        {
            Subdivision subdivision = subdivisionService.GetSubdivisionById(id);
            SubdivisionViewModel model = ModelFromData.GetViewModel(subdivision);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditSubdivision(SubdivisionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Subdivision subdivision = DataFromModel.GetData(model);
                subdivisionService.UpdateSubdivision(subdivision);
                return RedirectToAction("Subdivisions", "Subdivision");
            }
            return View();
        }
        public ActionResult DeleteSubdivision(int id)
        {
            Subdivision subdivision = subdivisionService.GetSubdivisionById(id);
            SubdivisionViewModel model = ModelFromData.GetViewModel(subdivision);
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteSubdivision(int id, SubdivisionViewModel model)
        {
            Subdivision subdivision = subdivisionService.GetSubdivisionById(id);
            subdivisionService.DeleteSubdivision(subdivision);
            return RedirectToAction("Subdivisions", "Subdivision");
        }
    }
}