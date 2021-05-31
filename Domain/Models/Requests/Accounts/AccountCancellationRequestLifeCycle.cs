using Domain.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests.Accounts
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Жизненный цикл заявки на аннулирование учетной записи"
    /// </summary>
    public class AccountCancellationRequestLifeCycle:LifeCycle
    {
        /// <summary>
        /// Идентификатор заявки на аннулирование учетной записи
        /// </summary>
        [Required]
        public int RequestId { get; set; }
        /// <summary>
        /// Объект заявки на аннулирование учетной записи
        /// </summary>
        public AccountCancellationRequest Request { get; set; }       
    }
}
