using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Статус заявки"
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Идентификатор статуса заявки
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Полное наименование статуса заявки
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Fullname { get; set; }
        /// <summary>
        /// Сокращенное наименование статуса заявки
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Shortname { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Status() {  }
        /// <summary>
        /// Конструктор с параметрами, для инициализации объекта статуса заявки
        /// </summary>
        /// <param name="fullname">Полное наименование статуса заявки</param>
        /// <param name="shortname">Сокращенное наименование статуса заявки</param>
        public Status(string fullname, string shortname)
        {
            // инициализация переменных
            Fullname = fullname;
            Shortname = shortname;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта статуса заявки.</returns>
        public override string ToString()
        {
            return $"Status object:(Id:[{Id}];Fullname:[{Fullname}];Shortname:[{Shortname}]).";
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            if(obj is Status && obj != null)
            {
                Status temp = (Status)obj;
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
