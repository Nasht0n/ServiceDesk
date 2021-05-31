using Domain.Abstract;
using Domain.Models.ManyToMany;
using System.Collections.Generic;

namespace Domain.Models.Requests.Accounts
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Заявка на отключение учетной записи"
    /// </summary>
    public class AccountDisconnectRequest:Request
    {
        /// <summary>
        /// Список прикрепленных файлов
        /// </summary>
        public virtual ICollection<AccountDisconnectRequestAttachment> Attachments { get; set; }
        public virtual ICollection<AccountDisconnectRequestLifeCycle> LifeCycles { get; set; }       
    }
}
