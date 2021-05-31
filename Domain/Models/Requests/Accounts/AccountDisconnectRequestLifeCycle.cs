using Domain.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests.Accounts
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Жизненный цикл заявки на отключение учетной записи"
    /// </summary>
    public class AccountDisconnectRequestLifeCycle:LifeCycle
    {
        /// <summary>
        /// Идентификатор заявки на отключение учетной записи
        /// </summary>
        [Required]
        public int RequestId { get; set; }
        /// <summary>
        /// Объект заявки на отключение учетной записи
        /// </summary>
        public AccountDisconnectRequest Request { get; set; }       
    }
}
