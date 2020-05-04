using BusinessLogic.Abstract;
using Domain.Models;
using Domain.Models.ManyToMany;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.ServiceModel;
using WebUI.ViewModels.ServicesApproversModel;
using WebUI.ViewModels.ServicesExecutorGroupsModel;

namespace WebUI.Areas.ControlPanel.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IBranchRepository branchRepository;
        private readonly IBranchLogic branchLogic;
        private readonly ICategoryRepository categoryRepository;
        private readonly ICategoryLogic categoryLogic;
        private readonly IServiceRepository serviceRepository;
        private readonly IServiceLogic serviceLogic;
        private readonly IExecutorGroupRepository executorGroupRepository;
        private readonly IExecutorGroupLogic executorGroupLogic;
        private readonly IServicesExecutorGroupsRepository servicesExecutorGroupsRepository;
        private readonly IServicesExecutorGroupsLogic servicesExecutorGroupsLogic;
        private readonly IServicesApproversRepository servicesApproversRepository;
        private readonly IServicesApproversLogic servicesApproversLogic;
        private readonly ISubdivisionRepository subdivisionRepository;
        private readonly ISubdivisionLogic subdivisionLogic;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly int pageSize = 5;

        public ServiceController(IAccountRepository accountRepository, IAccountLogic accountLogic,
            IEmployeeRepository employeeRepository, IEmployeeLogic employeeLogic,
            IBranchRepository branchRepository, IBranchLogic branchLogic,
            ICategoryRepository categoryRepository, ICategoryLogic categoryLogic,
            IServiceRepository serviceRepository, IServiceLogic serviceLogic,
            IExecutorGroupRepository executorGroupRepository, IExecutorGroupLogic executorGroupLogic,
            IServicesExecutorGroupsRepository servicesExecutorGroupsRepository, IServicesExecutorGroupsLogic servicesExecutorGroupsLogic,
            IServicesApproversRepository servicesApproversRepository, IServicesApproversLogic servicesApproversLogic,
            ISubdivisionRepository subdivisionRepository, ISubdivisionLogic subdivisionLogic,
            IAccountPermissionRepository accountPermissionRepository, IAccountPermissionLogic accountPermissionLogic)
        {
            this.accountRepository = accountRepository;
            this.accountLogic = accountLogic;
            this.employeeRepository = employeeRepository;
            this.employeeLogic = employeeLogic;
            this.branchRepository = branchRepository;
            this.branchLogic = branchLogic;
            this.categoryRepository = categoryRepository;
            this.categoryLogic = categoryLogic;
            this.serviceRepository = serviceRepository;
            this.serviceLogic = serviceLogic;
            this.executorGroupRepository = executorGroupRepository;
            this.executorGroupLogic = executorGroupLogic;
            this.servicesExecutorGroupsRepository = servicesExecutorGroupsRepository;
            this.servicesExecutorGroupsLogic = servicesExecutorGroupsLogic;
            this.servicesApproversRepository = servicesApproversRepository;
            this.servicesApproversLogic = servicesApproversLogic;
            this.subdivisionRepository = subdivisionRepository;
            this.subdivisionLogic = subdivisionLogic;
            this.accountPermissionRepository = accountPermissionRepository;
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
        [HttpGet]
        public async Task<JsonResult> PopulateCategories(int branchId)
        {
            var categories = (await categoryRepository.GetCategories())
                .Where(c => c.BranchId == branchId)
                .Select(c => new { Value = c.Id, Text = c.Name });
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Index(string search = "", int branch = 0, int category = 0, int page = 1)
        {
            var user = await PopulateAccountInfo();
            var services = await serviceRepository.GetServices();
            ServicesListViewModel model = ModelFromData.GetListViewModel(services, search, page, branch, category, pageSize);
            var branches = await branchRepository.GetBranches();
            model.BranchList = new SelectList(branches, "Id", "Fullname");
            if (model.SelectedBranch != 0)
            {
                var _branch = await branchLogic.GetBranch(model.SelectedBranch);
                var categories = await categoryLogic.GetCategories(_branch);
                model.CategoryList = new SelectList(categories, "Id", "Name");
            }
            else
            {
                model.CategoryList = new SelectList(Enumerable.Empty<SelectListItem>());
            }
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var user = await PopulateAccountInfo();
            ServiceViewModel model = new ServiceViewModel();
            var branches = await branchRepository.GetBranches();
            model.BranchList = new SelectList(branches, "Id", "Fullname");
            if (model.SelectedBranch.HasValue)
            {
                var branch = await branchLogic.GetBranch(model.SelectedBranch.Value);
                var categories = await categoryLogic.GetCategories(branch);
                model.CategoryList = new SelectList(categories, "Id", "Name");
            }
            else
            {
                model.CategoryList = new SelectList(Enumerable.Empty<SelectListItem>());
            }
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Create(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = DataFromModel.GetData(model);
                await serviceRepository.AddService(service);
                return RedirectToAction("Index", "Service", new { Area = "ControlPanel" });
            }
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            var user = await PopulateAccountInfo();
            var service = await serviceLogic.GetService(id);
            ServiceViewModel model = ModelFromData.GetViewModel(service);

            var branches = await branchRepository.GetBranches();
            model.BranchList = new SelectList(branches, "Id", "Fullname", model.SelectedBranch);
            var branch = await branchLogic.GetBranch(model.SelectedBranch.Value);
            var categories = await categoryLogic.GetCategories(branch);
            model.CategoryList = new SelectList(categories, "Id", "Name", model.SelectedCategory);

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = DataFromModel.GetData(model);
                await serviceRepository.UpdateService(service);
                return RedirectToAction("Index", "Service", new { Area = "ControlPanel" });
            }
            return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            var user = await PopulateAccountInfo();
            var service = await serviceLogic.GetService(id);
            ServiceViewModel model = ModelFromData.GetViewModel(service);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, ServiceViewModel model)
        {
            var service = await serviceLogic.GetService(id);
            await serviceRepository.DeleteService(service);
            return RedirectToAction("Index", "Service", new { Area = "ControlPanel" });
        }

        public async Task<ActionResult> ServicesExecutorGroups(int id)
        {
            await PopulateAccountInfo();
            ServicesExecutorGroupsListViewModel model = new ServicesExecutorGroupsListViewModel();
            var service = await serviceLogic.GetService(id);
            model.ServiceModel = ModelFromData.GetViewModel(service);
            var executorGroups = await executorGroupRepository.GetExecutorGroups();
            model.ExecutorGroups = new SelectList(executorGroups, "Id", "Name");
            var serviceExecutorGroups = await servicesExecutorGroupsLogic.GetServicesExecutorGroups(service);
            model.ExecutorGroupsListModel = ModelFromData.GetViewModel(serviceExecutorGroups);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> ServicesExecutorGroups(ServicesExecutorGroupsListViewModel model)
        {
            if (model.SelectedExecutorGroup.HasValue)
            {
                ServicesExecutorGroup group = new ServicesExecutorGroup
                {
                    ServiceId = model.ServiceModel.Id,
                    ExecutorGroupId = model.SelectedExecutorGroup.Value
                };
                await servicesExecutorGroupsRepository.Add(group);
            }
            return RedirectToAction("ServicesExecutorGroups", "Service", new { Area = "ControlPanel", id = model.ServiceModel.Id });
        }

        public async Task<ActionResult> DeleteExecutorGroup(int executorGroupId, int serviceId)
        {
            ServicesExecutorGroup servicesExecutorGroup = new ServicesExecutorGroup { ServiceId = serviceId, ExecutorGroupId = executorGroupId };
            await servicesExecutorGroupsRepository.Delete(servicesExecutorGroup);
            return RedirectToAction("ServicesExecutorGroups", "Service", new { Area = "ControlPanel", id = serviceId });
        }

        [HttpGet]
        public async Task<JsonResult> PopulateEmployees(int subdivisionId, int currentId)
        {
            var subdivision = await subdivisionLogic.GetSubdivision(subdivisionId);
            var employees = await employeeLogic.GetEmployees(subdivision);
            var service = await serviceLogic.GetService(currentId);
            var serviceApprovers = await servicesApproversLogic.GetServicesApprovers(service);
            List<Employee> temp = new List<Employee>();
            foreach (var employee in employees)
            {
                var exec = serviceApprovers.SingleOrDefault(se => se.EmployeeId == employee.Id);
                if (exec == null) temp.Add(employee);
            }
            var result = temp.Select(c => new { Value = c.Id, Text = $"{c.Surname} {c.Firstname}" });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ServiceApprovers(int id)
        {
            await PopulateAccountInfo();
            ServicesApproversListViewModel model = new ServicesApproversListViewModel();
            var service = await serviceLogic.GetService(id);
            model.ServiceModel = ModelFromData.GetViewModel(service);
            var subdivisions = await subdivisionRepository.GetSubdivisions();
            model.Subdivisions = new SelectList(subdivisions, "Id", "Fullname");
            if (model.SelectedSubdivision.HasValue)
            {
                var subdivision = await subdivisionLogic.GetSubdivision(model.SelectedSubdivision.Value);
                var employees = await employeeLogic.GetEmployees(subdivision);
                model.Employees = new SelectList(employees, "Id", "Surname");
            }
            else
            {
                model.Employees = new SelectList(Enumerable.Empty<SelectListItem>());
            }
            var serviceApprovers = await servicesApproversLogic.GetServicesApprovers(service);
            model.ApproversListModel = ModelFromData.GetViewModel(serviceApprovers);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> ServiceApprovers(ServicesApproversListViewModel model)
        {
            if (model.SelectedEmployee.HasValue && model.SelectedSubdivision.HasValue)
            {
                ServicesApprover servicesApprover = new ServicesApprover { 
                    EmployeeId = model.SelectedEmployee.Value,
                    ServiceId = model.ServiceModel.Id
                };
                await servicesApproversRepository.AddServicesApprover(servicesApprover);
            }
            return RedirectToAction("ServiceApprovers", "Service", new { Area = "ControlPanel", id = model.ServiceModel.Id });
        }

        public async Task<ActionResult> DeleteServiceApprover(int approverId, int serviceId)
        {
            ServicesApprover servicesApprover = new ServicesApprover { EmployeeId = approverId, ServiceId = serviceId };
            await servicesApproversRepository.DeleteServicesApprover(servicesApprover);
            return RedirectToAction("ServiceApprovers", "Service", new { Area = "ControlPanel", id = serviceId });
        }
    }
}