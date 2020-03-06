using Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests.Email
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Заявка на регистрацию почтового ящика"
    /// </summary>
    public class EmailRegistrationRequest:Request
    {
        /// <summary>
        /// Желаемый адрес электронной почты
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public EmailRegistrationRequest()
        {

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
        /// <param name="executorGroupId">Идентификатор группы исполнителей</param>
        /// <param name="email">Желаемый адрес электронной почты</param>
        public EmailRegistrationRequest(string title, string justification, string description, int serviceId, int statusId, int priorityId, int cabinetId, int clientId, int executorGroupId, string email)
        {
            Title = title;
            Justification = justification;
            Description = description;
            ServiceId = serviceId;
            StatusId = statusId;
            PriorityId = priorityId;
            CabinetId = cabinetId;
            ClientId = clientId;
            ExecutorGroupId = executorGroupId;
            Email = email;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта заявки на регистрацию почтового ящика.</returns>
        public override string ToString()
        {
            return $"EmailRegistrationRequest object:(Id:[{Id}];Title:[{Title}];Justification:[{Justification}];Description:[{Description}];ServiceId:[{ServiceId}];" +
                $"StatusId:[{StatusId}];PriorityId:[{PriorityId}];CabinetId:[{CabinetId}];ClientId:[{ClientId}];ExecutorGroupId:[{ExecutorGroupId}]);Email:[{Email}].";
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is EmailRegistrationRequest && obj != null)
            {
                EmailRegistrationRequest temp = (EmailRegistrationRequest)obj;
                if (temp.Id == Id && temp.Title == Title && temp.Justification == Justification && temp.Description == Description && temp.ServiceId == ServiceId &&
                    temp.StatusId == StatusId && temp.PriorityId == PriorityId && temp.CabinetId == CabinetId && temp.ClientId == ClientId && 
                    temp.ExecutorGroupId == ExecutorGroupId && temp.Email == Email) return true;
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
