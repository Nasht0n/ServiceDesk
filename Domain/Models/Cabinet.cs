using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Кабинет"
    /// </summary>
    public class Cabinet
    {
        /// <summary>
        /// Идентификатор кабинета
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Наименование кабинета
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        /// <summary>
        /// Список сотрудников входящих в состав кабинета
        /// </summary>
        public IList<Employee> Employees { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Cabinet() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Наименование кабинета</param>
        public Cabinet(string name)
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
            return obj is Cabinet cabinet &&
                   Id == cabinet.Id &&
                   Name == cabinet.Name;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта кабинета.</returns>
        public override string ToString()
        {
            return $"Cabinet object:(Id:[{Id}];Name:[{Name}]).";
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
