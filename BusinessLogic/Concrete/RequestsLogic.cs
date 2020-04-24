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

        public async Task<List<Requests>> GetRequests(Employee employee, Service service = null, bool descending = true)
        {
            List<Requests> result = new List<Requests>();
            // Получение всех заявок
            var requests = await requestRepository.GetRequests();
            // Если вид заявки указан — получаем заявки данного вида
            if (service != null) requests = requests.Where(r => r.ServiceId == service.Id).ToList();
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
            // возвращаем список заявок, где пользователь является создателем, исполнителем или входит в группу исполнителей закрепленных за видом заявки
            return result.Where(r => r.ClientId == employee.Id || r.ExecutorId == employee.Id || r.ExecutorId == null).OrderBy(r => r.Date).ToList();
        }

        public async Task<List<Requests>> GetRequests(bool descending = true)
        {
            // Получение всех заявок
            var requests = await requestRepository.GetRequests();
            // выводим согласно выбраному типу сортировки
            if (descending) return requests.OrderByDescending(r => r.Date).ToList();
            else return requests.OrderBy(r => r.Date).ToList();
        }

        public async Task<List<Requests>> GetRequests(Employee employee, bool descending = true)
        {
            List<Requests> result = new List<Requests>();
            // Получение всех заявок
            var requests = await requestRepository.GetRequests();
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
            // выводим согласно выбраному типу сортировки
            if (descending)
            {
                return result.Where(r => r.ClientId == employee.Id || r.ExecutorId == employee.Id || r.ExecutorId == null).OrderByDescending(r => r.Date).ToList();
            }
            else
            {
                return result.Where(r => r.ClientId == employee.Id || r.ExecutorId == employee.Id || r.ExecutorId == null).OrderBy(r => r.Date).ToList();
            }
        }

        public async Task<List<Requests>> GetRequests(Employee employee, Status status, bool descending = true)
        {
            List<Requests> result = new List<Requests>();
            var requests = await requestRepository.GetRequests();
            // Если статус заявки указан — получаем заявки данного статуса
            if (status != null) requests = requests.Where(r => r.StatusId == status.Id).ToList();

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
            // возвращаем список заявок, где пользователь является создателем, исполнителем или входит в группу исполнителей закрепленных за видом заявки
            return result.Where(r => r.ClientId == employee.Id || r.ExecutorId == employee.Id || r.ExecutorId == null).OrderBy(r => r.Date).ToList();
        }

        public async Task<List<Requests>> GetRequests(Employee employee, Status status, bool client = true, bool descending = true)
        {
            List<Requests> result = new List<Requests>();
            var requests = await requestRepository.GetRequests();
            // Если статус заявки указан — получаем заявки данного статуса
            if (status != null) requests = requests.Where(r => r.StatusId == status.Id).ToList();

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
    }
}
