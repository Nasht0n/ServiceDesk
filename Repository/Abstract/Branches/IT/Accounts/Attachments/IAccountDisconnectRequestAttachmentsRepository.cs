using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Attachments
{
    /// <summary>
    /// Интерфейс доступа к хранилищу прикрепленных файлов заявка отключения учетной записи
    /// </summary>
    public interface IAccountDisconnectRequestAttachmentsRepository
    {
        /// <summary>
        /// Метод добавления файла к заявке отключения учетной записи
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns>Объект прикрепленного файла к заявке отключения учетной записи</returns>
        Task<AccountDisconnectRequestAttachment> Add(AccountDisconnectRequestAttachment attachment);
        /// <summary>
        /// Метод удаления файла заявки отключения учетной записи
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns></returns>
        Task Delete(AccountDisconnectRequestAttachment attachment);
        /// <summary>
        /// Метод получения списка прикрепленных файлов заявки на отключение учетной записи
        /// </summary>
        /// <returns>Возвращает список прикрепленных файлов заявки на отключение учетной записи</returns>
        Task<List<AccountDisconnectRequestAttachment>> GetAttachments();
    }
}
