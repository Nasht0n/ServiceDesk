using Domain.Abstract;
using Domain.Models.ManyToMany;
using System.Collections.Generic;

namespace Domain.Models.Requests.Accounts
{
    /// <summary>
    /// Класс-сущность, содержащий описание данных для хранения в таблице "Заявка на аннулирование учетной записи"
    /// </summary>
    public class AccountCancellationRequest:Request
    {
        /// <summary>
        /// Список прикрепленных файлов
        /// </summary>
        public virtual ICollection<AccountCancellationRequestAttachment> Attachments { get; set; }
        public virtual ICollection<AccountCancellationRequestLifeCycle> LifeCycles { get; set; }
    }
}
