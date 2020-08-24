namespace Domain.Models.Requests.Equipment
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Ремонтируемая техника"
    /// </summary>
    public class RepairEquipments
    {
        /// <summary>
        /// Идентификатор записи ремонтируемого оборудования
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Инвентарный номер техники
        /// </summary>
        public string InventoryNumber { get; set; }
        /// <summary>
        /// Идентификатор заявки на ремонт оборудования
        /// </summary>
        public int RequestId { get; set; }
        /// <summary>
        /// Объект заявки на ремонт оборудования
        /// </summary>
        public EquipmentRepairRequest Request { get; set; }        
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public RepairEquipments()
        {

        }
        /// <summary>
        /// Контструктор с параметрами
        /// </summary>
        /// <param name="inventoryNumber">Инвентарный номер техники</param>
        /// <param name="requestId">Идентификатор заявки на заправку техники</param>
        public RepairEquipments(string inventoryNumber, int requestId)
        {
            // инициализация переменных
            InventoryNumber = inventoryNumber;
            RequestId = requestId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is RepairEquipments equipments &&
                   Id == equipments.Id &&
                   InventoryNumber == equipments.InventoryNumber &&
                   RequestId == equipments.RequestId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление записи ремонтируемой техники.</returns>
        public override string ToString()
        {
            return $"RepairEquipment object:(Id:[{Id}];InventoryNumber:[{InventoryNumber}];RequestId:[{RequestId}]).";
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
