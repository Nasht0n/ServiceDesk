using BusinessLogic.Abstract;
using Domain.Models;
using Domain.Models.ManyToMany;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.ExecutorGroupMembers;
using WebUI.ViewModels.ExecutorGroupModel;

namespace WebUI.Areas.ControlPanel.Controllers
{
    [Authorize]
    public class ExecutorGroupController : Controller
    {
        private readonly IAccountRepository accountRepository;
        private readonly IAccountPermissionRepository accountPermissionRepository;
        private readonly IExecutorGroupRepository executorGroupRepository;
        private readonly IExecutorGroupLogic executorGroupLogic;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IEmployeeLogic employeeLogic;
        private readonly ISubdivisionRepository subdivisionRepository;
        private readonly ISubdivisionLogic subdivisionLogic;
        private readonly IExecutorGroupMembersRepository executorGroupMembersRepository;
        private readonly IExecutorGroupMemberLogic executorGroupMemberLogic;
        private readonly int pageSize = 5;

        public ExecutorGroupController(IAccountRepository accountRepository, IAccountPermissionRepository accountPermissionRepository, 
            IExecutorGroupRepository executorGroupRepository, IExecutorGroupLogic executorGroupLogic,
            IEmployeeRepository employeeRepository, IEmployeeLogic employeeLogic,
            ISubdivisionRepository subdivisionRepository, ISubdivisionLogic subdivisionLogic,
            IExecutorGroupMembersRepository executorGroupMembersRepository, IExecutorGroupMemberLogic executorGroupMemberLogic)
        {
            this.accountRepository = accountRepository;
            this.accountPermissionRepository = accountPermissionRepository;
            this.executorGroupRepository = executorGroupRepository;
            this.executorGroupLogic = executorGroupLogic;
            this.employeeRepository = employeeRepository;
            this.employeeLogic = employeeLogic;
            this.subdivisionRepository = subdivisionRepository;
            this.subdivisionLogic = subdivisionLogic;
            this.executorGroupMembersRepository = executorGroupMembersRepository;
            this.executorGroupMemberLogic = executorGroupMemberLogic;
        }


        public async Task<Employee> PopulateAccountInfo()
        {
            int id = int.Parse(User.Identity.Name);
            var account = (await accountRepository.GetAccounts()).Where(a => a.Id == id).FirstOrDefault();
            var user = await employeeLogic.GetEmployeeById(account.EmployeeId);
            account.Permissions = (await accountPermissionRepository.GetAccountPermissions()).Where(ap => ap.AccountId == account.Id).ToList();
            ViewBag.CanAddRequest = account.Permissions.Where(p => p.PermissionId == 1).ToList().Count != 0;
            ViewBag.AccessToControlPanel = account.Permissions.Where(p => p.PermissionId == 4).ToList().Count != 0;
            ViewBag.ActiveUser = $"{account.Employee.Surname} {account.Employee.Firstname[0]}. {account.Employee.Patronymic[0]}.";
            return user;
        }

        public async Task<ActionResult> Index(string search = "", int page = 1)
        {
            var user = await PopulateAccountInfo();
            List<ExecutorGroup> executorGroups = await executorGroupRepository.GetExecutorGroups();
            ExecutorGroupsListViewModel model = ModelFromData.GetListViewModel(executorGroups, search, page, pageSize);
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var user = await PopulateAccountInfo();
            return View(new ExecutorGroupViewModel());
        }
        [HttpPost]
        public async Task<ActionResult> Create(ExecutorGroupViewModel model)
        {   
            if (ModelState.IsValid)
            {
                var executorGroup = DataFromModel.GetData(model);
                await executorGroupRepository.AddExecutorGroup(executorGroup);
                return RedirectToAction("Index", "ExecutorGroup", new { Area = "ControlPanel" });
            }
            return View();
        }
        public async Task<ActionResult> Edit(int id)
        {
            var user = await PopulateAccountInfo();
            var executorGroup = await executorGroupLogic.GetExecutorGroup(id);
            ExecutorGroupViewModel model = ModelFromData.GetViewModel(executorGroup);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(ExecutorGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var executorGroup = DataFromModel.GetData(model);
                await executorGroupRepository.UpdateExecutorGroup(executorGroup);
                return RedirectToAction("Index", "ExecutorGroup", new { Area = "ControlPanel" });
            }
            return View();
        }
        public async Task<ActionResult> Delete(int id)
        {
            var user = await PopulateAccountInfo();
            var executorGroup = await executorGroupLogic.GetExecutorGroup(id);
            ExecutorGroupViewModel model = ModelFromData.GetViewModel(executorGroup);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, ExecutorGroupViewModel model)
        {
            var executorGroup = await executorGroupLogic.GetExecutorGroup(id);
            await executorGroupRepository.DeleteExecutorGroup(executorGroup);
            return RedirectToAction("Index", "ExecutorGroup", new { Area = "ControlPanel" });
        }

        [HttpGet]
        public async Task<JsonResult> PopulateExecutors(int subdivisionId, int currentId)
        {
            var employees = await employeeLogic.GetEmployees(subdivisionId);
            var executorGroupMembers = await executorGroupMemberLogic.GetExecutorGroupMembers(currentId);
            List<Employee> temp = new List<Employee>();
            foreach (var employee in employees)
            {
                var exec = executorGroupMembers.SingleOrDefault(se => se.EmployeeId == employee.Id);
                if (exec == null) temp.Add(employee);
            }
            var result = temp.Select(c => new { Value = c.Id, Text = $"{c.Surname} {c.Firstname}" });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GroupMembers(int id)
        {
            await PopulateAccountInfo();
            ExecutorGroupMembersListViewModel model = new ExecutorGroupMembersListViewModel();
            var executorGroup = await executorGroupLogic.GetExecutorGroup(id);
            model.ExecutorGroupModel = ModelFromData.GetViewModel(executorGroup);
            var subdivisions = await subdivisionRepository.GetSubdivisions();
            model.Subdivisions = new SelectList(subdivisions, "Id", "Fullname");
            if (model.SelectedSubdivision.HasValue)
            {
                var employees = await employeeLogic.GetEmployees(model.SelectedSubdivision.Value);
                model.Executors = new SelectList(employees, "Id", "Surname");
            }
            else
            {
                model.Executors = new SelectList(Enumerable.Empty<SelectListItem>());
            }
            var executorGroupMembers = await executorGroupMemberLogic.GetExecutorGroupMembers(id);
            model.ExecutorGroupMemberModel = ModelFromData.GetViewModel(executorGroupMembers);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> GroupMembers(ExecutorGroupMembersListViewModel model)
        {
            if(model.SelectedSubdivision.HasValue && model.SelectedExecutor.HasValue)
            {
                ExecutorGroupMember member = new ExecutorGroupMember { 
                    EmployeeId = model.SelectedExecutor.Value,
                    ExecutorGroupId = model.ExecutorGroupModel.Id
                };
                await executorGroupMembersRepository.AddExecutorGroupMember(member);
            }
            return RedirectToAction("GroupMembers", "ExecutorGroup",new { Area = "ControlPanel" });
        }

        public async Task<ActionResult> DeleteExecutor(int employeeId, int executorGroupId)
        {
            ExecutorGroupMember record = new ExecutorGroupMember { EmployeeId = employeeId, ExecutorGroupId = executorGroupId };
            await executorGroupMembersRepository.DeleteExecutorGroupMember(record);
            return RedirectToAction("GroupMembers", "ExecutorGroup", new { Area = "ControlPanel", id = executorGroupId });
        }
    }
}