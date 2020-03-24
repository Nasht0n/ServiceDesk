using Domain.Abstract;
using Domain.Models.ManyToMany;
using System.Collections.Generic;

namespace Domain.Models.Requests.Accounts
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Заявка на аннулирование учетной записи"
    /// </summary>
    public class AccountCancellationRequest:Request
    {
        /// <summary>
        /// Список прикрепленных файлов
        /// </summary>
        public virtual IList<AccountCancellationRequestAttachment> Attachments { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public AccountCancellationRequest()
        {
            Attachments = new List<AccountCancellationRequestAttachment>();
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
        /// <param name="clientId">Идентификатор клиента</param>
        /// <param name="executorGroupId">Идентификатор группы исполнителей</param>
        public AccountCancellationRequest(string title, string justification, string description, int serviceId, int statusId, int priorityId, int clientId, int executorGroupId)
        {
            Title = title;
            Justification = justification;
            Description = description;
            ServiceId = serviceId;
            StatusId = statusId;
            PriorityId = priorityId;
            ClientId = clientId;
            ExecutorGroupId = executorGroupId;
            Attachments = new List<AccountCancellationRequestAttachment>();
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта заявки на аннулирование учетной записи.</returns>
        public override string ToString()
        {
            return $"AccountCancellationRequest object:(Id:[{Id}];Title:[{Title}];Justification:[{Justification}];Description:[{Description}];ServiceId:[{ServiceId}];" +
                $"StatusId:[{StatusId}];PriorityId:[{PriorityId}];ClientId:[{ClientId}];ExecutorGroupId:[{ExecutorGroupId}]).";
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            if(obj is AccountCancellationRequest && obj != null)
            {
                AccountCancellationRequest temp = (AccountCancellationRequest)obj;
                if (temp.Id == Id && temp.Title == Title && temp.Justification == Justification && temp.Description == Description && temp.ServiceId == ServiceId &&
                    temp.StatusId == StatusId && temp.PriorityId == PriorityId  && temp.ClientId == ClientId && temp.ExecutorGroupId == ExecutorGroupId) return true;
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
