using BusinessLogic;
using Domain.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.Branch;

namespace WebUI.Areas.Admin.Controllers
{
    public class BranchController : Controller
    {
        private BranchService branchService = new BranchService();
        private readonly int pageSize = 5;

        public ActionResult Branches(string search = "", int page = 1)
        {
            List<Branch> branches = branchService.GetBranches();
            BranchesListViewModel model = ModelFromData.GetListViewModel(branches, search, page, pageSize);
            return View(model);
        }
        public ActionResult AddBranch()
        {
            return View(new BranchViewModel());
        }

        [HttpPost]
        public ActionResult AddBranch(BranchViewModel model)
        {
            if (ModelState.IsValid)
            {
                Branch branch = DataFromModel.GetData(model);
                branchService.AddBranch(branch);
                return RedirectToAction("Branches", "Branch");
            }
            return View();
        }

        public ActionResult EditBranch(int id)
        {
            Branch branch = branchService.GetBranchById(id);
            BranchViewModel model = ModelFromData.GetViewModel(branch);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditBranch(BranchViewModel model)
        {
            if (ModelState.IsValid)
            {
                Branch branch = DataFromModel.GetData(model);
                branchService.UpdateBranch(branch);
                return RedirectToAction("Branches", "Branch");
            }
            return View();
        }
        public ActionResult DeleteBranch(int id)
        {
            Branch branch = branchService.GetBranchById(id);
            BranchViewModel model = ModelFromData.GetViewModel(branch);
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteBranch(int id, BranchViewModel model)
        {
            Branch branch = branchService.GetBranchById(id);
            branchService.DeleteBranch(branch);
            return RedirectToAction("Branches", "Branch");
        }
    }
}