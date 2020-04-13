using BusinessLogic.Abstract;
using BusinessLogic.Abstract.Branches.IT.Equipments;
using BusinessLogic.Abstract.Branches.IT.Equipments.LifeCycles;
using BusinessLogic.Abstract.Branches.IT.Equipments.Requests;
using Domain.Models;
using Domain.Models.Requests.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Models.Enum;
using WebUI.Models.Helpers;
using WebUI.ViewModels.Requests.IT.Equipments;

namespace WebUI.Areas.IT.Controllers
{
    public class ComponentReplaceRequestController : Controller
    {
        private const int SERVICE_ID = 5;
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly ICampusLogic campusLogic;
        private readonly IPriorityLogic priorityLogic;
        private readonly IEquipmentTypeLogic equipmentTypeLogic;
        private readonly IServiceLogic serviceLogic;
        private readonly ISubdivisionLogic subdivisionLogic;
        private readonly IComponentReplaceRequestLogic requestLogic;
        private readonly IComponentReplaceRequestLifeCycleLogic lifeCycleLogic;
        private readonly IReplaceComponentsLogic componentsLogic;

        public ComponentReplaceRequestController(IAccountLogic accountLogic, IEmployeeLogic employeeLogic, IAccountPermissionLogic accountPermissionLogic, 
            ICampusLogic campusLogic, IPriorityLogic priorityLogic, IEquipmentTypeLogic equipmentTypeLogic, IServiceLogic serviceLogic, ISubdivisionLogic subdivisionLogic,
            IComponentReplaceRequestLogic requestLogic, IComponentReplaceRequestLifeCycleLogic lifeCycleLogic, IReplaceComponentsLogic componentsLogic)
        {
            this.accountLogic = accountLogic;
            this.employeeLogic = employeeLogic;
            this.accountPermissionLogic = accountPermissionLogic;
            this.campusLogic = campusLogic;
            this.priorityLogic = priorityLogic;
            this.equipmentTypeLogic = equipmentTypeLogic;
            this.serviceLogic = serviceLogic;
            this.subdivisionLogic = subdivisionLogic;
            this.requestLogic = requestLogic;
            this.lifeCycleLogic = lifeCycleLogic;
            this.componentsLogic = componentsLogic;
        }

        public async Task<Employee> PopulateAccountInfo()
        {
            int id = int.Parse(User.Identity.Name);
            var account = await accountLogic.GetAccountById(id);
            var user = await employeeLogic.GetEmployeeById(account.EmployeeId);
            account.Permissions = await accountPermissionLogic.GetPermissions(account.Id);
            ViewBag.CanAddRequest = account.Permissions.Where(p => p.PermissionId == 1).ToList().Count != 0;
            ViewBag.AccessToControlPanel = account.Permissions.Where(p => p.PermissionId == 4).ToList().Count != 0;
            ViewBag.ActiveUser = $"{account.Employee.Surname} {account.Employee.Firstname[0]}. {account.Employee.Patronymic[0]}.";
            return user;
        }

        private async Task PopulateDropDownList(ComponentReplaceRequestViewModel model)
        {
            var campuses = await campusLogic.GetCampuses();
            var priorities = await priorityLogic.GetPriorities();
            var equipmentTypes = await equipmentTypeLogic.GetEquipmentTypes();

            if(model.SelectedPriority.HasValue) 
                model.Priorities = new SelectList(priorities, "Id", "Fullname", model.SelectedPriority.Value);
            else 
                model.Priorities = new SelectList(priorities, "Id", "Fullname");

            if(model.SelectedCampus.HasValue)
                model.Campuses = new SelectList(campuses, "Id", "Name",model.SelectedPriority.Value);
            else 
                model.Campuses = new SelectList(campuses, "Id", "Name");

            if(model.SelectedEquipmentType.HasValue) 
                model.EquipmentTypes = new SelectList(equipmentTypes, "Id", "Name", model.SelectedEquipmentType.Value);
            else 
                model.EquipmentTypes = new SelectList(equipmentTypes, "Id", "Name");
        }

        private async Task<ComponentReplaceRequest> InitializeRequest(ComponentReplaceRequestViewModel model, Employee user)
        {
            ComponentReplaceRequest request = new ComponentReplaceRequest();
            Service service = await serviceLogic.GetServiceById(SERVICE_ID);
            request.ServiceId = service.Id;
            request.StatusId = (service.ApprovalRequired) ? (int)RequestStatus.Approval : (int)RequestStatus.Open;
            request.PriorityId = model.PriorityId;
            request.ClientId = user.Id;
            request.SubdivisionId = user.SubdivisionId;
            ExecutorGroup executorGroup = RequestHelper.GetExecutorGroup(service);
            request.ExecutorGroupId = executorGroup.Id;
            Employee executor = await RequestHelper.GetExecutor(user, executorGroup, subdivisionLogic, employeeLogic);
            request.ExecutorId = executor?.Id;
            request.CampusId = model.CampusId;
            request.PriorityId = model.PriorityId;
            request.Title = model.Title;
            request.Justification = model.Justification;
            request.Description = model.Description;
            request.Location = model.Location;
            request.ReplaceComponents = new List<ReplaceComponents>();
            foreach (var item in model.Replaces)
            {
                ReplaceComponents replace = DataFromModel.GetData(item);
                request.ReplaceComponents.Add(replace);
            }
            return request;
        }

