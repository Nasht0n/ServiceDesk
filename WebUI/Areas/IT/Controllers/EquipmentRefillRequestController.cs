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
    public class EquipmentRefillRequestController : Controller
    {
        private const int SERVICE_ID = 4;

        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly ICampusLogic campusLogic;
        private readonly IPriorityLogic priorityLogic;
        private readonly IEquipmentTypeLogic equipmentTypeLogic;
        private readonly IEquipmentLogic equipmentLogic;
        private readonly IServiceLogic serviceLogic;
        private readonly ISubdivisionLogic subdivisionLogic;
        private readonly IEquipmentRefillRequestLogic requestLogic;
        private readonly IEquipmentRefillRequestLifeCycleLogic lifeCycleLogic;
        private readonly IRefillEquipmentsLogic equipmentsLogic;
        private readonly IRefuelingLimitsLogic limitsLogic;

        public EquipmentRefillRequestController(IAccountLogic accountLogic, IEmployeeLogic employeeLogic, IAccountPermissionLogic accountPermissionLogic,
           ICampusLogic campusLogic, IPriorityLogic priorityLogic, IEquipmentTypeLogic equipmentTypeLogic, IEquipmentLogic equipmentLogic, IServiceLogic serviceLogic, ISubdivisionLogic subdivisionLogic,
           IEquipmentRefillRequestLogic requestLogic, IEquipmentRefillRequestLifeCycleLogic lifeCycleLogic, IRefillEquipmentsLogic refillEquipmentsLogic, IRefuelingLimitsLogic limitsLogic)
        {
            this.accountLogic = accountLogic;
            this.employeeLogic = employeeLogic;
            this.accountPermissionLogic = accountPermissionLogic;
            this.campusLogic = campusLogic;
            this.priorityLogic = priorityLogic;
            this.equipmentTypeLogic = equipmentTypeLogic;
            this.equipmentLogic = equipmentLogic;
            this.serviceLogic = serviceLogic;
            this.subdivisionLogic = subdivisionLogic;
            this.requestLogic = requestLogic;
            this.lifeCycleLogic = lifeCycleLogic;
            this.equipmentsLogic = refillEquipmentsLogic;
            this.limitsLogic = limitsLogic;
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

        private async Task PopulateDropDownList(EquipmentRefillRequestViewModel model)
        {
            var campuses = await campusLogic.GetCampuses();
            var priorities = await priorityLogic.GetPriorities();
            model.Priorities = new SelectList(priorities, "Id", "Fullname");
            model.Campuses = new SelectList(campuses, "Id", "Name");
        }

        private async Task<EquipmentRefillRequest> InitializeRequest(EquipmentRefillRequestViewModel model, Employee user)
        {
            EquipmentRefillRequest request = new EquipmentRefillRequest();
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

        private EquipmentRefillRequestLifeCycle InitializeLifeCycle(int requestId, Employee user, string message)
        {
            EquipmentRefillRequestLifeCycle lifeCycle = new EquipmentRefillRequestLifeCycle();
            lifeCycle.Date = DateTime.Now;
            lifeCycle.EmployeeId = user.Id;
            lifeCycle.Message = message;
            lifeCycle.RequestId = requestId;
            return lifeCycle;
        }

        private async Task ChangeRequestStatus(int id, RequestStatus status)
        {
            var request = await requestLogic.GetRequest(id);
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
            EquipmentRefillRequest request = await requestLogic.GetRequest(id);
            List<EquipmentRefillRequestLifeCycle> lifeCycles = await lifeCycleLogic.GetLifeCycles(request);
            EquipmentRefillDetailsRequestViewModel model = ModelFromData.GetViewModel(request, user, lifeCycles);

            foreach (var refill in model.RequestModel.Refills)
            {
                var equipment = await equipmentLogic.GetEquipment(refill.InventoryNumber);
                refill.EquipmentTypeModel = ModelFromData.GetViewModel(equipment.EquipmentType);
                refill.Model = equipment.Name;
            }

            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            Employee user = await PopulateAccountInfo();
            await PopulateLimitsInfo(user);
            EquipmentRefillRequestViewModel model = new EquipmentRefillRequestViewModel();
            await PopulateDropDownList(model);
            var service = await serviceLogic.GetService(SERVICE_ID);
            model.ServiceModel = ModelFromData.GetViewModel(service);
            return View(model);
        }

        private async Task PopulateLimitsInfo(Employee user)
        {
            var refills = await requestLogic.GetRequests(user.Subdivision);
            var limits = await limitsLogic.GetLimit(user.Subdivision);
            ViewBag.RefillsCount = refills.Count + 1;
            ViewBag.LimitsCount = limits.Count;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EquipmentRefillRequestViewModel model)
        {
            await PopulateDropDownList(model);
            Employee user = await PopulateAccountInfo();
            await PopulateLimitsInfo(user);

            var request = await InitializeRequest(model, user);

            if (model.Refills.Count == 0)
            {
                ModelState.AddModelError("", "Список оборудования требующего заправку пуст.");
                var service = await serviceLogic.GetService(SERVICE_ID);
                model.ServiceModel = ModelFromData.GetViewModel(service);
                return View(model);
            }
            else
            {
                request.RefillEquipments = new List<RefillEquipments>();
                foreach (var item in model.Refills)
                {
                    var equipment = await equipmentLogic.GetEquipment(item.InventoryNumber);
                    if (equipment == null)
                    {
                        ModelState.AddModelError("", $"Оборудование с данным инвентарным номером не найдено: '{item.InventoryNumber}'.");
                        var service = await serviceLogic.GetService(SERVICE_ID);
                        model.ServiceModel = ModelFromData.GetViewModel(service);
                        model.Refills = new List<RefillEquipmentViewModel>();
                        return View(model);
                    }
                    RefillEquipments refill = DataFromModel.GetData(item);

                    request.RefillEquipments.Add(refill);
                }
                await requestLogic.Save(request);
                await LifeCycleMessage(request.Id, user, "Создание заявки");
                return RedirectToAction("Details", "EquipmentRefillRequest", new { id = request.Id });
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            await PopulateAccountInfo();
            var request = await requestLogic.GetRequest(id);
            EquipmentRefillRequestViewModel model = ModelFromData.GetViewModel(request);
            await PopulateDropDownList(model);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(EquipmentRefillRequestViewModel model)
        {
            Employee user = await PopulateAccountInfo();
            await PopulateDropDownList(model);
            var request = DataFromModel.GetData(model);
            await equipmentsLogic.DeleteEntry(request);
            if (model.Refills.Count == 0)
            {
                ModelState.AddModelError("", "Список оборудования требующего заправку пуст.");
                var service = await serviceLogic.GetService(SERVICE_ID);
                model.ServiceModel = ModelFromData.GetViewModel(service);
                return View(model);
            }
            else
            {
                List<RefillEquipments> equipments = new List<RefillEquipments>();
                foreach (var item in model.Refills)
                {
                    RefillEquipments refill = DataFromModel.GetData(item);
                    refill.RequestId = request.Id;
                    await equipmentsLogic.Add(refill);
                    equipments.Add(refill);
                }
                request.RefillEquipments = equipments;
                await requestLogic.Save(request);
                await LifeCycleMessage(request.Id, user, "Редактирование заявки");
                return RedirectToAction("Details", "EquipmentRefillRequest", new { id = request.Id });
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            await PopulateAccountInfo();
            var request = await requestLogic.GetRequest(id);
            EquipmentRefillRequestViewModel model = ModelFromData.GetViewModel(request);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, EquipmentRefillRequestViewModel model)
        {
            await PopulateAccountInfo();
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

        public async Task<ActionResult> AddMessage(int id, EquipmentRefillDetailsRequestViewModel model)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetService(SERVICE_ID);
            await LifeCycleMessage(id, user, model.Message);
            return RedirectToAction("Details", service.Controller, new { id });
        }
    }
}