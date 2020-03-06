using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Организация"
    /// </summary>
    public class ExecutorGroup
    {
        /// <summary>
        /// Идентификатор группы исполнителей
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Наименование группы исполнителей
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public IList<Employee> Employees { get; set; }
        public IList<Service> Services { get; set; }
        public ExecutorGroup() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Наименование группы исполнителей</param>
        public ExecutorGroup(string name)
        {
            //инициализация переменных
            Name = name;
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is ExecutorGroup group &&
                   Id == group.Id &&
                   Name == group.Name;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта группы исполнителей.</returns>
        public override string ToString()
        {
            return $"Executor Group object:(Id:[{Id}];Name:[{Name}]).";
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
