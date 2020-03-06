using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests.Network
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Подключаемое оборудование"
    /// </summary>
    public class ConnectionEquipments
    {
        /// <summary>
        /// Идентификатор подключаемого оборудования
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Количество единиц
        /// </summary>
        [Required]
        public int Count { get; set; }
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
        /// Конструктор по умолчанию
        /// </summary>
        public ConnectionEquipments() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="count">Количество единиц</param>
        /// <param name="equipmentTypeId">Идентификатор типа оборудования</param>
        public ConnectionEquipments(int count, int equipmentTypeId)
        {
            Count = count;
            EquipmentTypeId = equipmentTypeId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is ConnectionEquipments equipments &&
                   Id == equipments.Id &&
                   Count == equipments.Count &&
                   EquipmentTypeId == equipments.EquipmentTypeId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление записи подключаемого оборудования.</returns>
        public override string ToString()
        {
            return $"ConnectionEquipment object:(Id:[{Id}];Count:[{Count}];EquipmentTypeId:[{EquipmentTypeId}]);";
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
