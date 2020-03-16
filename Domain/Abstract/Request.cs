using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.Abstract
{
    /// <summary>
    /// Абстрактный класс описания заявки
    /// </summary>
    public abstract class Request
    {
        /// <summary>
        /// Идентификатор заявки
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Тема заявки
        /// </summary>
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
        /// <summary>
        /// Обоснование заявки
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Justification { get; set; }
        /// <summary>
        /// Описание заявки
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        /// <summary>
        /// Идентификатор вида работы, указанной заявки
        /// </summary>
        [Required]
        public int ServiceId { get; set; }
        /// <summary>
        /// Объект вида работы, указанной заявки
        /// </summary>
        public Service Service { get; set; }
        /// <summary>
        /// Идентификатор статуса, указанной заявки
        /// </summary>
        [Required]
        public int StatusId { get; set; }
        /// <summary>
        /// Объект статуса, указанной заявки
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// Идентификатор приоритета выполнения, указанной заявки
        /// </summary>
        [Required]
        public int PriorityId { get; set; }
        /// <summary>
        /// Объект приоритета выполнения, указанной заявки
        /// </summary>
        public Priority Priority { get; set; }
        /// <summary>
        /// Идентификатор пользователя, создавшего указанную заявку
        /// </summary>
        [Required]
        public int ClientId { get; set; }
        /// <summary>
        /// Объект пользователя, создавшего указанную заявку 
        /// </summary>
        public Employee Client { get; set; }
        /// <summary>
        /// Идентификатор пользователя, назначенного исполнителем указанной заявки
        /// </summary>
        public int? ExecutorId { get; set; }
        /// <summary>
        /// Объект пользователя, назначенного исполнителем указанной заявки
        /// </summary>
        public Employee Executor { get; set; }
        /// <summary>
        /// Идентификатор группы исполнителей, указанной заявки
        /// </summary>
        [Required]
        public int ExecutorGroupId { get; set; }
        /// <summary>
        /// Объект группы исполнителей, указанной заявки
        /// </summary>
        public ExecutorGroup ExecutorGroup { get; set; }
    }
}
