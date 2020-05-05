using BusinessLogic.Abstract;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels;
using WebUI.ViewModels.BranchModel;
using WebUI.ViewModels.CategoryModel;
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

        public DashboardController(IAccountLogic accountLogic, IAccountPermissionLogic accountPermissionLogic,
            IEmployeeLogic employeeLogic, IBranchLogic branchLogic, ICategoryLogic categoryLogic, IServiceLogic serviceLogic,
            IRequestsLogic requestsLogic, IStatusLogic statusLogic)
        {
            this.accountLogic = accountLogic;
            this.accountPermissionLogic = accountPermissionLogic;
            this.employeeLogic = employeeLogic;
            this.branchLogic = branchLogic;
            this.categoryLogic = categoryLogic;
            this.serviceLogic = serviceLogic;
            this.requestsLogic = requestsLogic;
            this.statusLogic = statusLogic;
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
            foreach(var category in categories)
            {
                CategoryInfo info = new CategoryInfo(model.Requests);
                info.CategoryModel = ModelFromData.GetViewModel(category);
                model.MenuInformation.CategoryStats.CategoryInfos.Add(info);
            }                      
        }
        /// <summary>
        /// Метод отображения главной страницы рабочего стола
        /// </summary>
        /// <returns>Представление рабочего стола</returns>
        public async Task<ActionResult> Index()
        {
            // инициализация модели представления
            DashboardViewModel model = new DashboardViewModel();
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // получение заявок касающихся авторизованного сотрудника
            var requests = await requestsLogic.GetRequests(user);
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
        public async Task<ActionResult> Requests(int categoryId = 0,int serviceId = 0, int statusId = 0)
        {
            // инициализация модели представления
            RequestListViewModel model = new RequestListViewModel();
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // получени категории заявок по указанному идентификатору
            var category = await categoryLogic.GetCategory(categoryId);
            // получение вида заявок по указанному идентификатору
            var service = await serviceLogic.GetService(serviceId);
            // получение статуса заявок по указанному идентификатору
            var status = await statusLogic.GetStatus(statusId);
            // получение списка заявок
            var requests = await requestsLogic.GetRequests(user, category,service, status);
            // инициализации списка заявок в модели представления
            model.Requests = ModelFromData.GetViewModel(requests);
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
            var requests = await requestsLogic.GetRequests(user);
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
            var requests = await requestsLogic.GetRequests(user);
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
            var requests = await requestsLogic.GetRequests(user);
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
    }
}