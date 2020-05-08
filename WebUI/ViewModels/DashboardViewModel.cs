using Domain.Views;
using System.Collections.Generic;
using System.Linq;
using WebUI.Models.Enum;
using WebUI.ViewModels.Requests.View;
using WebUI.ViewModels.ServiceModel;

namespace WebUI.ViewModels
{
    public class DashboardViewModel : DashboardConfigurationViewModel
    {
        // Количество отображаемых заявок пользователя 
        private readonly int LastRequestCount = 3;
        // Список отображаемых заявок, с участием пользователя
        public List<RequestViewModel> LastRequests
        {
            get
            {
                return Requests.Take(LastRequestCount).OrderByDescending(r => r.Date).ToList();
            }
        }
        // Таблица статистики видов работ
        public List<ServicesStats> ServicesInfos { get; set; }
        // Количество заявок открытых пользователем
        public int CountCreatedRequest
        {
            get
            {
                return Requests.Where(r => r.ClientId == CurrentUser.Id).Count();
            }
        }
        // Количество заявок в работе
        public int CountExecutedRequest
        {
            get
            {
                return Requests.Where(r => r.ExecutorId == CurrentUser.Id).Count();
            }
        }
        // Количество выполненных заявок
        public int CountCompletedRequest
        {
            get
            {
                return Requests.Where(r => r.StatusId == (int)RequestStatus.Done).Count();
            }
        }
        // Количество заявок требующих согласования
        public int CountApprovalRequest
        {
            get
            {
                return Requests.Where(r => r.StatusId == (int)RequestStatus.Approval).Count();
            }
        }

        // Класс статистики видов работ
        public class ServicesStats
        {
            private readonly List<RequestViewModel> requests;

            public ServicesStats(List<RequestViewModel> requests)
            {
                this.requests = requests;
            }
            // Вид работы
            public ServiceViewModel ServiceModel { get; set; }
            // Открыто заявок
            public int OpenCount
            {
                get { return requests.Where(r => r.ServiceId == ServiceModel.Id && r.StatusId == (int) RequestStatus.Open).Count(); }
            }
            // Открыто заявок
            public int ApprovalCount
            {
                get { return requests.Where(r => r.ServiceId == ServiceModel.Id && r.StatusId == (int)RequestStatus.Approval).Count(); }
            }
            // Заявок в работе
            public int InWorkCount
            {
                get { return requests.Where(r => r.ServiceId == ServiceModel.Id && r.StatusId == (int) RequestStatus.InWork).Count(); }
            }
            // Выполнено заявок
            public int DoneCount
            {
                get { return requests.Where(r => r.ServiceId == ServiceModel.Id && r.StatusId == (int) RequestStatus.Done).Count(); }
            }
            // Всего заявок данного вида работы
            public int TotalCount
            {
                get { return requests.Where(r => r.ServiceId == ServiceModel.Id).Count(); }
            }
        }
    }

}