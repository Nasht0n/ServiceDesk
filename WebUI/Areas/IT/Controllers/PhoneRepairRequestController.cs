using BusinessLogic.Abstract;
using BusinessLogic.Abstract.Branches.IT.Communications.LifeCycles;
using BusinessLogic.Abstract.Branches.IT.Communications.Requests;
using Domain.Models;
using Domain.Models.Requests.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Models.Enum;
using WebUI.Models.Helpers;
using WebUI.ViewModels.Requests.IT.Communications;

namespace WebUI.Areas.IT.Controllers
{
    public class PhoneRepairRequestController : Controller
    {
        private const int SERVICE_ID = 16;
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly ICampusLogic campusLogic;
        private readonly IPriorityLogic priorityLogic;
        private readonly IEquipmentTypeLogic equipmentTypeLogic;
        private readonly IServiceLogic serviceLogic;
        private readonly ISubdivisionLogic subdivisionLogic;
        private readonly IPhoneRepairRequestLogic requestLogic;
        private readonly IPhoneRepairRequestLifeCycleLogic lifeCycleLogic;
        private readonly IEquipmentLogic equipmentLogic;

        public PhoneRepairRequestController(IAccountLogic accountLogic, IEmployeeLogic employeeLogic, IAccountPermissionLogic accountPermissionLogic,
           ICampusLogic campusLogic, IPriorityLogic priorityLogic, IEquipmentTypeLogic equipmentTypeLogic, IServiceLogic serviceLogic, ISubdivisionLogic subdivisionLogic,
           IPhoneRepairRequestLogic requestLogic, IPhoneRepairRequestLifeCycleLogic lifeCycleLogic, IEquipmentLogic equipmentLogic)
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
            this.equipmentLogic = equipmentLogic;
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

        private async Task PopulateDropDownList(PhoneRepairRequestViewModel model)
        {
            var priorities = await priorityLogic.GetPriorities();
            model.Priorities = new SelectList(priorities, "Id", "Fullname");
        }

        private async Task<PhoneRepairRequest> InitializeRequest(PhoneRepairRequestViewModel model, Employee user)
        {
            PhoneRepairRequest request = new PhoneRepairRequest();
            Service service = await serviceLogic.GetServiceById(SERVICE_ID);
            request.ServiceId = service.Id;
            request.StatusId = (service.ApprovalRequired) ? (int)RequestStatus.Approval : (int)RequestStatus.Open;
            request.ClientId = user.Id;
            request.SubdivisionId = user.SubdivisionId;
            ExecutorGroup executorGroup = RequestHelper.GetExecutorGroup(service);
            request.ExecutorGroupId = executorGroup.Id;
            Employee executor = await RequestHelper.GetExecutor(user, executorGroup, subdivisionLogic, employeeLogic);
            request.ExecutorId = executor?.Id;
            request.PriorityId = model.PriorityId;
            request.Title = model.Title;
            request.Justification = model.Justification;
            request.Description = model.Description;
            request.CampusId = model.CampusId;
            request.Location = model.Location;
            return request;
        }

        private PhoneRepairRequestLifeCycle InitializeLifeCycle(int requestId, Employee user, string message)
        {
            PhoneRepairRequestLifeCycle lifeCycle = new PhoneRepairRequestLifeCycle();
            lifeCycle.Date = DateTime.Now;
            lifeCycle.EmployeeId = user.Id;
            lifeCycle.Message = message;
            lifeCycle.RequestId = requestId;
            return lifeCycle;
        }

