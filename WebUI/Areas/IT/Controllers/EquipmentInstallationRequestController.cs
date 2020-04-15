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
    public class EquipmentInstallationRequestController : Controller
    {
        private const int SERVICE_ID = 1;
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly ICampusLogic campusLogic;
        private readonly IPriorityLogic priorityLogic;
        private readonly IEquipmentTypeLogic equipmentTypeLogic;
        private readonly IServiceLogic serviceLogic;
        private readonly ISubdivisionLogic subdivisionLogic;
        private readonly IEquipmentInstallationRequestLogic requestLogic;
        private readonly IEquipmentInstallationRequestLifeCycleLogic lifeCycleLogic;
        private readonly IInstallationEquipmentsLogic equipmentsLogic;

        public EquipmentInstallationRequestController(IAccountLogic accountLogic, IEmployeeLogic employeeLogic, IAccountPermissionLogic accountPermissionLogic,
           ICampusLogic campusLogic, IPriorityLogic priorityLogic, IEquipmentTypeLogic equipmentTypeLogic, IServiceLogic serviceLogic, ISubdivisionLogic subdivisionLogic,
           IEquipmentInstallationRequestLogic requestLogic, IEquipmentInstallationRequestLifeCycleLogic lifeCycleLogic, IInstallationEquipmentsLogic equipmentsLogic)
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
            this.equipmentsLogic = equipmentsLogic;
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

        private async Task PopulateDropDownList(EquipmentInstallationRequestViewModel model)
        {
            var campuses = await campusLogic.GetCampuses();
            var priorities = await priorityLogic.GetPriorities();
            var equipmentTypes = await equipmentTypeLogic.GetEquipmentTypes();
            model.Priorities = new SelectList(priorities, "Id", "Fullname");
            model.Campuses = new SelectList(campuses, "Id", "Name");
            model.EquipmentTypes = new SelectList(equipmentTypes, "Id", "Name");
        }

        private async Task<EquipmentInstallationRequest> InitializeRequest(EquipmentInstallationRequestViewModel model, Employee user)
        {
            EquipmentInstallationRequest request = new EquipmentInstallationRequest();
            Service service = await serviceLogic.GetServiceById(SERVICE_ID);
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

        private EquipmentInstallationRequestLifeCycle InitializeLifeCycle(int requestId, Employee user, string message)
        {
            EquipmentInstallationRequestLifeCycle lifeCycle = new EquipmentInstallationRequestLifeCycle();
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
            EquipmentInstallationRequest request = await requestLogic.GetRequestById(id);
            var service = await serviceLogic.GetServiceById(request.ServiceId);
            List<EquipmentInstallationRequestLifeCycle> lifeCycles = await lifeCycleLogic.GetLifeCycles(request.Id);
            EquipmentInstallationDetailsRequestViewModel model = ModelFromData.GetViewModel(request, user, lifeCycles);
            model.AllApproval = IsApproval(service, lifeCycles);
            return View(model);
        }

        private bool IsApproval(Service service, List<EquipmentInstallationRequestLifeCycle> lifeCycles)
        {
            bool allApproval = true;
            if (service.ManyApprovalRequired)
            {
                foreach (var approver in service.Approvers)
                {
                    if (!allApproval) break;
                    var lifeCycle = lifeCycles.FirstOrDefault(l => l.EmployeeId == approver.EmployeeId && l.Message == "Заявка прошла согласование");
                    allApproval = lifeCycle != null ? true : false;
                }
            }
            return allApproval;
        }

        public async Task<ActionResult> Create()
        {
            await PopulateAccountInfo();
            EquipmentInstallationRequestViewModel model = new EquipmentInstallationRequestViewModel();
            await PopulateDropDownList(model);
            var service = await serviceLogic.GetServiceById(SERVICE_ID);
            model.ServiceModel = ModelFromData.GetViewModel(service);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Create(EquipmentInstallationRequestViewModel model)
        {
            await PopulateDropDownList(model);
            Employee user = await PopulateAccountInfo();
            var request = await InitializeRequest(model, user);
            if (model.Installations.Count == 0)
            {
                ModelState.AddModelError("", "Список оборудования на установку пуст.");
                var service = await serviceLogic.GetServiceById(SERVICE_ID);
                model.ServiceModel = ModelFromData.GetViewModel(service);
                return View(model);
            }
            else
            {
                request.InstallationEquipments = new List<InstallationEquipments>();
                foreach (var item in model.Installations)
                {
                    InstallationEquipments installation = DataFromModel.GetData(item);
                    request.InstallationEquipments.Add(installation);
                }
                await requestLogic.Save(request);
                await LifeCycleMessage(request.Id, user, "Создание заявки");
                return RedirectToAction("Details", "EquipmentInstallationRequest", new { id = request.Id });
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            await PopulateAccountInfo();
            var request = await requestLogic.GetRequestById(id);
            EquipmentInstallationRequestViewModel model = ModelFromData.GetViewModel(request);
            await PopulateDropDownList(model);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(EquipmentInstallationRequestViewModel model)
        {
            Employee user = await PopulateAccountInfo();
            await PopulateDropDownList(model);
            var request = DataFromModel.GetData(model);
            await equipmentsLogic.DeleteEntry(request);
            if (model.Installations.Count == 0)
            {
                ModelState.AddModelError("", "Список оборудования на установку пуст.");
                var service = await serviceLogic.GetServiceById(SERVICE_ID);
                model.ServiceModel = ModelFromData.GetViewModel(service);
                return View(model);
            }
            else
            {
                List<InstallationEquipments> equipments = new List<InstallationEquipments>();
                foreach (var item in model.Installations)
                {
                    InstallationEquipments installation = DataFromModel.GetData(item);
                    installation.RequestId = request.Id;
                    await equipmentsLogic.Add(installation);
                    equipments.Add(installation);
                }
                request.InstallationEquipments = equipments;
                await requestLogic.Save(request);
                await LifeCycleMessage(request.Id, user, "Редактирование заявки");
                return RedirectToAction("Details", "EquipmentInstallationRequest", new { id = request.Id });
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            await PopulateAccountInfo();
            var request = await requestLogic.GetRequestById(id);
            EquipmentInstallationRequestViewModel model = ModelFromData.GetViewModel(request);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, EquipmentInstallationRequestViewModel model)
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
            return RedirectToAction("Details", "EquipmentInstallationRequest", new { id });
        }

        public async Task<ActionResult> RejectRequest(int id)
        {
            Employee user = await PopulateAccountInfo();
            await ChangeRequestStatus(id, RequestStatus.Closed);
            await LifeCycleMessage(id, user, "Заявка не прошла согласование");
            return RedirectToAction("Details", "EquipmentInstallationRequest", new { id });
        }

        public async Task<ActionResult> GetInWork(int id)
        {
            Employee user = await PopulateAccountInfo();
            await ChangeRequestStatus(id, RequestStatus.InWork);
            await LifeCycleMessage(id, user, "Начало исполнения заявки");
            return RedirectToAction("Details", "EquipmentInstallationRequest", new { id });
        }

        public async Task<ActionResult> DoneWork(int id)
        {
            Employee user = await PopulateAccountInfo();
            await ChangeRequestStatus(id, RequestStatus.Done);
            await LifeCycleMessage(id, user, "Заявка выполнена");
            return RedirectToAction("Details", "EquipmentInstallationRequest", new { id });
        }

        public async Task<ActionResult> Archive(int id)
        {
            Employee user = await PopulateAccountInfo();
            await ChangeRequestStatus(id, RequestStatus.Archive);
            await LifeCycleMessage(id, user, "Заявка перенесена в архив");
            return RedirectToAction("Details", "EquipmentInstallationRequest", new { id });
        }

        public async Task<ActionResult> AddMessage(int id, EquipmentInstallationDetailsRequestViewModel model)
        {
            Employee user = await PopulateAccountInfo();
            await LifeCycleMessage(id, user, model.Message);
            return RedirectToAction("Details", "EquipmentInstallationRequest", new { id });
        }
    }
}