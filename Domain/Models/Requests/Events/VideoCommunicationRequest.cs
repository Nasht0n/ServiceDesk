using Domain.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests.Events
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Заявка на проведение видеосвязи"
    /// </summary>
    public class VideoCommunicationRequest:Request
    {
        /// <summary>
        /// Расположение
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Location { get; set; }
        /// <summary>
        /// Дата проведения мероприятия
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
        /// <summary>
        /// Время проведения мероприятия
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Time { get; set; }
        /// <summary>
        /// Идентификатор учебного корпуса
        /// </summary>
        [Required]
        public int CampusId { get; set; }
        /// <summary>
        /// Объект учебного корпуса
        /// </summary>
        public Campus Campus { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public VideoCommunicationRequest() { }
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
        /// <param name="executorGroupId">Идентификатор группы исполнителей</param>
        /// <param name="date">Дата проведения мероприятия</param>
        /// <param name="location">Расположение</param>
        /// <param name="campusId">Идентификатор учебного корпуса</param>
        public VideoCommunicationRequest(string title, string justification, string description, int serviceId, int statusId, int priorityId, 
            int clientId, int executorGroupId, string location, DateTime date, int campusId)
        {
            Title = title;
            Justification = justification;
            Description = description;
            ServiceId = serviceId;
            StatusId = statusId;
            PriorityId = priorityId;
            ClientId = clientId;
            ExecutorGroupId = executorGroupId;
            Location = location;
            Date = date;
            CampusId = campusId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта заявки на выделение телефонного номера.</returns>
        public override string ToString()
        {
            return $"VideoCommunicationRequest object:(Id:[{Id}];Title:[{Title}];Justification:[{Justification}];Description:[{Description}];ServiceId:[{ServiceId}];" +
                $"StatusId:[{StatusId}];PriorityId:[{PriorityId}];ClientId:[{ClientId}];ExecutorGroupId:[{ExecutorGroupId}]);Location:[{Location}];" +
                $"Date:[{Date.ToString()}];CampusId:[{CampusId}].";
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is VideoCommunicationRequest && obj != null)
            {
                VideoCommunicationRequest temp = (VideoCommunicationRequest)obj;
                if (temp.Id == Id && temp.Title == Title && temp.Justification == Justification && temp.Description == Description && temp.ServiceId == ServiceId &&
                    temp.StatusId == StatusId && temp.PriorityId == PriorityId && temp.ClientId == ClientId &&
                    temp.ExecutorGroupId == ExecutorGroupId && temp.Location == Location && temp.Date == Date && temp.CampusId == CampusId) return true;
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