        public async Task ChangeRequestStatus(int id, RequestStatus status)
        {
            var request = await requestLogic.GetRequestById(id);
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
            PhoneRepairRequest request = await requestLogic.GetRequestById(id);
            List<PhoneRepairRequestLifeCycle> lifeCycles = await lifeCycleLogic.GetLifeCycles(request);
            PhoneRepairDetailsRequestViewModel model = ModelFromData.GetViewModel(request, user, lifeCycles);
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            await PopulateAccountInfo();
            PhoneRepairRequestViewModel model = new PhoneRepairRequestViewModel();
            await PopulateDropDownList(model);
            var service = await serviceLogic.GetServiceById(SERVICE_ID);
            model.ServiceModel = ModelFromData.GetViewModel(service);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Create(PhoneRepairRequestViewModel model)
        {
            await PopulateDropDownList(model);
            Employee user = await PopulateAccountInfo();
            var request = await InitializeRequest(model, user);
            var service = await serviceLogic.GetServiceById(SERVICE_ID);
            await requestLogic.Save(request);
            await LifeCycleMessage(request.Id, user, "Создание заявки");
            return RedirectToAction("Details", service.Controller, new { id = request.Id });

        }

        public async Task<ActionResult> Edit(int id)
        {
            await PopulateAccountInfo();
            var request = await requestLogic.GetRequestById(id);
            PhoneRepairRequestViewModel model = ModelFromData.GetViewModel(request);
            await PopulateDropDownList(model);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(PhoneRepairRequestViewModel model)
        {
            Employee user = await PopulateAccountInfo();
            await PopulateDropDownList(model);
            var request = DataFromModel.GetData(model);
            var service = await serviceLogic.GetServiceById(SERVICE_ID);
            await requestLogic.Save(request);
            await LifeCycleMessage(request.Id, user, "Редактирование заявки");
            return RedirectToAction("Details", service.Controller, new { id = request.Id });

        }

        public async Task<ActionResult> Delete(int id)
        {
            Employee user = await PopulateAccountInfo();
            var request = await requestLogic.GetRequestById(id);
            PhoneRepairRequestViewModel model = ModelFromData.GetViewModel(request);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, PhoneRepairRequestViewModel model)
        {
            Employee user = await PopulateAccountInfo();
            var request = await requestLogic.GetRequestById(id);
            await requestLogic.Delete(request);
            return RedirectToAction("Requests", "Dashboard", new { Area = "" });
        }


        public async Task<ActionResult> AgreeRequest(int id)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetServiceById(SERVICE_ID);
            await ChangeRequestStatus(id, RequestStatus.Open);
            await LifeCycleMessage(id, user, "Заявка прошла согласование");
            return RedirectToAction("Details", service.Controller, new { id });
        }

        public async Task<ActionResult> RejectRequest(int id)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetServiceById(SERVICE_ID);
            await ChangeRequestStatus(id, RequestStatus.Closed);
            await LifeCycleMessage(id, user, "Заявка не прошла согласование");
            return RedirectToAction("Details", service.Controller, new { id });
        }

        public async Task<ActionResult> GetInWork(int id)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetServiceById(SERVICE_ID);
            await ChangeRequestStatus(id, RequestStatus.InWork);
            await LifeCycleMessage(id, user, "Начало исполнения заявки");
            return RedirectToAction("Details", service.Controller, new { id });
        }

        public async Task<ActionResult> DoneWork(int id)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetServiceById(SERVICE_ID);
            await ChangeRequestStatus(id, RequestStatus.Done);
            await LifeCycleMessage(id, user, "Заявка выполнена");
            return RedirectToAction("Details", service.Controller, new { id });
        }

        public async Task<ActionResult> Archive(int id)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetServiceById(SERVICE_ID);
            await ChangeRequestStatus(id, RequestStatus.Archive);
            await LifeCycleMessage(id, user, "Заявка перенесена в архив");
            return RedirectToAction("Details", service.Controller, new { id });
        }

        public async Task<ActionResult> AddMessage(int id, PhoneRepairDetailsRequestViewModel model)
        {
            Employee user = await PopulateAccountInfo();
            var service = await serviceLogic.GetServiceById(SERVICE_ID);
            await LifeCycleMessage(id, user, model.Message);
            return RedirectToAction("Details", service.Controller, new { id });
        }
    }
}