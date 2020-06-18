using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу прикрепленных файлов в заявках системы
    /// </summary>
    public interface IAttachmentRepository
    {
        /// <summary>
        /// Метод добавления записи прикрепленного файла
        /// </summary>
        /// <param name="attachment">Прикрепленный файл</param>
        /// <returns>Объект прикрепленного файла</returns>
        Task<Attachment> Add(Attachment attachment);
        /// <summary>
        /// Метод редактирования записи прикрепленного файла
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns></returns>
        Task<Attachment> Update(Attachment attachment);
        /// <summary>
        /// Метод удаления записи прикрепленного файла
        /// </summary>
        /// <param name="attachment">Прикрепленный файл</param>
        /// <returns></returns>
        Task Delete(Attachment attachment);
        /// <summary>
        /// Метод получения списка прикрепленных файлов
        /// </summary>
        /// <returns>Возвращает список прикрепленных файлов</returns>
        Task<List<Attachment>> GetAttachments();
    }
}
