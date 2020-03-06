using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Оборудование"
    /// </summary>
    public class Equipment
    {
        /// <summary>
        /// Идентификатор оборудования
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Наименование оборудования
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        /// <summary>
        /// Инвентарный номер оборудования
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string InventoryNumber { get; set; }
        /// <summary>
        /// Идентификатор типа оборудования
        /// </summary>
        [Required]
        public int EquipmentTypeId { get; set; }
        /// <summary>
        /// Объект типа оборудования
        /// </summary>
        public EquipmentType EquipmentType { get; set; }
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Equipment() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name">Наименование оборудования</param>
        /// <param name="inventoryNumber">Инвентарный номер оборудования</param>
        /// <param name="equipmentTypeId">Идентификатор типа оборудования</param>
        public Equipment(string name, string inventoryNumber, int equipmentTypeId)
        {
            // инициализация переменных
            Name = name;
            InventoryNumber = inventoryNumber;
            EquipmentTypeId = equipmentTypeId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Equipment equipment &&
                   Id == equipment.Id &&
                   Name == equipment.Name &&
                   InventoryNumber == equipment.InventoryNumber &&
                   EquipmentTypeId == equipment.EquipmentTypeId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление объекта оборудования.</returns>
        public override string ToString()
        {
            return $"Equipment object: (Id:[{Id}];Name:[{Name}];InventoryNumber:[{InventoryNumber}];EquipmentTypeId:[{EquipmentTypeId}]).";
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
