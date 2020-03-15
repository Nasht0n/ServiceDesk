using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Отрасль поддержки"
    /// </summary>
    public class Branch
    {
        /// <summary>
        /// Идентификатор отрасли поддержки
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Наименование отрасли поддержки
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Fullname { get; set; }
        [Required]
        [DefaultValue("Area")]
        [MaxLength(150)]
        public string AreaName { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Branch() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Наименование категории заявки</param>
        public Branch(string name)
        {
            // инициализация переменных
            Fullname = name;
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Branch branch &&
                   Id == branch.Id &&
                   Fullname == branch.Fullname &&
                   AreaName == branch.AreaName;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта отрасли заявки.</returns>
        public override string ToString()
        {
            return $"Branch object:(Id:[{Id}];Name:[{Fullname}];AreaName:[{AreaName}]).";
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
