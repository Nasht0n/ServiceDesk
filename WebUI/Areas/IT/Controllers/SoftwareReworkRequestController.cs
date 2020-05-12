using BusinessLogic.Abstract;
using BusinessLogic.Abstract.Branches.IT.Softwares.Attachments;
using BusinessLogic.Abstract.Branches.IT.Softwares.LifeCycles;
using BusinessLogic.Abstract.Branches.IT.Softwares.Requests;
using Domain.Models;
using Domain.Models.ManyToMany;
using Domain.Models.Requests.Software;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.Models.Enum;
using WebUI.Models.Helpers;
using WebUI.ViewModels;
using WebUI.ViewModels.AttachmentsModel;
using WebUI.ViewModels.AttachmentsModel.IT.Softwares;
using WebUI.ViewModels.Requests.IT.Softwares;
using static WebUI.ViewModels.CategoryStats;

namespace WebUI.Areas.IT.Controllers
{
    [Authorize]
    public class SoftwareReworkRequestController : Controller
    {
        // Идентификатор вида заявки
        private const int SERVICE_ID = 19;
        // Логика для работы с данными
        private readonly IAccountLogic accountLogic;
        private readonly IEmployeeLogic employeeLogic;
        private readonly IAccountPermissionLogic accountPermissionLogic;
        private readonly IPriorityLogic priorityLogic;
        private readonly IServiceLogic serviceLogic;
        private readonly ISubdivisionLogic subdivisionLogic;
        private readonly ISoftwareReworkRequestLogic requestLogic;
        private readonly ISoftwareReworkRequestLifeCycleLogic lifeCycleLogic;
        private readonly IBranchLogic branchLogic;
        private readonly ICategoryLogic categoryLogic;
        private readonly IRequestsLogic requestsLogic;
        private readonly IAttachmentLogic attachmentLogic;
        private readonly ISoftwareReworkRequestAttachmentLogic requestAttachmentLogic;

