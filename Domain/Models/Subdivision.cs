using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Подразделения"
    /// </summary>
    public class Subdivision
    {
        /// <summary>
        /// Идентификатор подразделения
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Полное наименование подразделения
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Fullname { get; set; }
        /// <summary>
        /// Сокращенное наименование подразделения
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Shortname { get; set; }
        /// <summary>
        /// Список пользователей, закрепленных за подразделением в качестве исполнителя
        /// </summary>
        public IList<Employee> SubdivisionExecutors { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Subdivision() { }
        /// <summary>
        /// Конструктор с параметрами, для инициализации объекта подразделения
        /// </summary>
        /// <param name="fullname">Полное наименование подразделения</param>
        /// <param name="shortname">Сокращенное наименование подразделения</param>
        public Subdivision(string fullname, string shortname)
        {
            // инициализация переменных
            Fullname = fullname;
            Shortname = shortname;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта подразделения.</returns>
        public override string ToString()
        {
            return $"Subdivision object:(Id:[{Id}];Fullname:[{Fullname}];Shortname:[{Shortname}]).";
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            if(obj is Subdivision && obj != null)
            {
                Subdivision temp = (Subdivision)obj;
                if (temp.Id == Id && temp.Fullname == Fullname && temp.Shortname == Shortname) return true;
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
