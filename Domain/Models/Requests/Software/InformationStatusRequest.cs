using Domain.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests.Software
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Заявка о состоянии информации, размещенной на сайте университета"
    /// </summary>
    public class InformationStatusRequest:Request
    {
        /// <summary>
        /// URL адрес сайта
        /// </summary>
        [Required]        
        public string URL { get; set; }
        /// <summary>
        /// Список заголовков страниц, на которых размещена актуальная информация
        /// </summary>
        public virtual IList<InformationStatusRequestTitle> Titles { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public InformationStatusRequest()
        {
            Titles = new List<InformationStatusRequestTitle>();
        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="title">Тема заявки</param>
        /// <param name="justification">Обоснование заявки</param>
        /// <param name="description">Основание заявки</param>
        /// <param name="serviceId">Идентификатор вида работы</param>
        /// <param name="statusId">Идентификатор статуса заявки</param>
        /// <param name="priorityId">Идентификатор приоритета заявки</param>
        /// <param name="cabinetId">Идентификатор кабинета сотрудника</param>
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="url">URL адрес сайта</param>
        /// <param name="executorGroupId">Идентификатор группы исполнителей</param>
        public InformationStatusRequest(string title, string justification, string description, int serviceId, int statusId, int priorityId, int clientId, int executorGroupId, string url)
        {
            Title = title;
            Justification = justification;
            Description = description;
            ServiceId = serviceId;
            StatusId = statusId;
            PriorityId = priorityId;
            ClientId = clientId;
            ExecutorGroupId = executorGroupId;
            URL = url;
            Titles = new List<InformationStatusRequestTitle>();
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта жизненного цикла заявки на разработку программного обеспечения.</returns>
        public override string ToString()
        {
            return $"InformationStatusRequest object:(Id:[{Id}];Title:[{Title}];Justification:[{Justification}];Description:[{Description}];ServiceId:[{ServiceId}];" +
                $"StatusId:[{StatusId}];PriorityId:[{PriorityId}];ClientId:[{ClientId}];ExecutorGroupId:[{ExecutorGroupId}]);URL:[{URL}].";
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is InformationStatusRequest && obj != null)
            {
                InformationStatusRequest temp = (InformationStatusRequest)obj;
                if (temp.Id == Id && temp.Title == Title && temp.Justification == Justification && temp.Description == Description && temp.ServiceId == ServiceId &&
                    temp.StatusId == StatusId && temp.PriorityId == PriorityId && temp.ClientId == ClientId && temp.ExecutorGroupId == ExecutorGroupId && temp.URL == URL) return true;
                else return false;
            }
            return false;
        }
        /// <summary>
        /// Метод переопределния стандартного метода получения хэш-кода объекта
        /// </summary>
        /// <returns>Возвращает хэш-код объекта</returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