        public SoftwareReworkRequestController(IAccountLogic accountLogic, IEmployeeLogic employeeLogic, IAccountPermissionLogic accountPermissionLogic,
            IPriorityLogic priorityLogic, IServiceLogic serviceLogic, ISubdivisionLogic subdivisionLogic, ISoftwareReworkRequestLogic requestLogic,
            ISoftwareReworkRequestLifeCycleLogic lifeCycleLogic, IBranchLogic branchLogic, ICategoryLogic categoryLogic, IRequestsLogic requestsLogic,
            IAttachmentLogic attachmentLogic, ISoftwareReworkRequestAttachmentLogic requestAttachmentLogic)
        {
            this.accountLogic = accountLogic;
            this.employeeLogic = employeeLogic;
            this.accountPermissionLogic = accountPermissionLogic;
            this.priorityLogic = priorityLogic;
            this.serviceLogic = serviceLogic;
            this.subdivisionLogic = subdivisionLogic;
            this.requestLogic = requestLogic;
            this.lifeCycleLogic = lifeCycleLogic;
            this.branchLogic = branchLogic;
            this.categoryLogic = categoryLogic;
            this.requestsLogic = requestsLogic;
            this.attachmentLogic = attachmentLogic;
            this.requestAttachmentLogic = requestAttachmentLogic;
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
        private async Task PopulateDropDownList(SoftwareReworkRequestViewModel model)
        {
            var priorities = await priorityLogic.GetPriorities();
            model.Priorities = new SelectList(priorities, "Id", "Fullname");
        }
        /// <summary>
        /// Метод инициализации заявки
        /// </summary>
        /// <param name="model">Модель заявки</param>
        /// <param name="user">Авторизованный сотрудник</param>
        /// <returns>Возвращает объект заявки</returns>
        private async Task<SoftwareReworkRequest> InitializeRequest(SoftwareReworkRequestViewModel model, Employee user)
        {
            // создание заявки
            SoftwareReworkRequest request = new SoftwareReworkRequest();
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
        private SoftwareReworkRequestLifeCycle InitializeLifeCycle(int requestId, Employee user, string message)
        {
            // создание записи жизненного цикла заявки
            SoftwareReworkRequestLifeCycle lifeCycle = new SoftwareReworkRequestLifeCycle();
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
        private async Task ChangeRequestStatus(int id, RequestStatus status)
        {
            // получаем заявку по идентификатору
            var request = await requestLogic.GetRequest(id);
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
            SoftwareReworkDetailsRequestViewModel model = new SoftwareReworkDetailsRequestViewModel();
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // получение заявок касающихся авторизованного сотрудника
            var requests = await requestsLogic.GetRequests(user, client: false);
            // инициализации списка заявок в модели представления
            model.Requests = ModelFromData.GetViewModel(requests);
            // Инициализация бокового меню
            await MenuInformation(model);
            // поиск заявки по идентификатору
            var request = await requestLogic.GetRequest(id);
            // получение вида заявки
            var service = await serviceLogic.GetService(request.ServiceId);
            // получение списка жизненного цикла заявки
            var lifeCycles = await lifeCycleLogic.GetLifeCycles(request);
            // инициализация модели представления
            model = ModelFromData.GetViewModel(model, request, user, lifeCycles);
            // проверка: прошла ли заявка полное согласование (при множественном согласовании)
            model.AllApproval = IsApproval(service, lifeCycles);
            // отображаем представление 
            return View(model);
        }
        /// <summary>
        /// Метод проверки заявки на полное согласование (множественное)
        /// </summary>
        /// <param name="service">Вид заявки</param>
        /// <param name="lifeCycles">Жизненный цикл заявки</param>
        /// <returns>Возвращает true — если заявка согласована, иначе false</returns>
        private bool IsApproval(Service service, List<SoftwareReworkRequestLifeCycle> lifeCycles)
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
            SoftwareReworkRequestViewModel model = new SoftwareReworkRequestViewModel();
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
            return View(model);
        }
        /// <summary>
        /// Метод отправки данных страницы создания заявки
        /// </summary>
        /// <param name="model">Модель представления заявки</param>
        /// <returns>Возвращает представления согласно логике метода</returns>
        [HttpPost]
        public async Task<ActionResult> Create(SoftwareReworkRequestViewModel model)
        {
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // инициализация выпадающего списка представления
            await PopulateDropDownList(model);
            // Инициализация бокового меню
            await MenuInformation(model);
            // создание заявки, согласно модели представления и авторизованного сотрудника
            var request = await InitializeRequest(model, user);
            // получение вида заявки
            var service = await serviceLogic.GetService(SERVICE_ID);
            // обход прикрепленных файлов к заявке
            foreach (var file in model.Files)
            {
                // получаем имя файла
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                // получаем расширение файла
                string fileExtension = Path.GetExtension(file.FileName);
                // путь к сохранению файлов
                string uploadPath = Server.MapPath("~/Files/UploadedFiles/SoftwareAttachments/");
                // получение полного пути к файлу
                var filePath = uploadPath + fileName.Trim() + fileExtension;
                // инициализация пути к файлу
                model.FilePath = filePath;
                // сохранение файла на жесткий диск сервера
                file.SaveAs(model.FilePath);
                // создаем запись о прикрепленном файле в БД
                // указываем дату загрузки файла
                // наименование файла
                // путь к файлу
                Attachment attachmentFile = new Attachment
                {
                    DateUploaded = DateTime.Now,
                    Filename = fileName,
                    Path = filePath
                };
                // сохраняем информацию о прикрепленном файле
                attachmentFile = await attachmentLogic.Save(attachmentFile);
                // создаем объект прикреплений данного вида заявки
                // инициализируем идентификатор прикрепленного файла
                SoftwareReworkRequestAttachment attachment = new SoftwareReworkRequestAttachment
                {
                    AttachmentId = attachmentFile.Id
                };
                // добавляем данные прикрепленных файлов к заявке
                request.Attachments.Add(attachment);
            }
            // сохраняем заявку
            await requestLogic.Save(request);
            // создаем запись о создании заявки в жизненный цикл заявки
            await LifeCycleMessage(request.Id, user, "Создание заявки");
            // открываем страницу просмотра заявки
            return RedirectToAction("Details", service.Controller, new { id = request.Id });
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
            SoftwareReworkRequestViewModel model = ModelFromData.GetViewModel(request);
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
            // получение списка прикрепленных файлов к заявке
            var attachments = await requestAttachmentLogic.GetAttachments(request);
            // обход по прикреплениям
            foreach (var attachment in attachments)
            {
                // получение файла
                Attachment file = await attachmentLogic.GetAttachment(attachment.AttachmentId);
                // инициализация модели прикрепленного файла
                AttachmentViewModel attachmentModel = ModelFromData.GetViewModel(file);
                // добавление прикрепленного файла в модель представления
                model.AttachmentsModel.Add(new SoftwareReworkRequestAttachmentViewModel { AttachmentModel = attachmentModel });
            }
            // возвращаем представление редактирования заявки
            return View(model);
        }
        /// <summary>
        /// Метод отправки данных со страницы редактирования заявки
        /// </summary>
        /// <param name="model">Модель представления заявки</param>
        /// <returns>Возвращает представления согласно логике метода</returns>
        [HttpPost]
        public async Task<ActionResult> Edit(SoftwareReworkRequestViewModel model)
        {
            // получение данных об авторизованном сотруднике
            // инициализация конфигурации
            var user = await PopulateAccountInfo(model);
            // инициализация выпадающего списка представления
            await PopulateDropDownList(model);
            // Инициализация бокового меню
            await MenuInformation(model);
            // инициализация заявки из модели представления
            var request = DataFromModel.GetData(model);
            // получение вида заявки
            var service = await serviceLogic.GetService(SERVICE_ID);
            // обход прикрепленных файлов к заявке
            foreach (var file in model.Files)
            {
                if (file != null)
                {
                    // получаем имя файла
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    // получаем расширение файла
                    string fileExtension = Path.GetExtension(file.FileName);
                    // путь к сохранению файлов
                    string uploadPath = Server.MapPath("~/Files/UploadedFiles/SoftwareAttachments/");
                    // получение полного пути к файлу
                    var filePath = uploadPath + fileName.Trim() + fileExtension;
                    // инициализация пути к файлу
                    model.FilePath = filePath;
                    // сохранение файла на жесткий диск сервера
                    file.SaveAs(model.FilePath);
                    // создаем запись о прикрепленном файле в БД
                    // указываем дату загрузки файла
                    // наименование файла
                    // путь к файлу
                    Attachment attachmentFile = new Attachment
                    {
                        DateUploaded = DateTime.Now,
                        Filename = fileName,
                        Path = filePath
                    };
                    // сохраняем информацию о прикрепленном файле
                    attachmentFile = await attachmentLogic.Save(attachmentFile);
                    // создаем объект прикреплений данного вида заявки
                    // инициализируем идентификатор прикрепленного файла
                    SoftwareReworkRequestAttachment attachment = new SoftwareReworkRequestAttachment
                    {
                        AttachmentId = attachmentFile.Id,
                        RequestId = request.Id
                    };
                    // добавляем данные прикрепленных файлов к заявке
                    await requestAttachmentLogic.Add(attachment);
                }
            }
            // сохраняем заявку
            await requestLogic.Save(request);
            // создаем запись о создании заявки в жизненный цикл заявки
            await LifeCycleMessage(request.Id, user, "Редактирование заявки");
            return RedirectToAction("Details", service.Controller, new { id = request.Id });
        }
        /// <summary>
        /// Метод удаления файла
        /// </summary>
        /// <param name="requestId">Идентификатор заявки</param>
        /// <param name="attachmentId">Идентификатор прикрепленного файла</param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteFile(int requestId, int attachmentId)
        {
            // получение вида заявок
            var service = await serviceLogic.GetService(SERVICE_ID);
            // получение прикрепленного файла
            var attachment = await attachmentLogic.GetAttachment(attachmentId);
            // удаление прикрепленного файла
            await attachmentLogic.Delete(attachment);
            // перенаправление на просмотр данных о заявке
            return RedirectToAction("Details", service.Controller, new { id = requestId });
        }
        /// <summary>
        /// Метод скачивания прикрепленного файла с сервера
        /// </summary>
        /// <param name="attachmentId">Идентификатор прикрепленного файла</param>
        /// <returns></returns>
        public async Task<FileResult> DownloadFile(int attachmentId)
        {
            // получение данных о прикрепленном файле
            var file = await attachmentLogic.GetAttachment(attachmentId);
            // инициализация наименование файла
            string filename = file.Filename + Path.GetExtension(file.Path);
            // получение типа файла
            string file_type = MimeMapping.GetMimeMapping(filename);
            // скачиваем выбранный файл с сервера
            return File(file.Path, file_type, filename);
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
            SoftwareReworkRequestViewModel model = ModelFromData.GetViewModel(request);
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
        public async Task<ActionResult> Delete(int id, SoftwareReworkRequestViewModel model)
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
            // получение вида заявки
            var service = await serviceLogic.GetService(SERVICE_ID);
            // изменение статуса заявки 
            await ChangeRequestStatus(id, RequestStatus.Open);
            // добавление записи жизненного цикла заявки
            await LifeCycleMessage(id, user, "Заявка прошла согласование");
            // открытие окна заявки
            return RedirectToAction("Requests", "Dashboard", new { Area = "", statusId = "4" });
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
            // получение вида заявки
            var service = await serviceLogic.GetService(SERVICE_ID);
            // изменение статуса заявки 
            await ChangeRequestStatus(id, RequestStatus.Closed);
            // добавление записи жизненного цикла заявки
            await LifeCycleMessage(id, user, "Заявка не прошла согласование");
            // открытие окна заявки
            return RedirectToAction("Requests", "Dashboard", new { Area = "", statusId = "4" });
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
            // получение заявки
            var request = await requestLogic.GetRequest(id);
            // инициализация идентификатора исполнителя
            request.ExecutorId = user.Id;
            // сохранение изменений
            await requestLogic.Save(request);
            // изменение статуса заявки 
            await ChangeRequestStatus(id, RequestStatus.InWork);
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
        public async Task<ActionResult> AddMessage(int id, SoftwareDevelopmentDetailsRequestViewModel model)
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