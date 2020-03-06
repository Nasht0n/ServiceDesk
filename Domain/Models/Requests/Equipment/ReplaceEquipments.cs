namespace Domain.Models.Requests.Equipment
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Оборудование под замену"
    /// </summary>
    public class ReplaceEquipments
    {
        /// <summary>
        /// Идентификатор оборудования под замену
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Инвентарный номер оборудования
        /// </summary>
        public string InventoryNumber { get; set; }
        /// <summary>
        /// Идентификатор заявки на замену оборудования
        /// </summary>
        public int RequestId { get; set; }
        /// <summary>
        /// Объект заявки на замену оборудования
        /// </summary>
        public EquipmentReplaceRequest Request { get; set; }
        /// <summary>
        /// Идентификатор типа оборудования
        /// </summary>
        public int EquipmentTypeId { get; set; }
        /// <summary>
        /// Объект типа оборудования
        /// </summary>
        public EquipmentType EquipmentType { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ReplaceEquipments() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="inventoryNumber">Инвентарный номер</param>
        /// <param name="requestId">Идентификатор заявки на замену оборудования</param>
        /// <param name="equipmentTypeId">Идентификатор типа оборудования</param>
        public ReplaceEquipments(string inventoryNumber, int requestId, int equipmentTypeId)
        {
            // инициализация переменных
            InventoryNumber = inventoryNumber;
            RequestId = requestId;
            EquipmentTypeId = equipmentTypeId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is ReplaceEquipments equipments &&
                   Id == equipments.Id &&
                   InventoryNumber == equipments.InventoryNumber &&
                   RequestId == equipments.RequestId &&
                   EquipmentTypeId == equipments.EquipmentTypeId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление записи заменяемого оборудования.</returns>
        public override string ToString()
        {
            return $"ReplaceEquipment object:(Id:[{Id}];InventoryNumber:[{InventoryNumber}]; RequestId:[{RequestId}]; EquipmentTypeId:[{EquipmentTypeId}]).";
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
