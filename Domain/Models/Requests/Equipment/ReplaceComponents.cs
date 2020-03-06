namespace Domain.Models.Requests.Equipment
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Комплектующее оборудование под замену"
    /// </summary>
    public class ReplaceComponents
    {
        /// <summary>
        /// Идентификатор комплектующего оборудования под замену
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Количество единиц
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Идентификатор комплектующего 
        /// </summary>
        public int ComponentId { get; set; }
        /// <summary>
        /// Объект комплектующего
        /// </summary>
        public Component Component { get; set; }
        /// <summary>
        /// Идентификатор заявки на замену комплектующего оборудования
        /// </summary>
        public int RequestId { get; set; }
        /// <summary>
        /// Объект заявки на замену комплектующего оборудования
        /// </summary>
        public ComponentReplaceRequest Request { get; set; }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public ReplaceComponents() {  }
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="count">Количество единиц</param>
        /// <param name="componentId">Идентификатор комплектующего </param>
        /// <param name="requestId">Идентификатор заявки на замену комплектующего оборудования</param>
        public ReplaceComponents(int count, int componentId, int requestId)
        {
            Count = count;
            ComponentId = componentId;
            RequestId = requestId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода сравнения объектов.
        /// </summary>
        /// <param name="obj">Объект для сравнения</param>
        /// <returns>Возвращает true — в случае идентичности объектов, иначе — false.</returns>
        public override bool Equals(object obj)
        {
            return obj is ReplaceComponents components &&
                   Id == components.Id &&
                   Count == components.Count &&
                   ComponentId == components.ComponentId &&
                   RequestId == components.RequestId;
        }
        /// <summary>
        /// Метод переопределения стандартного метода ToString(). 
        /// Выводим информацию о текущем объекте.
        /// </summary>
        /// <returns>Возвращает строковое представление записи заменяемого комплектующего оборудования.</returns>
        public override string ToString()
        {
            return $"ReplaceComponent object:(Id:[{Id}];Count:[{Count}];ComponentId:[{ComponentId}];RequestId:[{RequestId}]).";
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
