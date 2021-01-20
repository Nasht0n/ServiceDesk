using Domain.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Requests.Software
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Жизненный цикл заявки о состоянии информации, размещенной на сайте университета"
    /// </summary>
    public class InformationStatusRequestLifeCycle:LifeCycle
    {
        /// <summary>
        /// Идентификатор заявки о состоянии информации, размещенной на сайте университета
        /// </summary>
        [Required]
        public int RequestId { get; set; }
        /// <summary>
        /// Объект заявки о состоянии информации, размещенной на сайте университета
        /// </summary>
        [ForeignKey("RequestId")]
        public InformationStatusRequest Request { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public InformationStatusRequestLifeCycle() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="date">Дата и время события в жизненном цикле заявки</param>
        /// <param name="message">Сообщение жизненного цикла</param>
        /// <param name="requestId">Идентификатор заявки</param>
        /// <param name="employeeId">Идентификатор пользователя, создавшего запись жизненного цикла</param>
        public InformationStatusRequestLifeCycle(DateTime date, string message, int requestId, int employeeId)
        {
            Date = date;
            RequestId = requestId;
            Message = message;
            EmployeeId = employeeId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта жизненного цикла заявки на разработку программного обеспечения.</returns>
        public override string ToString()
        {
            return $"InformationStatusRequestLifeCycle object:(Id:[{Id}];Date:[{Date}];Message:[{Message}];RequestId:[{RequestId}];EmployeeId:[{EmployeeId}]).";
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is InformationStatusRequestLifeCycle && obj != null)
            {
                InformationStatusRequestLifeCycle temp = (InformationStatusRequestLifeCycle)obj;
                if (temp.Id == Id && temp.Date == Date && temp.Message == Message && temp.RequestId == RequestId && temp.EmployeeId == EmployeeId) return true;
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
