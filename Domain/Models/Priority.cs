using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Приоритет заявки"
    /// </summary>
    public class Priority
    {
        /// <summary>
        /// Идентификатор приоритета заявки
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Полное наименование приоритета заявки
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Fullname { get; set; }
        /// <summary>
        /// Сокращенное наименование приоритета заявки
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Shortname { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Priority() { }
        /// <summary>
        /// Конструктор с параметрами, для инициализации объекта приоритета заявки
        /// </summary>
        /// <param name="fullname">Полное наименование приоритета заявки</param>
        /// <param name="shortname">Сокращенное наименование приоритета заявки</param>
        public Priority(string fullname, string shortname)
        {
            // инициализация переменных
            Fullname = fullname;
            Shortname = shortname;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта приоритета заявки.</returns>
        public override string ToString()
        {
            return $"Priority object:(Id:[{Id}];Fullname:[{Fullname}];Shortname:[{Shortname}]).";
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Priority && obj != null)
            {
                Priority temp = (Priority)obj;
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
