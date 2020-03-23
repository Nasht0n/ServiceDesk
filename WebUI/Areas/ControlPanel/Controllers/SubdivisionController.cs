using BusinessLogic;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.Subdivision;

namespace WebUI.Areas.ControlPanel.Controllers
{
    public class SubdivisionController : Controller
    {
        private AccountService accountService = new AccountService();
        private EmployeeService employeeService = new EmployeeService();
        private SubdivisionService subdivisionService = new SubdivisionService();
        private readonly int pageSize = 5;

        public Employee PopulateAccountInfo()
        {
            int id = int.Parse(User.Identity.Name);
            var account = accountService.GetAccountById(id);
            var user = employeeService.GetEmployeeById(account.EmployeeId);
            ViewBag.CanAddRequest = account.Permissions.Where(p => p.Title == "CanAddRequest").ToList().Count != 0;
            ViewBag.AccessToControlPanel = account.Permissions.Where(p => p.Title == "AccessToControlPanel").ToList().Count != 0;
            ViewBag.ActiveUser = $"{account.Employee.Surname} {account.Employee.Firstname[0]}. {account.Employee.Patronymic[0]}.";
            return user;
        }

        public ActionResult Index(string search = "", int page = 1)
        {
            var user = PopulateAccountInfo();
            List<Subdivision> subdivisions = subdivisionService.GetSubdivisions();
            SubdivisionsListViewModel model = ModelFromData.GetListViewModel(subdivisions, search, page, pageSize);
            return View(model);
        }

        public ActionResult Create()
        {
            var user = PopulateAccountInfo();
            return View(new SubdivisionViewModel());
        }

        [HttpPost]
        public ActionResult Create(SubdivisionViewModel model)
        {
            var user = PopulateAccountInfo();
            Subdivision subdivision = DataFromModel.GetData(model);
            subdivisionService.AddSubdivision(subdivision);
            return RedirectToAction("Index", "Subdivision");
        }

        public ActionResult Edit(int id)
        {
            var user = PopulateAccountInfo();
            Subdivision subdivision = subdivisionService.GetSubdivisionById(id);
            SubdivisionViewModel model = ModelFromData.GetViewModel(subdivision);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(SubdivisionViewModel model)
        {
            var user = PopulateAccountInfo();
            Subdivision subdivision = DataFromModel.GetData(model);
            subdivisionService.UpdateSubdivision(subdivision);
            return RedirectToAction("Index", "Subdivision");
        }
        public ActionResult Delete(int id)
        {
            var user = PopulateAccountInfo();
            Subdivision subdivision = subdivisionService.GetSubdivisionById(id);
            SubdivisionViewModel model = ModelFromData.GetViewModel(subdivision);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id, SubdivisionViewModel model)
        {
            var user = PopulateAccountInfo();
            Subdivision subdivision = subdivisionService.GetSubdivisionById(id);
            subdivisionService.DeleteSubdivision(subdivision);
            return RedirectToAction("Index", "Subdivision");
        }
    }
}