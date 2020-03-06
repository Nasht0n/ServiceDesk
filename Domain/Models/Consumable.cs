using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Расходный материал"
    /// </summary>
    public class Consumable
    {
        /// <summary>
        /// Идентификатор расходного материала
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Наименование расходного материала
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Consumable()
        {

        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Наименование расходного материала</param>
        public Consumable(string name)
        {
            // инициализация переменных
            Name = name;
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Consumable consumable &&
                   Id == consumable.Id &&
                   Name == consumable.Name;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта оборудования.</returns>
        public override string ToString()
        {
            return $"Consumable object:(Id:[{Id}];Name:[{Name}]).";
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
