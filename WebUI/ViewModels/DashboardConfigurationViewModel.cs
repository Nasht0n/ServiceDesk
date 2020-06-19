using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Linq;
using WebUI.Models.Enum;
using WebUI.ViewModels.AccountModel;
using WebUI.ViewModels.BranchModel;
using WebUI.ViewModels.CategoryModel;
using WebUI.ViewModels.EmployeeModel;
using WebUI.ViewModels.ExecutorGroupModel;
using WebUI.ViewModels.Requests.View;

namespace WebUI.ViewModels
{
    public abstract class DashboardConfigurationViewModel
    {
        // Текущий пользователь
        public EmployeeViewModel CurrentUser { get; set; }
        public List<ExecutorGroupViewModel> UserExecutorGroups { get; set; }

        // Права доступа пользователя
        public UserPermissions UserPermissions { get; set; }
        // Список всех заявок
        public List<RequestViewModel> Requests { get; set; }
        // Всплывающее меню
        public MenuStats MenuInformation { get; set; }
    }
    // Права доступа пользователя
    public class UserPermissions
    {
        // Учетная запись пользователя
        public AccountViewModel Account { get; set; }
        // Список прав доступа
        public List<AccountPermission> Permissions { get; set; }
        // Право на добавление новой заявки
        public bool AddRequest { get { return Permissions.Where(p => p.AccountId == Account.Id && p.PermissionId == (int)AccountPermissionEnum.AddRequest).Any(); } }
        // Право на редактирование заявки
        public bool EditRequest { get { return Permissions.Where(p => p.AccountId == Account.Id && p.PermissionId == (int)AccountPermissionEnum.EditRequest).Any(); } }
        // Право на удаление заявки
        public bool DeleteRequest { get { return Permissions.Where(p => p.AccountId == Account.Id && p.PermissionId == (int)AccountPermissionEnum.DeleteRequest).Any(); } }
        // Право на доступ к панели управления
        public bool AccessToControlPanel { get { return Permissions.Where(p => p.AccountId == Account.Id && p.PermissionId == (int)AccountPermissionEnum.AccessToControlPanel).Any(); } }
        // Право просмотра заявок
        public bool ViewRequest { get { return Permissions.Where(p => p.AccountId == Account.Id && p.PermissionId == (int)AccountPermissionEnum.ViewRequest).Any(); } }
        // Право согласования заявки
        public bool ApprovalAllowed { get { return Permissions.Where(p => p.AccountId == Account.Id && p.PermissionId == (int)AccountPermissionEnum.ApprovalAllowed).Any(); } }
        // Право принятия заявки в работу
        public bool GetInWorkRequest { get { return Permissions.Where(p => p.AccountId == Account.Id && p.PermissionId == (int)AccountPermissionEnum.GetInWorkRequest).Any(); } }
        // Право обратного отзыва
        public bool Feedback { get { return Permissions.Where(p => p.AccountId == Account.Id && p.PermissionId == (int)AccountPermissionEnum.Feedback).Any(); } }
    }

    // Класс статистики бокового меню рабочего стола
    public class MenuStats
    {
        // Список отраслей заявки
        public List<BranchViewModel> Branches { get; set; }
        // Статистика категории заявки
        public CategoryStats CategoryStats { get; set; }
    }
    // Класс статистики категории заявки
    public class CategoryStats
    {
        // Список категорий
        public List<CategoryInfo> CategoryInfos { get; set; }
        // Класс информации о категории
        public class CategoryInfo
        {
            private readonly List<RequestViewModel> requests;

            public CategoryInfo(List<RequestViewModel> Requests)
            {
                requests = Requests;
            }

            public CategoryViewModel CategoryModel { get; set; }
            // Открыто заявок
            public int OpenCount
            {
                get
                {
                    if (requests != null)
                        return requests.Where(r => r.ServiceModel.CategoryModel.Id == CategoryModel.Id && r.StatusId != (int)RequestStatus.Closed).Count();
                    else
                        return 0;
                }
            }
            // Заявок в работе
            public int InWorkCount
            {
                get
                {
                    if (requests != null)
                        return requests.Where(r => r.ServiceModel.CategoryModel.Id == CategoryModel.Id && r.StatusId == (int)RequestStatus.InWork).Count();
                    else
                        return 0;
                }

            }
            // Выполнено заявок
            public int DoneCount
            {
                get
                {
                    if (requests != null) return requests.Where(r => r.ServiceModel.CategoryModel.Id == CategoryModel.Id && r.StatusId == (int)RequestStatus.Done).Count();
                    else
                        return 0;
                }
            }
            // Всего заявок данного вида работы
            public int TotalCount
            {
                get
                {
                    if (requests != null) return requests.Where(r => r.ServiceModel.CategoryModel.Id == CategoryModel.Id).Count();
                    else
                        return 0;
                }
            }
        }
    }

}