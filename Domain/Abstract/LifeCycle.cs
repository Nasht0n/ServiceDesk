using Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Abstract
{
    /// <summary>
    /// Абстрактный класс описания жизненного цикла заявки
    /// </summary>
    public abstract class LifeCycle
    {
        /// <summary>
        /// Идентификатор жизненного цикла заявки
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Дата и время события в жизненном цикле заявки
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
        /// <summary>
        /// Сообщение жизненного цикла заявки
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Message { get; set; }
        /// <summary>
        /// Идентификатор пользователя, создавшего запись жизненного цикла
        /// </summary>
        [Required]
        public int EmployeeId { get; set; }
        /// <summary>
        /// Объект пользователя, создавшего запись жизненного цикла
        /// </summary>
        public Employee Employee { get; set; }
    }
}
