using BusinessLogic.Abstract;
using BusinessLogic.Abstract.Branches.IT.Equipments;
using BusinessLogic.Abstract.Branches.IT.Equipments.Consumption;
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
using WebUI.ViewModels;
using WebUI.ViewModels.Requests.IT.Equipments;
using static WebUI.ViewModels.CategoryStats;

namespace WebUI.Areas.IT.Controllers
{
    [Authorize]
    public class EquipmentRefillRequestController : Controller
    {
        // Идентификатор вида заявки
        private const int SERVICE_ID = 4;
        // Логика для работы с данными
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly ICampusLogic campusLogic;
        private readonly IPriorityLogic priorityLogic;
        private readonly IEquipmentTypeLogic equipmentTypeLogic;
        private readonly IEquipmentLogic equipmentLogic;
        private readonly IServiceLogic serviceLogic;
        private readonly ISubdivisionLogic subdivisionLogic;
        private readonly IBranchLogic branchLogic;
        private readonly ICategoryLogic categoryLogic;
        private readonly IRequestsLogic requestsLogic;
        private readonly IEquipmentRefillRequestLogic requestLogic;
        private readonly IEquipmentRefillRequestLifeCycleLogic lifeCycleLogic;
        private readonly IRefillEquipmentsLogic equipmentsLogic;
        private readonly IRefuelingLimitsLogic limitsLogic;
        private readonly IConsumableTypeLogic consumableTypeLogic;
        private readonly IConsumableLogic consumableLogic;
        private readonly IEquipmentRefillRequestConsumptionLogic consumptionLogic;

