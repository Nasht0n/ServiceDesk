using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Расходный материал"
    /// </summary>
    public class Consumable
    {
        /// <summary>
        /// Идентификатор расходного материала
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор типа расходного материала
        /// </summary>
        public int TypeId { get; set; }        
        /// <summary>
        /// Наименование расходного материала
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// Инвентарный номер расходного материала
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string InventoryNumber { get; set; }
        /// <summary>
        /// Идентификатор еденицы измерения
        /// </summary>
        [Required]        
        public int UnitId { get; set; }

        public ConsumableType Type { get; set; }
        public Unit Unit { get; set; }
    }
}
