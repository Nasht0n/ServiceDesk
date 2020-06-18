using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Attachments
{
    /// <summary>
    /// Интерфейс доступа к хранилищу прикрепленных файлов заявка аннулирования учетной записи
    /// </summary>
    public interface IAccountCancellationRequestAttachmentsRepository
    {
        /// <summary>
        /// Метод добавления файла к заявке аннулирования учетной записи
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns>Объект прикрепленного файла к заявке аннулирования учетной записи</returns>
        Task<AccountCancellationRequestAttachment> Add(AccountCancellationRequestAttachment attachment);
        /// <summary>
        /// Метод удаления файла заявки аннулирования учетной записи
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns></returns>
        Task Delete(AccountCancellationRequestAttachment attachment);
        /// <summary>
        /// Метод получения списка прикрепленных файлов заявки на аннулирования учетной записи
        /// </summary>
        /// <returns>Возвращает список прикрепленных файлов заявки на аннулирования учетной записи</returns>
        Task<List<AccountCancellationRequestAttachment>> GetAttachments();
    }
}
