using BusinessLogic;
using BusinessLogic.LifeCycles;
using BusinessLogic.Requests;
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
    public class EquipmentInstallationRequestController : Controller
    {
        private const int SERVICE_ID = 1;

        private EquipmentInstallationRequestLifeCycleService lifeCycleService = new EquipmentInstallationRequestLifeCycleService();
        private EquipmentInstallationRequestService requestService = new EquipmentInstallationRequestService();

        private EmployeeService employeeService = new EmployeeService();
        private ServiceService serviceService = new ServiceService();
        private CampusService campusService = new CampusService();
        private PriorityService priorityService = new PriorityService();
        private EquipmentTypeService equipmentTypeService = new EquipmentTypeService();
        private SubdvisionService subdvisionService = new SubdvisionService();

        private void PopulateDropDownList()
        {
            ViewBag.Campuses = campusService.GetCampuses();
            ViewBag.Priorities = priorityService.GetPriorities();
            ViewBag.EquipmentTypes = equipmentTypeService.GetEquipmentTypes();
        }

        public ActionResult Details(int id)
        {
            Employee user = employeeService.GetEmployeeById(int.Parse(User.Identity.Name));
            EquipmentInstallationRequest request = requestService.GetRequest(id);
            List<EquipmentInstallationRequestLifeCycle> lifeCycles = lifeCycleService.GetLifeCycles(request.Id);
            EquipmentInstallationDetailsRequestViewModel model = ModelFromData.GetViewModel(request, user, lifeCycles);
            return View(model);
        }

        public ActionResult Create()
        {
            PopulateDropDownList();
            return View(new EquipmentInstallationRequestViewModel());
        }
        [HttpPost]
        public ActionResult Create(EquipmentInstallationRequestViewModel model)
        {
            PopulateDropDownList();
            Employee user = employeeService.GetEmployeeById(int.Parse(User.Identity.Name));
            var request = InitializeRequest(model, user);
            requestService.AddRequest(request);
            var lifeCycle = InitializeLifeCycle(request.Id, user);
            lifeCycleService.AddLifeCycle(lifeCycle);
            return RedirectToAction("Details", "EquipmentInstallationRequest", new { id = request.Id });
        }

        private EquipmentInstallationRequestLifeCycle InitializeLifeCycle(int requestId, Employee user)
        {
            EquipmentInstallationRequestLifeCycle lifeCycle = new EquipmentInstallationRequestLifeCycle();
            lifeCycle.Date = DateTime.Now;
            lifeCycle.EmployeeId = user.Id;
            lifeCycle.Message = "Создание заявки";
            lifeCycle.RequestId = requestId;
            return lifeCycle;
        }

        private EquipmentInstallationRequest InitializeRequest(EquipmentInstallationRequestViewModel model, Employee user)
        {
            EquipmentInstallationRequest request = new EquipmentInstallationRequest();
            Service service = serviceService.GetServiceById(SERVICE_ID);
            request.ServiceId = SERVICE_ID;
            request.StatusId = (service.ApprovalRequired) ? (int)RequestStatus.Approval : (int)RequestStatus.Open;
            request.PriorityId = model.PriorityId;
            request.ClientId = user.Id;
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
            request.InstallationEquipments = new List<InstallationEquipments>();
            foreach (var item in model.Installations)
            {
                InstallationEquipments installation = DataFromModel.GetData(item);
                request.InstallationEquipments.Add(installation);
            }
            return request;
        }

        public ActionResult Edit()
        {
            return View(new EquipmentInstallationRequestViewModel());
        }
        [HttpPost]
        public ActionResult Edit(EquipmentInstallationRequestViewModel model)
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View(new EquipmentInstallationRequestViewModel());
        }
        [HttpPost]
        public ActionResult Delete(EquipmentInstallationRequestViewModel model)
        {
            return View();
        }
    }
}