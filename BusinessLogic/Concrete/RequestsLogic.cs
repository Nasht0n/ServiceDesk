using BusinessLogic.Abstract;
using Domain.Models;
using Domain.Views;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class RequestsLogic : IRequestsLogic
    {
        private readonly IRequestRepository requestRepository;

        public RequestsLogic(IRequestRepository requestRepository)
        {
            this.requestRepository = requestRepository;
        }

        public async Task<List<Requests>> GetRequests(Employee employee, Service service = null, bool descending = false)
        {
            List<Requests> result = new List<Requests>();
            // Получение всех заявок
            var requests = await requestRepository.GetRequests();
            // Если вид заявки указан — получаем заявки данного вида
            if (service != null) requests = requests.Where(r => r.ServiceId == service.Id).ToList();
            // получаем заявки созданные сотрудником
            result = requests.Where(r => r.ClientId == employee.Id).ToList();
            // Список групп исполнителей, в которые включен текущий пользователь
            var executorGroups = employee.ExecutorGroups;
            // Если пользователь входит в группу(-ы) исполнителей
            if (executorGroups != null)
            {
                foreach (var group in executorGroups)
                {
                    // получаем список заявок, к которым отсносится пользователь
                    var temp = requests.Where(r => r.ExecutorGroupId == group.ExecutorGroupId).ToList();
                    // добавляем в итоговый лист
                    if (temp.Count != 0) result = result.Union(temp).ToList();
                }
            }
            // возвращаем список заявок, где пользователь является создателем, исполнителем или входит в группу исполнителей закрепленных за видом заявки
            if (descending) return result.OrderByDescending(r => r.Date).ToList();
            else return result.OrderBy(r => r.Date).ToList();
        }

        public async Task<List<Requests>> GetRequests(bool descending = false)
        {
            // Получение всех заявок
            var requests = await requestRepository.GetRequests();
            // выводим согласно выбраному типу сортировки
            if (descending) return requests.OrderByDescending(r => r.Date).ToList();
            else return requests.OrderBy(r => r.Date).ToList();
        }

        public async Task<List<Requests>> GetRequests(Employee employee, bool descending = false)
        {
            List<Requests> result = new List<Requests>();
            // Получение всех заявок
            var requests = await requestRepository.GetRequests();

            // получаем заявки созданные сотрудником
            result = requests.Where(r => r.ClientId == employee.Id).ToList();

            // Список групп исполнителей, в которые включен текущий пользователь
            var executorGroups = employee.ExecutorGroups;
            // Если пользователь входит в группу(-ы) исполнителей
            if (executorGroups.Count != 0)
            {
                foreach (var group in executorGroups)
                {
                    // получаем список заявок, к которым отсносится пользователь
                    var temp = requests.Where(r => r.ExecutorGroupId == group.ExecutorGroupId).ToList();
                    // добавляем в итоговый лист
                    if (temp.Count != 0) result = result.Union(temp).ToList();
                }
            }
            // выводим согласно выбраному типу сортировки
            if (descending)
            {
                return result.OrderByDescending(r => r.Date).ToList();
            }
            else
            {
                return result.OrderBy(r => r.Date).ToList();
            }
        }

        public async Task<List<Requests>> GetRequests(Employee employee, Status status, bool descending = false)
        {
            List<Requests> result = new List<Requests>();
            var requests = await requestRepository.GetRequests();
            // Если статус заявки указан — получаем заявки данного статуса
            if (status != null) requests = requests.Where(r => r.StatusId == status.Id).ToList();
            // получаем заявки созданные сотрудником
            result = requests.Where(r => r.ClientId == employee.Id).ToList();
            // Список групп исполнителей, в которые включен текущий пользователь
            var executorGroups = employee.ExecutorGroups;
            // Если пользователь входит в группу(-ы) исполнителей
            if (executorGroups != null)
            {
                foreach (var group in executorGroups)
                {
                    // получаем список заявок, к которым отсносится пользователь
                    var temp = requests.Where(r => r.ExecutorGroupId == group.ExecutorGroupId).ToList();
                    // добавляем в итоговый лист
                    if (temp.Count != 0) result = result.Union(temp).ToList();
                }
            }
            // возвращаем список заявок, где пользователь является создателем, исполнителем или входит в группу исполнителей закрепленных за видом заявки
            if (descending) return result.OrderByDescending(r => r.Date).ToList();
            else return result.OrderBy(r => r.Date).ToList();
        }

        public async Task<List<Requests>> GetRequests(Employee employee, Status status, bool client = true, bool descending = false)
        {
            List<Requests> result = new List<Requests>();
            var requests = await requestRepository.GetRequests();
            // Если статус заявки указан — получаем заявки данного статуса
            if (status != null) requests = requests.Where(r => r.StatusId == status.Id).ToList();
            // получаем заявки созданные сотрудником
            result = requests.Where(r => r.ClientId == employee.Id).ToList();
            // Список групп исполнителей, в которые включен текущий пользователь
            var executorGroups = employee.ExecutorGroups;
            // Если пользователь входит в группу(-ы) исполнителей
            if (executorGroups != null)
            {
                foreach (var group in executorGroups)
                {
                    // получаем список заявок, к которым отсносится пользователь
                    var temp = requests.Where(r => r.ExecutorGroupId == group.ExecutorGroupId).ToList();
                    // добавляем в итоговый лист
                    if (temp.Count != 0) result = result.Concat(temp).ToList();
                }
            }
            if (client)
            {
                // возвращаем список заявок, где пользователь является создателем, исполнителем или входит в группу исполнителей закрепленных за видом заявки
                return result.Where(r => r.ClientId == employee.Id).OrderBy(r => r.Date).ToList();
            }
            else
            {
                return result.Where(r => r.ExecutorId == employee.Id || r.ExecutorId == null).OrderBy(r => r.Date).ToList();
            }
        }

        public async Task<List<Requests>> GetRequests(Employee employee, Category category, Service service, Status status, bool descending = false)
        {
            List<Requests> result = new List<Requests>();
            // Получение всех заявок
            var requests = await requestRepository.GetRequests();
            if (category != null) requests = requests.Where(r => r.Service.Category.Id == category.Id).ToList();
            // Если вид заявки указан — получаем заявки данного вида
            if (service != null) requests = requests.Where(r => r.ServiceId == service.Id).ToList();
            // Если статус заявки указан — получаем заявки с указанным статусом
            if (status != null) requests = requests.Where(r => r.StatusId == status.Id).ToList();
            // получаем заявки созданные сотрудником
            result = requests.Where(r => r.ClientId == employee.Id).ToList();
            // Список групп исполнителей, в которые включен текущий пользователь
            var executorGroups = employee.ExecutorGroups;
            // Если пользователь входит в группу(-ы) исполнителей
            if (executorGroups != null)
            {
                foreach (var group in executorGroups)
                {
                    // получаем список заявок, к которым отсносится пользователь
                    var temp = requests.Where(r => r.ExecutorGroupId == group.ExecutorGroupId).ToList();
                    // добавляем в итоговый лист
                    if (temp.Count != 0) result = result.Union(temp).ToList();
                }
            }
            // возвращаем список заявок, где пользователь является создателем, исполнителем или входит в группу исполнителей закрепленных за видом заявки
            if (descending) return result.OrderByDescending(r => r.Date).ToList();
            else return result.OrderBy(r => r.Date).ToList();
        }

        public async Task<List<Requests>> GetRequests(Employee employee, bool client = false, bool descending = true)
        {
            List<Requests> result = new List<Requests>();
            // Получение всех заявок
            var requests = await requestRepository.GetRequests();

            // получаем заявки созданные сотрудником
            result = requests.Where(r => r.ClientId == employee.Id).ToList();

            if (!client)
            {
                var approvalServices = employee.ApprovalServices;
                if (approvalServices.Count != 0)
                {
                    foreach(var service in approvalServices)
                    {
                        var temp = requests.Where(r => r.ServiceId == service.ServiceId).ToList();
                        if(temp.Count!=0) result = result.Union(temp).ToList();
                    }
                }

                // Список групп исполнителей, в которые включен текущий пользователь
                var executorGroups = employee.ExecutorGroups;
                // Если пользователь входит в группу(-ы) исполнителей
                if (executorGroups.Count != 0)
                {
                    foreach (var group in executorGroups)
                    {
                        // получаем список заявок, к которым отсносится пользователь
                        var temp = requests.Where(r => r.ExecutorGroupId == group.ExecutorGroupId).ToList();
                        // добавляем в итоговый лист
                        if (temp.Count != 0) result = result.Union(temp).ToList();
                    }
                }
            }
            // выводим согласно выбраному типу сортировки
            if (descending)
            {
                return result.OrderByDescending(r => r.Date).ToList();
            }
            else
            {
                return result.OrderBy(r => r.Date).ToList();
            }
        }

        public async Task<List<Requests>> GetRequests(Employee employee, Category category, Service service, Status status, bool client = false, bool descending = true)
        {
            List<Requests> result = new List<Requests>();
            // Получение всех заявок
            var requests = await requestRepository.GetRequests();
            if (category != null) requests = requests.Where(r => r.Service.Category.Id == category.Id).ToList();
            // Если вид заявки указан — получаем заявки данного вида
            if (service != null) requests = requests.Where(r => r.ServiceId == service.Id).ToList();
            // Если статус заявки указан — получаем заявки с указанным статусом
            if (status != null) requests = requests.Where(r => r.StatusId == status.Id).ToList();
            // получаем заявки созданные сотрудником
            result = requests.Where(r => r.ClientId == employee.Id).ToList();

            if (!client)
            {
                var approvalServices = employee.ApprovalServices;
                if (approvalServices.Count != 0)
                {
                    foreach (var appService in approvalServices)
                    {
                        var temp = requests.Where(r => r.ServiceId == appService.ServiceId).ToList();
                        if (temp.Count != 0) result = result.Union(temp).ToList();
                    }
                }

                // Список групп исполнителей, в которые включен текущий пользователь
                var executorGroups = employee.ExecutorGroups;
                // Если пользователь входит в группу(-ы) исполнителей
                if (executorGroups != null)
                {
                    foreach (var group in executorGroups)
                    {
                        // получаем список заявок, к которым отсносится пользователь
                        var temp = requests.Where(r => r.ExecutorGroupId == group.ExecutorGroupId).ToList();
                        // добавляем в итоговый лист
                        if (temp.Count != 0) result = result.Union(temp).ToList();
                    }
                }
            }

            // возвращаем список заявок, где пользователь является создателем, исполнителем или входит в группу исполнителей закрепленных за видом заявки
            if (descending) return result.OrderByDescending(r => r.Date).ToList();
            else return result.OrderBy(r => r.Date).ToList();
        }
    }
}
