using BusinessLogic.Abstract;
using Domain.Models;
using Domain.Models.ManyToMany;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.SubdivisionExecutorsModel;
using WebUI.ViewModels.SubdivisionModel;

namespace WebUI.Areas.ControlPanel.Controllers
{
    [Authorize]
    public class SubdivisionController : Controller
    {
        private readonly int pageSize = 4;
        private readonly IAccountRepository accountRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly ISubdivisionRepository subdivisionRepository;
        private readonly ISubdivisionLogic subdivisionLogic;
        private readonly ISubdivisionExecutorsRepository subdivisionExecutorsRepository;
        private readonly ISubdivisionExecutorLogic subdivisionExecutorLogic;
        private readonly IAccountLogic accountLogic;
        private readonly IAccountPermissionLogic accountPermissionLogic;

        public SubdivisionController(IAccountRepository accountRepository, 
            IEmployeeRepository employeeRepository, IEmployeeLogic employeeLogic,
            IAccountPermissionRepository accountPermissionRepository, 
            ISubdivisionRepository subdivisionRepository, ISubdivisionLogic subdivisionLogic, 
            ISubdivisionExecutorsRepository subdivisionExecutorsRepository, ISubdivisionExecutorLogic subdivisionExecutorLogic,
            IAccountLogic accountLogic, IAccountPermissionLogic accountPermissionLogic)
        {
            this.accountRepository = accountRepository;
            this.employeeRepository = employeeRepository;
            this.employeeLogic = employeeLogic;
            this.accountPermissionRepository = accountPermissionRepository;
            this.subdivisionRepository = subdivisionRepository;
            this.subdivisionLogic = subdivisionLogic;
            this.subdivisionExecutorsRepository = subdivisionExecutorsRepository;
            this.subdivisionExecutorLogic = subdivisionExecutorLogic;
            this.accountLogic = accountLogic;
            this.accountPermissionLogic = accountPermissionLogic;
        }

        public async Task<Employee> PopulateAccountInfo()
        {
            int id = int.Parse(User.Identity.Name);
            var account = await accountLogic.GetAccount(id);
            var user = await employeeLogic.GetEmployee(account.EmployeeId);
            account.Permissions = await accountPermissionLogic.GetPermissions(account);

            ViewBag.CanAddRequest = account.Permissions.Where(p => p.PermissionId == 1).ToList().Count != 0;
            ViewBag.CanEditRequest = account.Permissions.Where(p => p.PermissionId == 2).ToList().Count != 0;
            ViewBag.CanDeleteRequest = account.Permissions.Where(p => p.PermissionId == 3).ToList().Count != 0;
            ViewBag.AccessToControlPanel = account.Permissions.Where(p => p.PermissionId == 4).ToList().Count != 0;
            ViewBag.ViewRequest = account.Permissions.Where(p => p.PermissionId == 5).ToList().Count != 0;
            ViewBag.ApprovalAllowed = account.Permissions.Where(p => p.PermissionId == 6).ToList().Count != 0;
            ViewBag.GetInWorkRequest = account.Permissions.Where(p => p.PermissionId == 7).ToList().Count != 0;

            ViewBag.ActiveUser = $"{account.Employee.Surname} {account.Employee.Firstname[0]}. {account.Employee.Patronymic[0]}.";
            return user;
        }

