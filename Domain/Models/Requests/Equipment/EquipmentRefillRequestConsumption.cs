namespace Domain.Models.Requests.Equipment
{
    /// <summary>
    /// Расход материалов на заправку 
    /// </summary>
    public class EquipmentRefillRequestConsumption
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор заявки
        /// </summary>
        public int RequestId { get; set; }
        /// <summary>
        /// Идентификатор расходника
        /// </summary>
        public int ConsumableId { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Еденица измерения
        /// </summary>
        public string Unit { get; set; }

        public EquipmentRefillRequest Request { get; set; }
        public Consumable Consumable { get; set; }
    }
}
