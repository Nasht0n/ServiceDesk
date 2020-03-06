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
        /// Количество затраченных единиц
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Идентификатор заявки на ремонт оборудования
        /// </summary>
        public int RequestId { get; set; }
        /// <summary>
        /// Объект заявки на ремонт оборудования
        /// </summary>
        public EquipmentRepairRequest Request { get; set; }
        /// <summary>
        /// Идентификатор расходного материала
        /// </summary>
        public int ConsumableId { get; set; }
        /// <summary>
        /// Объект расходного материала
        /// </summary>
        public Consumable Consumable { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public RepairEquipments()
        {

        }
        /// <summary>
        /// Контструктор с параметрами
        /// </summary>
        /// <param name="count">Количество затраченных единиц</param>
        /// <param name="requestId">Идентификатор заявки на ремонт оборудования</param>
        /// <param name="consumableId">Идентификатор расходного материала</param>
        public RepairEquipments(int count, int requestId, int consumableId)
        {
            Count = count;
            RequestId = requestId;
            ConsumableId = consumableId;
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
                   Count == equipments.Count &&
                   RequestId == equipments.RequestId &&
                   ConsumableId == equipments.ConsumableId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление записи ремонтируемой техники.</returns>
        public override string ToString()
        {
            return $"RepairEquipment object:(Id:[{Id}];Count:[{Count}];RequestId:[{RequestId}];ConsumableId:[{ConsumableId}]).";
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