        public async Task<ActionResult> Index(string search = "", int page = 1)
        {
            var user = await PopulateAccountInfo();
            var subdivisions = await subdivisionRepository.GetSubdivisions();
            SubdivisionsListViewModel model = ModelFromData.GetListViewModel(subdivisions, search, page, pageSize);
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var user = await PopulateAccountInfo();
            return View(new SubdivisionViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(SubdivisionViewModel model)
        {
            var user = await PopulateAccountInfo();
            Subdivision subdivision = DataFromModel.GetData(model);
            await subdivisionRepository.AddSubdivision(subdivision);
            return RedirectToAction("Index", "Subdivision", new { Area = "ControlPanel" });
        }

        public async Task<ActionResult> Edit(int id)
        {
            var user = await PopulateAccountInfo();            
            var subdivision = await subdivisionLogic.GetSubdivision(id);
            SubdivisionViewModel model = ModelFromData.GetViewModel(subdivision);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(SubdivisionViewModel model)
        {
            var user = await PopulateAccountInfo();
            Subdivision subdivision = DataFromModel.GetData(model);
            await subdivisionRepository.UpdateSubdivision(subdivision);
            return RedirectToAction("Index", "Subdivision", new { Area = "ControlPanel" });
        }
        public async Task<ActionResult> Delete(int id)
        {
            var user = await PopulateAccountInfo();
            var subdivision = await subdivisionLogic.GetSubdivision(id);
            SubdivisionViewModel model = ModelFromData.GetViewModel(subdivision);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, SubdivisionViewModel model)
        {
            var user = await PopulateAccountInfo();
            var subdivision = await subdivisionLogic.GetSubdivision(id);
            await subdivisionRepository.DeleteSubdivision(subdivision);
            return RedirectToAction("Index", "Subdivision", new { Area = "ControlPanel" });
        }

        [HttpGet]
        public async Task<JsonResult> PopulateExecutors(int subdivisionId, int currentId)
        {
            var subdivision = await subdivisionLogic.GetSubdivision(subdivisionId);
            var employees = await employeeLogic.GetEmployees(subdivision);
            var currentSubdivision = await subdivisionLogic.GetSubdivision(currentId);
            var subdivisionExecutors = await subdivisionExecutorLogic.GetExecutors(currentSubdivision);
            List<Employee> temp = new List<Employee>();
            foreach(var employee in employees)
            {
                var exec = subdivisionExecutors.SingleOrDefault(se => se.EmployeeId == employee.Id);
                if (exec == null) temp.Add(employee);
            }
            var result = temp.Select(c => new { Value = c.Id, Text = $"{c.Surname} {c.Firstname}"});
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> DeleteExecutor(int employeeId, int subdivisionId)
        {
            SubdivisionExecutor record = new SubdivisionExecutor { EmployeeId = employeeId, SubdivisionId = subdivisionId };
            await subdivisionExecutorsRepository.DeleteSubdivisionExecutor(record);
            return RedirectToAction("SubdivisionExecutors", "Subdivision", new { Area = "ControlPanel", id = subdivisionId });
        }

        public async Task<ActionResult> SubdivisionExecutors(int id)
        {
            await PopulateAccountInfo();
            SubdivisionExecutorsListViewModel model = new SubdivisionExecutorsListViewModel();
            var subdivision = await subdivisionLogic.GetSubdivision(id);
            model.SubdivisionModel = ModelFromData.GetViewModel(subdivision);
            var executors = await subdivisionExecutorLogic.GetExecutors(subdivision);
            model.ExecutorsModel = ModelFromData.GetViewModel(executors);
            var subdivisions = await subdivisionRepository.GetSubdivisions();
            model.Subdivisions = new SelectList(subdivisions, "Id", "Fullname");
            if (model.SelectedSubdivision.HasValue)
            {
                var selSubdivision = await subdivisionLogic.GetSubdivision(model.SelectedSubdivision.Value);
                var employees = await employeeLogic.GetEmployees(selSubdivision);
                model.Executors = new SelectList(employees, "Id", "Surname");
            }
            else
            {
                model.Executors = new SelectList(Enumerable.Empty<SelectListItem>());
            }         
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> SubdivisionExecutors(SubdivisionExecutorsListViewModel model)
        {
            if (model.SelectedSubdivision.HasValue && model.SelectedExecutor.HasValue)
            {
                SubdivisionExecutor record = new SubdivisionExecutor { EmployeeId = model.SelectedExecutor.Value, SubdivisionId = model.SubdivisionModel.Id };
                await subdivisionExecutorsRepository.AddSubdivisionExecutor(record);
                return RedirectToAction("SubdivisionExecutors", "Subdivision", new { Area = "ControlPanel", id = model.SubdivisionModel.Id });
            }
            return View(model);
        }
    }
}