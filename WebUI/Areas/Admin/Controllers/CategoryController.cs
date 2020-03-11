using BusinessLogic;
using Domain.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.Category;

namespace WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private BranchService branchService = new BranchService();
        private CategoryService categoryService = new CategoryService();
        private readonly int pageSize = 5;

        public ActionResult Categories(string search = "", int page = 1, int branch = 0)
        {
            ViewBag.Branches = branchService.GetBranches();
            List<Category> categories = categoryService.GetCategories();
            CategoriesListViewModel model = ModelFromData.GetListViewModel(categories, search, branch, page, pageSize);
            return View(model);
        }

        public ActionResult AddCategory()
        {
            ViewBag.Branches = branchService.GetBranches();
            return View(new CategoryViewModel());
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = DataFromModel.GetData(model);
                categoryService.AddCategory(category);
                return RedirectToAction("Categories", "Category");
            }
            return View();
        }

        public ActionResult EditCategory(int id)
        {
            Category category = categoryService.GetCategoryById(id);
            CategoryViewModel model = ModelFromData.GetViewModel(category);
            ViewBag.Branches = branchService.GetBranches();
            return View(model);
        }
        [HttpPost]
        public ActionResult EditCategory(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                Category category = DataFromModel.GetData(model);
                categoryService.UpdateCategory(category);
                return RedirectToAction("Categories", "Category");
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            Category category = categoryService.GetCategoryById(id);
            CategoryViewModel model = ModelFromData.GetViewModel(category);
            return View(model);
        }
        [HttpPost]
        public ActionResult DeleteCategory(int id, CategoryViewModel model)
        {
            Category category = categoryService.GetCategoryById(id);
            categoryService.DeleteCategory(category);
            return RedirectToAction("Categories", "Category");
        }
    }
}