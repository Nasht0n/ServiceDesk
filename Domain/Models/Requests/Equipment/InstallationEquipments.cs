namespace Domain.Models.Requests.Equipment
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Устанавливаемое оборудование"
    /// </summary>
    public class InstallationEquipments
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Количество единиц оборудования
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Идентификатор заявки на установку оборудования
        /// </summary>
        public int RequestId { get; set; }
        /// <summary>
        /// Объект заявки на установку оборудования
        /// </summary>
        public EquipmentInstallationRequest Request { get; set; }
        /// <summary>
        /// Идентификатор типа оборудования
        /// </summary>
        public int EquipmentTypeId { get; set; }
        /// <summary>
        /// Объект типа оборудования
        /// </summary>
        public EquipmentType EquipmentType { get; set; }
        /// <summary>
        /// Конструктор по умполчанию
        /// </summary>
        public InstallationEquipments() { }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="count">Количество единиц оборудования</param>
        /// <param name="requestId">Идентификатор заявки на установку оборудования</param>
        /// <param name="equipmentTypeId">Идентификатор типа оборудования</param>
        public InstallationEquipments(int count, int requestId, int equipmentTypeId)
        {
            // инициализация переменных
            Count = count;
            RequestId = requestId;
            EquipmentTypeId = equipmentTypeId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление записи устанавливаемого оборудования.</returns>
        public override string ToString()
        {
            return $"InstallationEquipments object:(Id:[{Id}];Count:[{Count}];RequestId:[{RequestId}];EquipmentTypeId:[{EquipmentTypeId}]).";
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is InstallationEquipments equipments &&
                   Id == equipments.Id &&
                   Count == equipments.Count &&
                   RequestId == equipments.RequestId &&
                   EquipmentTypeId == equipments.EquipmentTypeId;
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
