using BusinessLogic;
using Domain;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using WebUI.Models;
using WebUI.ViewModels.Account;
using WebUI.ViewModels.Permission;
using Domain.Models.ManyToMany;

namespace WebUI.Areas.ControlPanel.Controllers
{
    public class AccountController : Controller
    {
        private AccountService accountService = new AccountService();
        private EmployeeService employeeService = new EmployeeService();
        private SubdivisionService subdvisionService = new SubdivisionService();
        private PermissionService permissionService = new PermissionService();
        private readonly int pageSize = 5;

        public Employee PopulateAccountInfo()
        {
            int id = int.Parse(User.Identity.Name);
            var account = accountService.GetAccountById(id);
            var user = employeeService.GetEmployeeById(account.EmployeeId);
            ViewBag.CanAddRequest = account.Permissions.Where(p => p.Permission.Title == "CanAddRequest").ToList().Count != 0;
            ViewBag.AccessToControlPanel = account.Permissions.Where(p => p.Permission.Title == "AccessToControlPanel").ToList().Count != 0;
            ViewBag.ActiveUser = $"{account.Employee.Surname} {account.Employee.Firstname[0]}. {account.Employee.Patronymic[0]}.";
            return user;
        }

        private void PopulateDropDownList(bool filter = false)
        {
            List<Subdivision> subdivsions = new List<Subdivision>();
            if (filter)
            {
                subdivsions.Add(new Subdivision { Id = 0, Fullname = "Все подразделения", Shortname = "Все" });
            }
            subdivsions.AddRange(subdvisionService.GetSubdivisions());
            ViewBag.Subdivisions = subdivsions;            
        }

        public ActionResult Index(string search = "", int page = 1, int subdivision = 0)
        {
            var user = PopulateAccountInfo();
            var accounts = accountService.GetAccounts();

            PopulateDropDownList(true);
            AccountListViewModel model = ModelFromData.GetListViewModel(accounts, search, subdivision, page, pageSize);
            return View(model);
        }

        public ActionResult Create()
        {
            var user = PopulateAccountInfo();
            PopulateDropDownList();
            var permissions = permissionService.GetPermissions();
            ViewBag.Permissions = permissions;
            AccountViewModel model = new AccountViewModel();
            List<PermissionViewModel> permissionsModel = ModelFromData.GetListViewModel(permissions);
            model.Permissions = permissionsModel;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(AccountViewModel model)
        {
            var user = PopulateAccountInfo();
            PopulateDropDownList();
            Employee employee = DataFromModel.GetData(model.EmployeeModel);
            
            using(var context = new ServiceDeskContext())
            {
                var employees = context.Employees.ToList();
                if (employees.FirstOrDefault(e => e.Surname == employee.Surname && e.Firstname == employee.Firstname) == null)
                {
                    context.Employees.Add(employee);
                }

                Account account = DataFromModel.GetData(model);
                account.DateRegistration = DateTime.Now;
                account.DateChangePassword = DateTime.Now;
                account.LastEnterDateTime = DateTime.Now;
                account.EmployeeId = employee.Id;
                account.Permissions = new List<AccountPermission>();

                //foreach (var permission in model.Permissions)
                //{
                //    if (permission.IsChecked)
                //    {
                //        Permission ps = context.Permissions.FirstOrDefault(p => p.Id == permission.Id);
                //        account.Permissions.Add(ps);
                //    }
                //}

                context.Accounts.Add(account);
                context.SaveChanges();
            }

            
            
            return RedirectToAction("Index", "Account", new { Area = "ControlPanel" });
        }

        public ActionResult Edit(int id)
        {
            var user = PopulateAccountInfo();
            PopulateDropDownList();
            var permissions = permissionService.GetPermissions();
            Account account = accountService.GetAccountById(id);
            AccountViewModel model = ModelFromData.GetViewModel(account, permissions);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(AccountViewModel model)
        {
            var user = PopulateAccountInfo();
            PopulateDropDownList();
            Employee employee = DataFromModel.GetData(model.EmployeeModel);

            using(var context = new ServiceDeskContext())
            {
                if (employee.Id != 0)
                {
                    var employeeToUpdate = context.Employees.SingleOrDefault(e => e.Id == model.EmployeeModel.Id);
                    employeeToUpdate.Surname = model.EmployeeModel.Surname;
                    employeeToUpdate.Firstname = model.EmployeeModel.Firstname;
                    employeeToUpdate.Patronymic = model.EmployeeModel.Patronymic;
                    employeeToUpdate.Post = model.EmployeeModel.Post;
                    employeeToUpdate.Email = model.EmployeeModel.Email;
                    employeeToUpdate.Phone = model.EmployeeModel.Phone;
                    employeeToUpdate.HeadOfUnit = model.EmployeeModel.HeadOfUnit;
                    employeeToUpdate.SubdivisionId = model.EmployeeModel.SubdivisionId;                    
                }
                Account account = context.Accounts.Include(a=>a.Permissions).FirstOrDefault(a => a.Id == model.Id);

                account.Permissions.Clear();


                //account.Permissions = new List<Permission>();

                //foreach (var permission in model.Permissions)
                //{
                //    if (permission.IsChecked)
                //    {
                //        Permission ps = context.Permissions.FirstOrDefault(p => p.Id == permission.Id);
                //        account.Permissions.Add(ps);
                //    }
                //}

                context.SaveChanges();

            }           

            return RedirectToAction("Index", "Account", new { Area = "ControlPanel" });
        }
    }
}