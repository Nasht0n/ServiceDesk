using BusinessLogic;
using BusinessLogic.LifeCycles.IT.Equipment;
using BusinessLogic.Requests.IT.Equipment;
using Domain.Models;
using Domain.Models.Requests.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private EquipmentRefillRequestLifeCycleService lifeCycleService = new EquipmentRefillRequestLifeCycleService();
        private EquipmentRefillRequestService requestService = new EquipmentRefillRequestService();
        private RefillEquipmentService equipmentService = new RefillEquipmentService();
        private AccountService accountService = new AccountService();
        private EmployeeService employeeService = new EmployeeService();
        private ServiceService serviceService = new ServiceService();
        private CampusService campusService = new CampusService();
        private PriorityService priorityService = new PriorityService();
        private EquipmentTypeService equipmentTypeService = new EquipmentTypeService();
        private SubdivisionService subdvisionService = new SubdivisionService();

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

        private void PopulateDropDownList()
        {
            ViewBag.Campuses = campusService.GetCampuses();
            ViewBag.Priorities = priorityService.GetPriorities();
            ViewBag.EquipmentTypes = equipmentTypeService.GetEquipmentTypes();
        }

        private EquipmentRefillRequest InitializeRequest(EquipmentRefillRequestViewModel model, Employee user)
        {
            EquipmentRefillRequest request = new EquipmentRefillRequest();
            Service service = serviceService.GetServiceById(SERVICE_ID);
            request.ServiceId = SERVICE_ID;
            request.StatusId = (service.ApprovalRequired) ? (int)RequestStatus.Approval : (int)RequestStatus.Open;
            request.PriorityId = model.PriorityId;
            request.ClientId = user.Id;
            request.SubdivisionId = user.SubdivisionId;
            ExecutorGroup executorGroup = RequestHelper.GetExecutorGroup(service);
            request.ExecutorGroupId = executorGroup.Id;
            Employee executor = RequestHelper.GetExecutor(user, executorGroup, subdvisionService, employeeService);
            request.ExecutorId = executor?.Id;
            request.CampusId = model.CampusId;
            request.PriorityId = model.PriorityId;
            request.Title = model.Title;
            request.Justification = model.Justification;
            request.Description = model.Description;
            request.Location = model.Location;
            request.RefillEquipments = new List<RefillEquipments>();
            foreach (var item in model.Refills)
            {
                RefillEquipments refill = DataFromModel.GetData(item);
                request.RefillEquipments.Add(refill);
            }
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

        public void ChangeRequestStatus(int id, RequestStatus status)
        {
            var request = requestService.GetRequest(id);
            request.StatusId = (int)status;
            requestService.UpdateRequest(request);
        }

        public void LifeCycleMessage(int id, Employee user, string msg)
        {
            var lifeCycle = InitializeLifeCycle(id, user, msg);
            lifeCycleService.AddLifeCycle(lifeCycle);
        }

        public ActionResult Details(int id)
        {
            Employee user = PopulateAccountInfo();
            EquipmentRefillRequest request = requestService.GetRequest(id);
            List<EquipmentRefillRequestLifeCycle> lifeCycles = lifeCycleService.GetLifeCycles(request.Id);
            EquipmentRefillDetailsRequestViewModel model = ModelFromData.GetViewModel(request, user, lifeCycles);
            return View(model);
        }

        public ActionResult Create()
        {
            Employee user = PopulateAccountInfo();
            PopulateDropDownList();
            EquipmentRefillRequestViewModel model = new EquipmentRefillRequestViewModel();
            var service = serviceService.GetServiceById(SERVICE_ID);
            model.ServiceModel = ModelFromData.GetViewModel(service);
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(EquipmentRefillRequestViewModel model)
        {
            PopulateDropDownList();
            Employee user = PopulateAccountInfo();
            var request = InitializeRequest(model, user);
            requestService.AddRequest(request);
            LifeCycleMessage(request.Id, user, "Создание заявки");
            return RedirectToAction("Details", "EquipmentRefillRequest", new { id = request.Id });
        }

        public ActionResult Edit(int id)
        {
            Employee user = PopulateAccountInfo();
            PopulateDropDownList();
            var request = requestService.GetRequest(id);
            EquipmentRefillRequestViewModel model = ModelFromData.GetViewModel(request);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(EquipmentRefillRequestViewModel model)
        {
            Employee user = PopulateAccountInfo();
            PopulateDropDownList();
            var request = DataFromModel.GetData(model);
            equipmentService.DeleteEntry(request);
            List<RefillEquipments> equipments = new List<RefillEquipments>();
            foreach (var item in model.Refills)
            {
                RefillEquipments refill = DataFromModel.GetData(item);
                refill.RequestId = request.Id;
                equipmentService.AddRequest(refill);
                equipments.Add(refill);
            }
            request.RefillEquipments = equipments;
            requestService.UpdateRequest(request);
            LifeCycleMessage(request.Id, user, "Редактирование заявки");
            return RedirectToAction("Details", "EquipmentRefillRequest", new { id = request.Id });
        }

        public ActionResult Delete(int id)
        {
            Employee user = PopulateAccountInfo();
            var request = requestService.GetRequest(id);
            EquipmentRefillRequestViewModel model = ModelFromData.GetViewModel(request);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id, EquipmentRefillRequestViewModel model)
        {
            Employee user = PopulateAccountInfo();
            var request = requestService.GetRequest(id);
            requestService.DeleteRequest(request);
            return RedirectToAction("Requests", "Dashboard", new { Area = "" });
        }

        public ActionResult AgreeRequest(int id)
        {
            Employee user = PopulateAccountInfo();
            ChangeRequestStatus(id, RequestStatus.Open);
            LifeCycleMessage(id, user, "Заявка прошла согласование");
            return RedirectToAction("Details", "EquipmentRefillRequest", new { id });
        }

        public ActionResult RejectRequest(int id)
        {
            Employee user = PopulateAccountInfo();
            ChangeRequestStatus(id, RequestStatus.Closed);
            LifeCycleMessage(id, user, "Заявка не прошла согласование");
            return RedirectToAction("Details", "EquipmentRefillRequest", new { id });
        }

        public ActionResult GetInWork(int id)
        {
            Employee user = PopulateAccountInfo();
            ChangeRequestStatus(id, RequestStatus.InWork);
            LifeCycleMessage(id, user, "Начало исполнения заявки");
            return RedirectToAction("Details", "EquipmentRefillRequest", new { id });
        }

        public ActionResult DoneWork(int id)
        {
            Employee user = PopulateAccountInfo();
            ChangeRequestStatus(id, RequestStatus.Done);
            LifeCycleMessage(id, user, "Заявка выполнена");
            return RedirectToAction("Details", "EquipmentRefillRequest", new { id });
        }

        public ActionResult Archive(int id)
        {
            Employee user = PopulateAccountInfo();
            ChangeRequestStatus(id, RequestStatus.Archive);
            LifeCycleMessage(id, user, "Заявка перенесена в архив");
            return RedirectToAction("Details", "EquipmentRefillRequest", new { id });
        }

        public ActionResult AddMessage(int id, EquipmentRefillDetailsRequestViewModel model)
        {
            Employee user = PopulateAccountInfo();
            LifeCycleMessage(id, user, model.Message);
            return RedirectToAction("Details", "EquipmentRefillRequest", new { id });
        }
    }
}