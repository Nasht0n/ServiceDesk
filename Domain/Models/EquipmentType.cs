using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Тип оборудования"
    /// </summary>
    public class EquipmentType
    {
        /// <summary>
        /// Идентификатор типа оборудования
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Наименование типа оборудования
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        /// <summary>
        /// Список устанавливаемого оборудования
        /// </summary>
        public virtual List<InstallationEquipments> InstallationEquipments { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public EquipmentType()
        {
            InstallationEquipments = new List<InstallationEquipments>();
        }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Наименование типа оборудования</param>
        public EquipmentType(string name)
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
            return obj is EquipmentType type &&
                   Id == type.Id &&
                   Name == type.Name;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта типа оборудования.</returns>
        public override string ToString()
        {
            return $"EquipmentType object:(Id:[{Id}];Name:[{Name}]).";
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
