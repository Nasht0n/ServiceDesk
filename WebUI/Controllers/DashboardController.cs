using BusinessLogic.Abstract;
using BusinessLogic.Abstract.Branches.IT.Equipments.Consumption;
using Domain.Models;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels;
using WebUI.ViewModels.BranchModel;
using WebUI.ViewModels.CategoryModel;
using WebUI.ViewModels.ExecutorGroupModel;
using WebUI.ViewModels.Requests.View;
using WebUI.ViewModels.ServiceModel;
using static WebUI.ViewModels.CategoryStats;
using static WebUI.ViewModels.DashboardViewModel;

namespace WebUI.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IAccountLogic accountLogic;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IBranchLogic branchLogic;
        private readonly ICategoryLogic categoryLogic;
        private readonly IServiceLogic serviceLogic;
        private readonly IRequestsLogic requestsLogic;
        private readonly IStatusLogic statusLogic;
        private readonly IExecutorGroupLogic executorGroupLogic;
        private readonly IRefillRequestJournalLogic refillJournalLogic;
        private readonly IRefillRequestConsumptionLogic consumptionLogic;

        public DashboardController(IAccountLogic accountLogic, IAccountPermissionLogic accountPermissionLogic,
            IEmployeeLogic employeeLogic, IBranchLogic branchLogic, ICategoryLogic categoryLogic, IServiceLogic serviceLogic,
            IRequestsLogic requestsLogic, IStatusLogic statusLogic, IExecutorGroupLogic executorGroupLogic,
            IRefillRequestJournalLogic refillJournalLogic, IRefillRequestConsumptionLogic consumptionLogic)
        {
            this.accountLogic = accountLogic;
            this.accountPermissionLogic = accountPermissionLogic;
            this.employeeLogic = employeeLogic;
            this.branchLogic = branchLogic;
            this.categoryLogic = categoryLogic;
            this.serviceLogic = serviceLogic;
            this.requestsLogic = requestsLogic;
            this.statusLogic = statusLogic;
            this.executorGroupLogic = executorGroupLogic;
            this.refillJournalLogic = refillJournalLogic;
            this.consumptionLogic = consumptionLogic;
        }
        /// <summary>
        /// Метод получения данных информации об авторизованном пользователе в системе.
        /// Инициализация данных рабочего пространства
        /// </summary>
        /// <param name="model">Модель конфигурации рабочего стола</param>
        /// <returns>Возвращает объект авторизованного сотрудника</returns>
        public async Task<Employee> PopulateAccountInfo(DashboardConfigurationViewModel model)
        {
            // получение идентификатора учетной записи
            int id = int.Parse(User.Identity.Name);
            // поиск учетной записи сотрудника
            var account = await accountLogic.GetAccount(id);
            // поиск данных сотрудника
            var user = await employeeLogic.GetEmployee(account.EmployeeId);
            // инициализация полей конфигурации
            // передача информации о сотруднике
            model.CurrentUser = ModelFromData.GetViewModel(user);
            model.UserExecutorGroups = new List<ExecutorGroupViewModel>();
            foreach (var userGroup in user.ExecutorGroups)
            {
                var group = await executorGroupLogic.GetExecutorGroup(userGroup.ExecutorGroupId);
                var temp = ModelFromData.GetViewModel(group);
                model.UserExecutorGroups.Add(temp);
            }
            // инициализация прав доступа учетной записи
            model.UserPermissions = new UserPermissions();
            model.UserPermissions.Permissions = await accountPermissionLogic.GetPermissions(account);
            model.UserPermissions.Account = ModelFromData.GetViewModel(account);
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
            model.StartPeriodDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            model.EndPeriodDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }
        /// <summary>
        /// Метод отображения главной страницы рабочего стола
        /// </summary>
        /// <returns>Представление рабочего стола</returns>
        public async Task<ActionResult> Index(bool lastMonth = false)
        {
            // инициализация модели представления
            DashboardViewModel model = new DashboardViewModel();
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // получаем данные учетной записи
            var account = await accountLogic.GetAccount(user);
            // получение заявок касающихся авторизованного сотрудника
            var requests = await requestsLogic.GetRequests(account);
            if (lastMonth)
            {
                int month = DateTime.Now.Month;
                requests = requests.Where(r => r.Date.Month == month).ToList();
            }
            // инициализации списка заявок в модели представления
            model.Requests = ModelFromData.GetViewModel(requests);
            // инициализация таблицы данных статистики видов заявок
            model.ServicesInfos = await InitializeServicesInfos(model.Requests);
            await MenuInformation(model);
            // отображение представления
            return View(model);
        }
        /// <summary>
        /// Метод получения статистических данных таблицы видов заявок
        /// </summary>
        /// <param name="requests">Список заявок</param>
        /// <returns>Возвращаем статистику видов работ</returns>
        private async Task<List<ServicesStats>> InitializeServicesInfos(List<RequestViewModel> requests)
        {
            // получение списка активных видов заявок
            var services = await serviceLogic.GetActiveServices();
            // инициализация списка результатов
            List<ServicesStats> result = new List<ServicesStats>();
            // обход списка видов заявок
            foreach (var service in services)
            {
                // инициализация текущего вида заявок
                ServicesStats item = new ServicesStats(requests);
                // получение данных видов заявок
                item.ServiceModel = ModelFromData.GetViewModel(service);
                // если вид заявок содержит заявки - добавляем в список результата
                if (item.TotalCount != 0) result.Add(item);
            }
            // возвращаем список статистики
            return result;
        }
        /// <summary>
        /// Метод отображения страницы "Каталог заявок"
        /// </summary>
        /// <param name="serviceId">Идентификатор вида заявок</param>
        /// <returns>Представление каталога заявок</returns>
        public async Task<ActionResult> Requests(int categoryId = 0, int serviceId = 0, int statusId = 0, bool inWork = false, bool approver = false)
        {
            // инициализация модели представления
            RequestListViewModel model = new RequestListViewModel();
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // получаем данные учетной записи
            var account = await accountLogic.GetAccount(user);
            // получени категории заявок по указанному идентификатору
            var category = await categoryLogic.GetCategory(categoryId);
            model.CategoryModel = ModelFromData.GetViewModel(category);
            // получение вида заявок по указанному идентификатору
            var service = await serviceLogic.GetService(serviceId);
            model.ServiceModel = ModelFromData.GetViewModel(service);
            // получение статуса заявок по указанному идентификатору
            var status = await statusLogic.GetStatus(statusId);
            model.StatusModel = ModelFromData.GetViewModel(status);
            model.InWork = inWork;
            model.Approver = approver;
            // получение заявок, которые каким-либо образом относятся к пользователю
            var requests = await requestsLogic.GetRequests(account);
            // список меню
            model.Requests = ModelFromData.GetViewModel(requests);
            // получение списка заявок
            //requests = await requestsLogic.GetRequests(account, category, service, status, IsClient);            
            await MenuInformation(model);
            // отображение представления
            return View(model);
        }
        /// <summary>
        /// Метод отображения страницы "Выбор отрасли заявки"
        /// </summary>
        /// <returns>Представление выбора отрасли заявки</returns>
        public async Task<ActionResult> ChooseBranch()
        {
            // инициализация модели представления
            BranchesListViewModel model = new BranchesListViewModel();
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // получение заявок касающихся авторизованного сотрудника
            var requests = await requestsLogic.GetRequests(user, client: false);
            // инициализации списка заявок в модели представления
            model.Requests = ModelFromData.GetViewModel(requests);
            // получение списка отраслей заявки
            var branches = await branchLogic.GetBranches();
            // инициализация списка отраслей заявки
            model.Branches = ModelFromData.GetViewModel(branches);
            await MenuInformation(model);
            // отображение представления
            return View(model);
        }
        /// <summary>
        /// Метод отображения страницы "Выбор категории заявки"
        /// </summary>
        /// <param name="branchId">Идентификатор отрасли заявки</param>
        /// <returns>Представление выбора категории заявки</returns>
        public async Task<ActionResult> ChooseCategory(int branchId)
        {
            // инициализация модели представления
            CategoriesListViewModel model = new CategoriesListViewModel();
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // получение заявок касающихся авторизованного сотрудника
            var requests = await requestsLogic.GetRequests(user, client: false);
            // инициализации списка заявок в модели представления
            model.Requests = ModelFromData.GetViewModel(requests);
            // получение отрасли заявки по идентификатору
            var branch = await branchLogic.GetBranch(branchId);
            // получение списка категорий заявки текущей отрасли заявки
            var categories = await categoryLogic.GetCategories(branch);
            // инициализация списка категорий заявки
            model.Categories = ModelFromData.GetViewModel(categories);
            await MenuInformation(model);
            // отображение представления
            return View(model);
        }
        /// <summary>
        /// Метод отображения страницы "Выбор вида заявки"
        /// </summary>
        /// <param name="categoryId">Идентификатор категории заявки</param>
        /// <returns>Представление выбора вида заявки</returns>
        public async Task<ActionResult> ChooseService(int categoryId)
        {
            // инициализация модели представления
            ServicesListViewModel model = new ServicesListViewModel();
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // получение заявок касающихся авторизованного сотрудника
            var requests = await requestsLogic.GetRequests(user, client: false);
            // инициализации списка заявок в модели представления
            model.Requests = ModelFromData.GetViewModel(requests);
            // получение категории заявки по идентификатору
            var category = await categoryLogic.GetCategory(categoryId);
            // инициализация категории заявки
            model.CategoryModel = ModelFromData.GetViewModel(category);
            // получение списка видов работ
            var services = await serviceLogic.GetActiveServices(category);
            // инициализация списка категорий заявки
            model.Services = ModelFromData.GetViewModel(services);
            await MenuInformation(model);
            // отображение представления
            return View(model);
        }

        public async Task<ActionResult> Profile()
        {
            ProfileViewModel model = new ProfileViewModel();
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // получение заявок касающихся авторизованного сотрудника
            var requests = await requestsLogic.GetRequests(user, client: false);
            // инициализации списка заявок в модели представления
            model.Requests = ModelFromData.GetViewModel(requests);
            await MenuInformation(model);

            var employee = await employeeLogic.GetEmployee(user.Id);
            model.Employee = ModelFromData.GetViewModel(employee);
            var account = await accountLogic.GetAccount(employee);
            model.Account = ModelFromData.GetViewModel(account);
            return View(model);
        }

        public FileResult Manual()
        {
            // Путь к файлу
            string file_path = Server.MapPath("~/Files/SERVICE DESK. Руководство пользователя.pdf");
            // Тип файла - content-type
            string file_type = "application/pdf";
            return File(file_path, file_type);
        }

        [HttpGet]
        public async Task<ActionResult> Feedback()
        {
            FeedbackViewModel model = new FeedbackViewModel();
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // получаем данные учетной записи
            var account = await accountLogic.GetAccount(user);
            // получение заявок касающихся авторизованного сотрудника
            var requests = await requestsLogic.GetRequests(account);
            // инициализации списка заявок в модели представления
            model.Requests = ModelFromData.GetViewModel(requests);
            var employee = await employeeLogic.GetEmployee(user.Id);
            model.Name = employee.Firstname;
            await MenuInformation(model);
            // отображение представления
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Feedback(FeedbackViewModel model)
        {
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // получаем данные учетной записи
            var account = await accountLogic.GetAccount(user);
            // получение заявок касающихся авторизованного сотрудника
            var requests = await requestsLogic.GetRequests(account);
            // инициализации списка заявок в модели представления
            model.Requests = ModelFromData.GetViewModel(requests);
            await MenuInformation(model);
            if (ModelState.IsValid)
            {                
                MailSender.SendFeedback(model.Name, model.Message);
                return RedirectToAction("Index", "Dashboard", new { Area = "" });
            }
            
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> DownloadJournalReport(DashboardViewModel model)
        {
            string fileName = "Входящая корреспонденция.xlsx";
            string path = Server.MapPath("~/Files/Templates/") + fileName;
            string type = MimeTypes.GetMimeType(fileName);

            var startDate = model.StartPeriodDate;
            var endDate = model.EndPeriodDate;

            var journal = await refillJournalLogic.GetJournal(startDate, endDate);                
            try
            {
                var workbook = ReportManager.CreateConsumptionReport(path, journal, startDate, endDate);
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, type, fileName);
                }
            }
            catch (Exception)
            {                   
                throw;
            }
        }
    }
}