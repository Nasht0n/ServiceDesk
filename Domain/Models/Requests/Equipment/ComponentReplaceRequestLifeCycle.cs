using Domain.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests.Equipment
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Жизненный цикл заявки на замену комплектующего оборудования"
    /// </summary>
    public class ComponentReplaceRequestLifeCycle:LifeCycle
    {
        /// <summary>
        /// Идентификатор заявки на замену комплектующего оборудования
        /// </summary>
        [Required]
        public int RequestId { get; set; }
        /// <summary>
        /// Объект заявки на замену комплектующего оборудования
        /// </summary>
        public ComponentReplaceRequest Request { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ComponentReplaceRequestLifeCycle() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="date">Дата и время события в жизненном цикле заявки</param>
        /// <param name="message">Сообщение жизненного цикла</param>
        /// <param name="requestId">Идентификатор заявки</param>
        /// <param name="employeeId">Идентификатор пользователя, создавшего запись жизненного цикла</param>
        public ComponentReplaceRequestLifeCycle(DateTime date, string message, int requestId, int employeeId)
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
        /// <returns>Возвращает строковое представление объекта жизненного цикла заявки на замену комплектующего оборудования.</returns>
        public override string ToString()
        {
            return $"ComponentReplaceRequestLifeCycle object:(Id:[{Id}];Date:[{Date}];Message:[{Message}];RequestId:[{RequestId}];EmployeeId:[{EmployeeId}]).";
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is ComponentReplaceRequestLifeCycle && obj != null)
            {
                ComponentReplaceRequestLifeCycle temp = (ComponentReplaceRequestLifeCycle)obj;
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
