using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    /// <summary>
    /// Класс сущность таблица едениц измерения
    /// </summary>
    public class Unit
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Полное наименование еденицы измерения
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Fullname { get; set; }
        /// <summary>
        /// Сокращенное наименование еденицы измерения
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Shortname { get; set; }
    }
}