        public EquipmentRefillRequestController(IAccountLogic accountLogic, IEmployeeLogic employeeLogic, IAccountPermissionLogic accountPermissionLogic,
           ICampusLogic campusLogic, IPriorityLogic priorityLogic, IEquipmentTypeLogic equipmentTypeLogic, IEquipmentLogic equipmentLogic, IServiceLogic serviceLogic,
           ISubdivisionLogic subdivisionLogic, IBranchLogic branchLogic, ICategoryLogic categoryLogic, IRequestsLogic requestsLogic,
           IEquipmentRefillRequestLogic requestLogic, IEquipmentRefillRequestLifeCycleLogic lifeCycleLogic, IRefillEquipmentsLogic refillEquipmentsLogic, 
           IRefuelingLimitsLogic limitsLogic, IConsumableTypeLogic consumableTypeLogic, IConsumableLogic consumableLogic, IEquipmentRefillRequestConsumptionLogic consumptionLogic)
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
            this.branchLogic = branchLogic;
            this.categoryLogic = categoryLogic;
            this.requestsLogic = requestsLogic;
            this.requestLogic = requestLogic;
            this.lifeCycleLogic = lifeCycleLogic;
            this.equipmentsLogic = refillEquipmentsLogic;
            this.limitsLogic = limitsLogic;
            this.consumableTypeLogic = consumableTypeLogic;
            this.consumableLogic = consumableLogic;
            this.consumptionLogic = consumptionLogic;
        }
        /// <summary>
        /// Метод получения данных информации об авторизованном пользователе в системе.
        /// Инициализация данных рабочего пространства
        /// </summary>
        /// <param name="model">Модель конфигурации рабочего стола</param>
        /// <returns>Возвращает объект авторизованного сотрудника</returns>
        public async Task<Employee> PopulateAccountInfo(DashboardConfigurationViewModel model = null)
        {
            // получение идентификатора учетной записи
            int id = int.Parse(User.Identity.Name);
            // поиск учетной записи сотрудника
            var account = await accountLogic.GetAccount(id);
            // поиск данных сотрудника
            var user = await employeeLogic.GetEmployee(account.EmployeeId);
            if (model != null)
            {
                // инициализация полей конфигурации
                // передача информации о сотруднике
                model.CurrentUser = ModelFromData.GetViewModel(user);
                // инициализация прав доступа учетной записи
                model.UserPermissions = new UserPermissions();
                model.UserPermissions.Permissions = await accountPermissionLogic.GetPermissions(account);
                model.UserPermissions.Account = ModelFromData.GetViewModel(account);
            }
            // возвращаем данные о сотруднике
            return user;
        }
        /// <summary>
        /// Метод инициализации боковое меню
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task MenuInformation(DashboardConfigurationViewModel model)
        {
            model.MenuInformation = new MenuStats();
            var branches = await branchLogic.GetBranches();
            model.MenuInformation.Branches = ModelFromData.GetViewModel(branches);
            model.MenuInformation.CategoryStats = new CategoryStats();
            model.MenuInformation.CategoryStats.CategoryInfos = new List<CategoryInfo>();
            var categories = await categoryLogic.GetCategories();
            foreach (var category in categories)
            {
                CategoryInfo info = new CategoryInfo(model.Requests);
                info.CategoryModel = ModelFromData.GetViewModel(category);
                model.MenuInformation.CategoryStats.CategoryInfos.Add(info);
            }
        }
        /// <summary>
        /// Метод инициализации выпадающих списков
        /// </summary>
        /// <param name="model">Модель представления</param>
        /// <returns></returns>
        private async Task PopulateDropDownList(EquipmentRefillRequestViewModel model)
        {
            var campuses = await campusLogic.GetCampuses();
            var priorities = await priorityLogic.GetPriorities();
            
            model.Priorities = new SelectList(priorities, "Id", "Fullname");
            model.Campuses = new SelectList(campuses, "Id", "Name");
            
        }
        /// <summary>
        /// Метод инициализации выпадающих списков
        /// </summary>
        /// <param name="model">Модель представления</param>
        /// <returns></returns>
        private async Task PopulateDropDownList(EquipmentRefillDetailsRequestViewModel model)
        {
            var consumableTypes = await consumableTypeLogic.GetConsumableTypes();
            var consumables = await consumableLogic.GetConsumables(consumableTypes[0]);

            model.ConsumableTypes = new SelectList(consumableTypes, "Id", "Name");
            model.Consumables = new SelectList(consumables, "Id", "Name");
        }
        /// <summary>
        /// Метод инициализации списка расходных материалов
        /// </summary>
        /// <param name="subdivisionId"></param>
        /// <param name="currentId"></param>
        /// <returns></returns>
        public async Task<JsonResult> PopulateConsumables(int typeId)
        {
            var consumableType = await consumableTypeLogic.GetConsumableType(typeId);
            var consumables = await consumableLogic.GetConsumables(consumableType);
            var result = consumables.Select(c => new { Value = c.Id, Text = $"{c.InventoryNumber} —— { c.Name}" });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public async Task<ActionResult> AddConsumption(EquipmentRefillDetailsRequestViewModel model)
        {
            await consumptionLogic.Save(new EquipmentRefillRequestConsumption { RequestId = model.RequestModel.Id, ConsumableId = model.SelectedConsumable.Value, Count = model.ConsumptionModel.Count });            
            return RedirectToAction("Details", "EquipmentRefillRequest", new { id = model.RequestModel.Id });
        }
        /// <summary>
        /// Метод инициализации заявки
        /// </summary>
        /// <param name="model">Модель заявки</param>
        /// <param name="user">Авторизованный сотрудник</param>
        /// <returns>Возвращает объект заявки</returns>
        private async Task<EquipmentRefillRequest> InitializeRequest(EquipmentRefillRequestViewModel model, Employee user)
        {
            // создание заявки
            EquipmentRefillRequest request = new EquipmentRefillRequest();
            // получение вида заявки
            Service service = await serviceLogic.GetService(SERVICE_ID);
            // инициализация идентификатора вида заявки
            request.ServiceId = service.Id;
            // инициализация статуса заявки
            // если полученый вид заявки требует согласования - заявка получает статус "На согласовании"
            // в случае, если заявка не требует согласования - заявка получает статус "Открыта"
            request.StatusId = (service.ApprovalRequired) ? (int)RequestStatus.Approval : (int)RequestStatus.Open;
            // инициализация идентификатора приоритета заявки
            request.PriorityId = model.PriorityId;
            // инициализация идентификатора клиента(создателя) заявки
            request.ClientId = user.Id;
            // инициализация идентификатора подразделения создавшего заявку
            request.SubdivisionId = user.SubdivisionId;
            // получение группы исполнителей данного вида заявки
            ExecutorGroup executorGroup = RequestHelper.GetExecutorGroup(service);
            // инициализация идентификатора группы исполнителей
            request.ExecutorGroupId = executorGroup.Id;
            // инициализация идентификатора учебного корпуса
            request.CampusId = model.CampusId;
            // инициализиация аудитории
            request.Location = model.Location;
            // получение исполнителя вида работы
            Employee executor = await RequestHelper.GetExecutor(user, executorGroup, subdivisionLogic, employeeLogic);
            // инициализация идентификатора исполнителя, если он найден
            request.ExecutorId = executor?.Id;
            // инициализация темы заявки
            request.Title = model.Title;
            // инициализация обоснования заявки
            request.Justification = model.Justification;
            // инициализация описания заявки
            request.Description = model.Description;
            // возвращаем объект заявки
            return request;
        }
        /// <summary>
        /// Метод инициализации жизненного цикла заявки
        /// </summary>
        /// <param name="requestId">Идентификатор заявки</param>
        /// <param name="user">Текущий сотрудник</param>
        /// <param name="message">Сообщение жизненного цикла</param>
        /// <returns>Возвращает событие жизненного цикла заявки</returns>
        private EquipmentRefillRequestLifeCycle InitializeLifeCycle(int requestId, Employee user, string message)
        {
            // создание записи жизненного цикла заявки
            EquipmentRefillRequestLifeCycle lifeCycle = new EquipmentRefillRequestLifeCycle();
            // записываем время создания записи
            lifeCycle.Date = DateTime.Now;
            // инициализируем идентификатор сотрудника
            lifeCycle.EmployeeId = user.Id;
            // инициализируем сообщение жизненного цикла
            lifeCycle.Message = message;
            // инициализация идентификатора заявки
            lifeCycle.RequestId = requestId;
            // возвращаем запись жизненного цикла заявки
            return lifeCycle;
        }
        /// <summary>
        /// Метод изменения статуса заявки
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <param name="status">Новый статус заявки</param>
        /// <returns></returns>
        private async Task ChangeRequestStatus(int id, RequestStatus status, Employee executor = null)
        {
            // получаем заявку по идентификатору
            var request = await requestLogic.GetRequest(id);
            if (executor != null) request.ExecutorId = executor.Id;
            // инициализируем идентификатор статуса новым значением
            request.StatusId = (int)status;
            // сохраняем изменения заявки
            await requestLogic.Save(request);
        }
        /// <summary>
        /// Метод добавления записи в жизненный цикл заявки
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <param name="user">Текущий сотрудник</param>
        /// <param name="msg">Сообщение жизненного цикла</param>
        /// <returns></returns>
        private async Task LifeCycleMessage(int id, Employee user, string msg)
        {
            // инициализация записи жизненного цикла заявки
            var lifeCycle = InitializeLifeCycle(id, user, msg);
            // добавление записи жизненного цикла
            await lifeCycleLogic.Add(lifeCycle);
        }
        /// <summary>
        /// Метод отображения страницы информации о заявке
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <returns>Возвращает представление информации о заявке</returns>
        public async Task<ActionResult> Details(int id)
        {
            // создание модели представления
            EquipmentRefillDetailsRequestViewModel model = new EquipmentRefillDetailsRequestViewModel();
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // получение заявок касающихся авторизованного сотрудника
            var requests = await requestsLogic.GetRequests(user, client: false);
            // инициализации списка заявок в модели представления
            model.Requests = ModelFromData.GetViewModel(requests);
            // Инициализация бокового меню
            await MenuInformation(model);
            // инициализация выпадающего списка представления
            await PopulateDropDownList(model);
            // поиск заявки по идентификатору
            var request = await requestLogic.GetRequest(id);
            // получение вида заявки
            var service = await serviceLogic.GetService(request.ServiceId);
            // получение списка жизненного цикла заявки
            var lifeCycles = await lifeCycleLogic.GetLifeCycles(request);

            var consumptions = await consumptionLogic.GetConsumptions(request);
            // инициализация модели представления
            model = ModelFromData.GetViewModel(model, request, user, lifeCycles, consumptions);
            // проверка: прошла ли заявка полное согласование (при множественном согласовании)
            model.AllApproval = IsApproval(service, lifeCycles);
            // отображаем информацию о заправке
            foreach (var refill in model.RequestModel.Refills)
            {
                var equipment = await equipmentLogic.GetEquipment(refill.InventoryNumber);
                refill.EquipmentTypeModel = ModelFromData.GetViewModel(equipment.EquipmentType);
                refill.Model = equipment.Name;
            }
            // отображаем представление 
            return View(model);
        }

        public async Task<ActionResult> RemoveConsumption(int id)
        {
            var consumption = await consumptionLogic.GetConsumption(id);
            if (consumption != null)
            {
                await consumptionLogic.Delete(consumption);
            }
            return RedirectToAction("Details", "EquipmentRefillRequest", new { id = consumption.RequestId });
        }

        /// <summary>
        /// Метод проверки заявки на полное согласование (множественное)
        /// </summary>
        /// <param name="service">Вид заявки</param>
        /// <param name="lifeCycles">Жизненный цикл заявки</param>
        /// <returns>Возвращает true — если заявка согласована, иначе false</returns>
        private bool IsApproval(Service service, List<EquipmentRefillRequestLifeCycle> lifeCycles)
        {
            
            
            // флаг согласования
            bool allApproval = true;
            // если вид заявки требует согласования нескольких лиц
            if (service.ManyApprovalRequired)
            {
                // совершаем обход по сотрудникам проводящим согласование заявки
                foreach (var approver in service.Approvers)
                {
                    // если заявка не прошла согласование одного из сотрудников завершаем цикл
                    if (!allApproval) break;
                    // ищем отметку о согласовании в жизненном цикле заявки
                    var lifeCycle = lifeCycles.FirstOrDefault(l => l.EmployeeId == approver.EmployeeId && l.Message == "Заявка прошла согласование");
                    // если запись найдена, то продолжаем цикл
                    allApproval = lifeCycle != null ? true : false;
                }
            }
            // возвращаем результат
            return allApproval;
        }
        /// <summary>
        /// Метод отображения страницы создания заявки
        /// </summary>
        /// <returns>Возвращает представление создания заявки</returns>
        public async Task<ActionResult> Create()
        {
            // создание модели представления
            EquipmentRefillRequestViewModel model = new EquipmentRefillRequestViewModel();
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // получение заявок касающихся авторизованного сотрудника
            var requests = await requestsLogic.GetRequests(user, client: false);
            // инициализации списка заявок в модели представления
            model.Requests = ModelFromData.GetViewModel(requests);
            // Инициализация бокового меню
            await MenuInformation(model);
            // инициализация выпадающего списка представления
            await PopulateDropDownList(model);
            // получение вида заявки
            var service = await serviceLogic.GetService(SERVICE_ID);
            // инициализация модели вида заявки в представлении
            model.ServiceModel = ModelFromData.GetViewModel(service);
            // получаем информацию о лимитах
            await PopulateLimitsInfo(user);
            return View(model);
        }
        /// <summary>
        /// Метод передачи информации о лимитах представлению 
        /// </summary>
        /// <param name="user">Авторизованный сотрудник</param>
        /// <returns></returns>
        private async Task PopulateLimitsInfo(Employee user)
        {
            var refills = await requestLogic.GetRequests(user.Subdivision);
            var limits = await limitsLogic.GetLimit(user.Subdivision);
            ViewBag.RefillsCount = refills.Count + 1;
            ViewBag.LimitsCount = limits.Count;
        }
        /// <summary>
        /// Метод отправки данных страницы создания заявки
        /// </summary>
        /// <param name="model">Модель представления заявки</param>
        /// <returns>Возвращает представления согласно логике метода</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EquipmentRefillRequestViewModel model)
        {
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // инициализация выпадающего списка представления
            await PopulateDropDownList(model);
            // Инициализация бокового меню
            await MenuInformation(model);
            // получаем информацию о лимитах
            await PopulateLimitsInfo(user);
            // создание заявки, согласно модели представления и авторизованного сотрудника
            var request = await InitializeRequest(model, user);
            // получение вида заявки
            var service = await serviceLogic.GetService(SERVICE_ID);
            model.ServiceModel = ModelFromData.GetViewModel(service);
            // если список заправок пуст
            if (model.Refills.Count == 0)
            {
                ModelState.AddModelError("", "Список оборудования требующего заправку пуст.");
                return View(model);
            }
            else
            {
                // создаем список заправок из модели представления
                request.RefillEquipments = new List<RefillEquipments>();
                foreach (var item in model.Refills)
                {
                    // поиск оборудования по инвентарному номеру
                    var equipment = await equipmentLogic.GetEquipment(item.InventoryNumber);
                    if (equipment == null)
                    {
                        ModelState.AddModelError("", $"Оборудование с данным инвентарным номером не найдено: '{item.InventoryNumber}'.");
                        model.Refills = new List<RefillEquipmentViewModel>();
                        return View(model);
                    }
                    RefillEquipments refill = DataFromModel.GetData(item);
                    request.RefillEquipments.Add(refill);
                }
                // сохраняем заявку
                await requestLogic.Save(request);
                // создаем запись жизненного цикла заявки
                await LifeCycleMessage(request.Id, user, "Создание заявки");
                return RedirectToAction("Details", service.Controller, new { id = request.Id });
            }
        }
        /// <summary>
        /// Метод отображения страницы редактирования заявки
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <returns>Возвращает представление редактирования заявки</returns>
        public async Task<ActionResult> Edit(int id)
        {
            // получение заявки по идентификатору
            var request = await requestLogic.GetRequest(id);
            // создание представления заявки
            EquipmentRefillRequestViewModel model = ModelFromData.GetViewModel(request);
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // получение заявок касающихся авторизованного сотрудника
            var requests = await requestsLogic.GetRequests(user, client: false);
            // инициализации списка заявок в модели представления
            model.Requests = ModelFromData.GetViewModel(requests);
            // Инициализация бокового меню
            await MenuInformation(model);
            // инициализация выпадающего списка представления
            await PopulateDropDownList(model);
            return View(model);
        }
        /// <summary>
        /// Метод отправки данных со страницы редактирования заявки
        /// </summary>
        /// <param name="model">Модель представления заявки</param>
        /// <returns>Возвращает представления согласно логике метода</returns>
        [HttpPost]
        public async Task<ActionResult> Edit(EquipmentRefillRequestViewModel model)
        {
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // инициализация выпадающего списка представления
            await PopulateDropDownList(model);
            // Инициализация бокового меню
            await MenuInformation(model);
            // получение вида заявки
            var service = await serviceLogic.GetService(SERVICE_ID);
            model.ServiceModel = ModelFromData.GetViewModel(service);
            // инициализация заявки из модели представления
            var request = DataFromModel.GetData(model);
            // удаляем все записи заправок текущей заявки
            await equipmentsLogic.DeleteEntry(request);
            if (model.Refills.Count == 0)
            {
                ModelState.AddModelError("", "Список оборудования требующего заправку пуст.");
                return View(model);
            }
            else
            {
                // создаем список заправок из модели представления
                List<RefillEquipments> equipments = new List<RefillEquipments>();
                foreach (var item in model.Refills)
                {
                    RefillEquipments refill = DataFromModel.GetData(item);
                    refill.RequestId = request.Id;
                    await equipmentsLogic.Add(refill);
                    equipments.Add(refill);
                }
                request.RefillEquipments = equipments;
                // сохраняем заявку
                await requestLogic.Save(request);
                // создаем запись жизненного цикла заявки
                await LifeCycleMessage(request.Id, user, "Редактирование заявки");
                return RedirectToAction("Details", "EquipmentRefillRequest", new { id = request.Id });
            }
        }
        /// <summary>
        /// Метод отображения страницы удаления заявки
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <returns></returns>
        public async Task<ActionResult> Delete(int id)
        {
            // получение заявки по идентификатору
            var request = await requestLogic.GetRequest(id);
            // инициализация модели
            EquipmentRefillRequestViewModel model = ModelFromData.GetViewModel(request);
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // получение заявок касающихся авторизованного сотрудника
            var requests = await requestsLogic.GetRequests(user, client: false);
            // инициализации списка заявок в модели представления
            model.Requests = ModelFromData.GetViewModel(requests);
            // Инициализация бокового меню
            await MenuInformation(model);
            // отображаем страницу удаления заявки
            return View(model);
        }
        /// <summary>
        /// Метод отправки данных со страницы удаления заявки
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <param name="model">Модель представления</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Delete(int id, EquipmentRefillRequestViewModel model)
        {
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            await PopulateAccountInfo(model);
            // получение заявки по идентификатору
            var request = await requestLogic.GetRequest(id);
            // удаление заявки
            await requestLogic.Delete(request);
            // перенаправление на рабочий стол
            return RedirectToAction("Requests", "Dashboard", new { Area = "" });
        }
        /// <summary>
        /// Метод согласования заявки
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <returns></returns>
        public async Task<ActionResult> AgreeRequest(int id)
        {
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo();
            // изменение статуса заявки 
            await ChangeRequestStatus(id, RequestStatus.Agreed);
            // добавление записи жизненного цикла заявки
            await LifeCycleMessage(id, user, "Заявка прошла согласование");
            // открытие окна заявки
            return RedirectToAction("Requests", "Dashboard", new { Area = "", statusId = (int)RequestStatus.Approval });
        }
        /// <summary>
        /// Метод отмены согласования заявки
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <returns></returns>
        public async Task<ActionResult> RejectRequest(int id)
        {
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo();
            // изменение статуса заявки 
            await ChangeRequestStatus(id, RequestStatus.Closed);
            // добавление записи жизненного цикла заявки
            await LifeCycleMessage(id, user, "Заявка не прошла согласование");
            // открытие окна заявки
            return RedirectToAction("Requests", "Dashboard", new { Area = "", statusId = (int)RequestStatus.Approval });
        }
        /// <summary>
        /// Метод принятия заявки в работу
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <returns></returns>
        public async Task<ActionResult> GetInWork(int id)
        {
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo();
            // получение вида заявки
            var service = await serviceLogic.GetService(SERVICE_ID);
            // изменение статуса заявки 
            await ChangeRequestStatus(id, RequestStatus.InWork, user);
            // добавление записи жизненного цикла заявки
            await LifeCycleMessage(id, user, "Начало исполнения заявки");
            // открытие окна заявки
            return RedirectToAction("Details", service.Controller, new { id });
        }
        /// <summary>
        /// Метод установки отметки о выполнении заявки
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <returns></returns>
        public async Task<ActionResult> DoneWork(int id)
        {
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo();
            // получение вида заявки
            var service = await serviceLogic.GetService(SERVICE_ID);
            // изменение статуса заявки 
            await ChangeRequestStatus(id, RequestStatus.Done);
            // добавление записи жизненного цикла заявки
            await LifeCycleMessage(id, user, "Заявка выполнена");
            // открытие окна заявки
            return RedirectToAction("Details", service.Controller, new { id });
        }
        /// <summary>
        /// Метод перевода заявки в архив
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <returns></returns>
        public async Task<ActionResult> Close(int id)
        {
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo();
            // получение вида заявки
            var service = await serviceLogic.GetService(SERVICE_ID);
            // изменение статуса заявки 
            await ChangeRequestStatus(id, RequestStatus.Closed);
            // добавление записи жизненного цикла заявки
            await LifeCycleMessage(id, user, "Заявка закрыта");
            // открытие окна заявки
            return RedirectToAction("Details", service.Controller, new { id });
        }
        /// <summary>
        /// Метод перевода заявки в архив
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <returns></returns>
        public async Task<ActionResult> Archive(int id)
        {
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo();
            // получение вида заявки
            var service = await serviceLogic.GetService(SERVICE_ID);
            // изменение статуса заявки 
            await ChangeRequestStatus(id, RequestStatus.Archive);
            // добавление записи жизненного цикла заявки
            await LifeCycleMessage(id, user, "Заявка перенесена в архив");
            // открытие окна заявки
            return RedirectToAction("Details", service.Controller, new { id });
        }
        /// <summary>
        /// Метод добавления сообщения в жизненный цикл заявки
        /// </summary>
        /// <param name="id">Идентификатор заявки</param>
        /// <returns></returns>
        public async Task<ActionResult> AddMessage(int id, EquipmentRefillDetailsRequestViewModel model)
        {
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo();
            // получение вида заявки
            var service = await serviceLogic.GetService(SERVICE_ID);
            // добавление записи жизненного цикла заявки
            await LifeCycleMessage(id, user, model.Message);
            // открытие окна заявки
            return RedirectToAction("Details", service.Controller, new { id });
        }
    }
}