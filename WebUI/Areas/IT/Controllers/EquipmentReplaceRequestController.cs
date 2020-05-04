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
    public class EquipmentReplaceRequestController : Controller
    {
        private const int SERVICE_ID = 3;
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly ICampusLogic campusLogic;
        private readonly IPriorityLogic priorityLogic;
        private readonly IEquipmentTypeLogic equipmentTypeLogic;
        private readonly IServiceLogic serviceLogic;
        private readonly ISubdivisionLogic subdivisionLogic;
        private readonly IEquipmentReplaceRequestLogic requestLogic;
        private readonly IEquipmentReplaceRequestLifeCycleLogic lifeCycleLogic;
        private readonly IReplaceEquipmentsLogic equipmentsLogic;
        private readonly IEquipmentLogic equipmentLogic;

        public EquipmentReplaceRequestController(IAccountLogic accountLogic, IEmployeeLogic employeeLogic, IAccountPermissionLogic accountPermissionLogic,
           ICampusLogic campusLogic, IPriorityLogic priorityLogic, IEquipmentTypeLogic equipmentTypeLogic, IServiceLogic serviceLogic, ISubdivisionLogic subdivisionLogic,
           IEquipmentReplaceRequestLogic requestLogic, IEquipmentReplaceRequestLifeCycleLogic lifeCycleLogic, IReplaceEquipmentsLogic replaceEquipmentsLogic, IEquipmentLogic equipmentLogic)
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
            this.equipmentsLogic = replaceEquipmentsLogic;
            this.equipmentLogic = equipmentLogic;
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

        private async Task PopulateDropDownList(EquipmentReplaceRequestViewModel model)
        {
            var campuses = await campusLogic.GetCampuses();
            var priorities = await priorityLogic.GetPriorities();
            var equipmentTypes = await equipmentTypeLogic.GetEquipmentTypes();

            model.Priorities = new SelectList(priorities, "Id", "Fullname");
            model.Campuses = new SelectList(campuses, "Id", "Name");
            model.EquipmentTypes = new SelectList(equipmentTypes, "Id", "Name");
        }

        private async Task<EquipmentReplaceRequest> InitializeRequest(EquipmentReplaceRequestViewModel model, Employee user)
        {
            EquipmentReplaceRequest request = new EquipmentReplaceRequest();
            Service service = await serviceLogic.GetService(SERVICE_ID);
            request.ServiceId = service.Id;
            request.StatusId = (service.ApprovalRequired) ? (int)RequestStatus.Approval : (int)RequestStatus.Open;
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
            return request;
        }

        private EquipmentReplaceRequestLifeCycle InitializeLifeCycle(int requestId, Employee user, string message)
        {
            EquipmentReplaceRequestLifeCycle lifeCycle = new EquipmentReplaceRequestLifeCycle();
            lifeCycle.Date = DateTime.Now;
            lifeCycle.EmployeeId = user.Id;
            lifeCycle.Message = message;
            lifeCycle.RequestId = requestId;
            return lifeCycle;
        }

        public async Task ChangeRequestStatus(int id, RequestStatus status)
        {
            var request = await requestLogic.GetRequest(id);
            request.StatusId = (int)status;
            await requestLogic.Save(request);
        }

        public async Task LifeCycleMessage(int id, Employee user, string msg)
        {
            var lifeCycle = InitializeLifeCycle(id, user, msg);
            await lifeCycleLogic.Add(lifeCycle);
        }

        public async Task<ActionResult> Details(int id)
        {
            Employee user = await PopulateAccountInfo();
            EquipmentReplaceRequest request = await requestLogic.GetRequest(id);
            List<EquipmentReplaceRequestLifeCycle> lifeCycles = await lifeCycleLogic.GetLifeCycles(request);
            EquipmentReplaceDetailsRequestViewModel model = ModelFromData.GetViewModel(request, user, lifeCycles);
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            await PopulateAccountInfo();
            EquipmentReplaceRequestViewModel model = new EquipmentReplaceRequestViewModel();
            await PopulateDropDownList(model);
            var service = await serviceLogic.GetService(SERVICE_ID);
            model.ServiceModel = ModelFromData.GetViewModel(service);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Create(EquipmentReplaceRequestViewModel model)
        {
            await PopulateDropDownList(model);
            Employee user = await PopulateAccountInfo();
            var request = await InitializeRequest(model, user);
            if (model.Replaces.Count == 0)
            {
                ModelState.AddModelError("", "Список оборудования требующего замену пуст.");
                var service = await serviceLogic.GetService(SERVICE_ID);
                model.ServiceModel = ModelFromData.GetViewModel(service);
                return View(model);
            }
            else
            {
                request.ReplaceEquipments = new List<ReplaceEquipments>();
                foreach (var replace in model.Replaces)
                {
                    var equipment = await equipmentLogic.GetEquipment(replace.InventoryNumber);
                    if (equipment == null)
                    {
                        ModelState.AddModelError("", "Оборудование с данным инвентарным номером не найдено.");
                        var service = await serviceLogic.GetService(SERVICE_ID);
                        model.ServiceModel = ModelFromData.GetViewModel(service);
                        model.Replaces = new List<ReplaceEquipmentViewModel>();
                        return View(model);
                    }
                    ReplaceEquipments equipments = DataFromModel.GetData(replace);
                    request.ReplaceEquipments.Add(equipments);
                }
                await requestLogic.Save(request);
                await LifeCycleMessage(request.Id, user, "Создание заявки");
                return RedirectToAction("Details", "EquipmentReplaceRequest", new { id = request.Id });
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            await PopulateAccountInfo();
            var request = await requestLogic.GetRequest(id);
            EquipmentReplaceRequestViewModel model = ModelFromData.GetViewModel(request);
            await PopulateDropDownList(model);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(EquipmentReplaceRequestViewModel model)
        {
            Employee user = await PopulateAccountInfo();
            await PopulateDropDownList(model);
            var request = DataFromModel.GetData(model);
            await equipmentsLogic.DeleteEntry(request);
            if (model.Replaces.Count == 0)
            {
                ModelState.AddModelError("", "Список оборудования требующего замену пуст.");
                var service = await serviceLogic.GetService(SERVICE_ID);
                model.ServiceModel = ModelFromData.GetViewModel(service);
                return View(model);
            }
            else
            {
                List<ReplaceEquipments> equipments = new List<ReplaceEquipments>();
                foreach (var item in model.Replaces)
                {
                    ReplaceEquipments replace = DataFromModel.GetData(item);
                    replace.RequestId = request.Id;
                    await equipmentsLogic.Add(replace);
                    equipments.Add(replace);
                }
                request.ReplaceEquipments = equipments;
                await requestLogic.Save(request);
                await LifeCycleMessage(request.Id, user, "Редактирование заявки");
                return RedirectToAction("Details", "EquipmentReplaceRequest", new { id = request.Id });
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            Employee user = await PopulateAccountInfo();
            var request = await requestLogic.GetRequest(id);
            EquipmentReplaceRequestViewModel model = ModelFromData.GetViewModel(request);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, EquipmentReplaceRequestViewModel model)
        {
            Employee user = await PopulateAccountInfo();
            var request = await requestLogic.GetRequest(id);
            await requestLogic.Delete(request);
            return RedirectToAction("Requests", "Dashboard", new { Area = "" });
        }

        public async Task<ActionResult> AgreeRequest(int id)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetService(SERVICE_ID);
            await ChangeRequestStatus(id, RequestStatus.Open);
            await LifeCycleMessage(id, user, "Заявка прошла согласование");
            return RedirectToAction("Details", service.Controller, new { id });
        }

        public async Task<ActionResult> RejectRequest(int id)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetService(SERVICE_ID);
            await ChangeRequestStatus(id, RequestStatus.Closed);
            await LifeCycleMessage(id, user, "Заявка не прошла согласование");
            return RedirectToAction("Details", service.Controller, new { id });
        }

        public async Task<ActionResult> GetInWork(int id)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetService(SERVICE_ID);
            await ChangeRequestStatus(id, RequestStatus.InWork);
            await LifeCycleMessage(id, user, "Начало исполнения заявки");
            return RedirectToAction("Details", service.Controller, new { id });
        }

        public async Task<ActionResult> DoneWork(int id)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetService(SERVICE_ID);
            await ChangeRequestStatus(id, RequestStatus.Done);
            await LifeCycleMessage(id, user, "Заявка выполнена");
            return RedirectToAction("Details", service.Controller, new { id });
        }

        public async Task<ActionResult> Archive(int id)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetService(SERVICE_ID);
            await ChangeRequestStatus(id, RequestStatus.Archive);
            await LifeCycleMessage(id, user, "Заявка перенесена в архив");
            return RedirectToAction("Details", service.Controller, new { id });
        }

        public async Task<ActionResult> AddMessage(int id, EquipmentInstallationDetailsRequestViewModel model)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetService(SERVICE_ID);
            await LifeCycleMessage(id, user, model.Message);
            return RedirectToAction("Details", service.Controller, new { id });
        }
    }
}