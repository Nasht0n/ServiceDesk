using BusinessLogic;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.ControlPanel.Controllers
{
    public class DeskController : Controller
    {
        private AccountService accountService = new AccountService();
        private EmployeeService employeeService = new EmployeeService();

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

        public ActionResult Index()
        {
            var user = PopulateAccountInfo();
            return View();
        }
    }
}