        private ComponentReplaceRequestLifeCycle InitializeLifeCycle(int requestId, Employee user, string message)
        {
            ComponentReplaceRequestLifeCycle lifeCycle = new ComponentReplaceRequestLifeCycle();
            lifeCycle.Date = DateTime.Now;
            lifeCycle.EmployeeId = user.Id;
            lifeCycle.Message = message;
            lifeCycle.RequestId = requestId;
            return lifeCycle;
        }

        private async Task ChangeRequestStatus(int id, RequestStatus status)
        {
            var request = await requestLogic.GetRequestById(id);
            request.StatusId = (int)status;
            await requestLogic.Save(request);
        }

        private async Task LifeCycleMessage(int id, Employee user, string msg)
        {
            var lifeCycle = InitializeLifeCycle(id, user, msg);
            await lifeCycleLogic.Add(lifeCycle);
        }

        public async Task<ActionResult> Details(int id)
        {
            Employee user = await PopulateAccountInfo();
            ComponentReplaceRequest request = await requestLogic.GetRequestById(id);
            List<ComponentReplaceRequestLifeCycle> lifeCycles = await lifeCycleLogic.GetLifeCycles(request.Id);
            ComponentReplaceDetailsRequestViewModel model = ModelFromData.GetViewModel(request, user, lifeCycles);
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            await PopulateAccountInfo();
            ComponentReplaceRequestViewModel model = new ComponentReplaceRequestViewModel();
            await PopulateDropDownList(model);
            var service = await serviceLogic.GetServiceById(SERVICE_ID);
            model.ServiceModel = ModelFromData.GetViewModel(service);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Create(ComponentReplaceRequestViewModel model)
        {
            await PopulateDropDownList(model);
            Employee user = await PopulateAccountInfo();
            var request = await InitializeRequest(model, user);
            await requestLogic.Save(request);
            await LifeCycleMessage(request.Id, user, "Создание заявки");
            return RedirectToAction("Details", "ComponentReplaceRequest", new { id = request.Id });
        }

        public async Task<ActionResult> Edit(int id)
        {
            await PopulateAccountInfo();
            var request = await requestLogic.GetRequestById(id);
            ComponentReplaceRequestViewModel model = ModelFromData.GetViewModel(request);
            await PopulateDropDownList(model);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(ComponentReplaceRequestViewModel model)
        {
            Employee user = await PopulateAccountInfo();
            await PopulateDropDownList(model);
            var request = DataFromModel.GetData(model);

            await componentsLogic.DeleteEntry(request);
            List<ReplaceComponents> components = new List<ReplaceComponents>();
            foreach (var item in model.Replaces)
            {
                ReplaceComponents replace = DataFromModel.GetData(item);
                replace.RequestId = request.Id;
                await componentsLogic.Add(replace);
                components.Add(replace);
            }
            request.ReplaceComponents = components;

            await requestLogic.Save(request);
            await LifeCycleMessage(request.Id, user, "Редактирование заявки");
            return RedirectToAction("Details", "ComponentReplaceRequest", new { id = request.Id });
        }

        public async Task<ActionResult> Delete(int id)
        {
            await PopulateAccountInfo();
            var request = await requestLogic.GetRequestById(id);
            ComponentReplaceRequestViewModel model = ModelFromData.GetViewModel(request);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, ComponentReplaceDetailsRequestViewModel model)
        {
            await PopulateAccountInfo();
            var request = await requestLogic.GetRequestById(id);
            await requestLogic.Delete(request);
            return RedirectToAction("Requests", "Dashboard", new { Area = "" });
        }

        public async Task<ActionResult> AgreeRequest(int id)
        {
            Employee user = await PopulateAccountInfo();
            await ChangeRequestStatus(id, RequestStatus.Open);
            await LifeCycleMessage(id, user, "Заявка прошла согласование");
            return RedirectToAction("Details", "ComponentReplaceRequest", new { id });
        }

        public async Task<ActionResult> RejectRequest(int id)
        {
            Employee user = await PopulateAccountInfo();
            await ChangeRequestStatus(id, RequestStatus.Closed);
            await LifeCycleMessage(id, user, "Заявка не прошла согласование");
            return RedirectToAction("Details", "ComponentReplaceRequest", new { id });
        }

        public async Task<ActionResult> GetInWork(int id)
        {
            Employee user = await PopulateAccountInfo();
            await ChangeRequestStatus(id, RequestStatus.InWork);
            await LifeCycleMessage(id, user, "Начало исполнения заявки");
            return RedirectToAction("Details", "ComponentReplaceRequest", new { id });
        }

        public async Task<ActionResult> DoneWork(int id)
        {
            Employee user = await PopulateAccountInfo();
            await ChangeRequestStatus(id, RequestStatus.Done);
            await LifeCycleMessage(id, user, "Заявка выполнена");
            return RedirectToAction("Details", "ComponentReplaceRequest", new { id });
        }

        public async Task<ActionResult> Archive(int id)
        {
            Employee user = await PopulateAccountInfo();
            await ChangeRequestStatus(id, RequestStatus.Archive);
            await LifeCycleMessage(id, user, "Заявка перенесена в архив");
            return RedirectToAction("Details", "ComponentReplaceRequest", new { id });
        }

        public async Task<ActionResult> AddMessage(int id, ComponentReplaceDetailsRequestViewModel model)
        {
            Employee user = await PopulateAccountInfo();
            await LifeCycleMessage(id, user, model.Message);
            return RedirectToAction("Details", "ComponentReplaceRequest", new { id });
        }
    }
}