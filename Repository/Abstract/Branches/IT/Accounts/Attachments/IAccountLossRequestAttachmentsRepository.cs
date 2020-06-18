using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Attachments
{
    /// <summary>
    /// Класс доступа к хранилищу прикрепленных файлов заявка об утере учетной записи
    /// </summary>
    public interface IAccountLossRequestAttachmentsRepository
    {
        /// <summary>
        /// Метод добавления файла к заявке об утере учетной записи
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns>Объект прикрепленного файла к заявке об утере учетной записи</returns>
        Task<AccountLossRequestAttachment> Add(AccountLossRequestAttachment attachment);
        /// <summary>
        /// Метод удаления файла заявки об утере учетной записи
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns></returns>
        Task Delete(AccountLossRequestAttachment attachment);
        /// <summary>
        /// Метод получения списка прикрепленных файлов заявки об утере учетной записи
        /// </summary>
        /// <returns>Возвращает список прикрепленных файлов заявки об утере учетной записи</returns>
        Task<List<AccountLossRequestAttachment>> GetAttachments();
    }
}
