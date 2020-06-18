using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Attachments
{
    /// <summary>
    /// Интерфейс доступа к хранилищу прикрепленных файлов заявки на регистрацию учетной записи
    /// </summary>
    public interface IAccountRegistrationRequestAttachmentsRepository
    {
        /// <summary>
        /// Метод добавления файла к заявке на регистрацию учетной записи
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns>Объект прикрепленного файла к заявке на регистрацию учетной записи</returns>
        Task<AccountRegistrationRequestAttachment> Add(AccountRegistrationRequestAttachment attachment);
        /// <summary>
        /// Метод удаления файла заявки на регистрацию учетной записи
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns></returns>
        Task Delete(AccountRegistrationRequestAttachment attachment);
        /// <summary>
        /// Метод получения списка прикрепленных файлов заявки на регистрацию учетной записи
        /// </summary>
        /// <returns>Возвращает список прикрепленных файлов заявки на регистрацию учетной записи</returns>
        Task<List<AccountRegistrationRequestAttachment>> GetAttachments();
    }
}
