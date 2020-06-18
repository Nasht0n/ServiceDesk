using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Software.Attachments
{
    /// <summary>
    /// Класс доступа к хранилищу прикрепленных файлов заявка на доработку программного обеспечения
    /// </summary>
    public interface ISoftwareReworkRequestAttachmentsRepository
    {
        /// <summary>
        /// Метод добавления файла к заявке аннулирования учетной записи
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns>Объект прикрепленного файла к заявке аннулирования учетной записи</returns>
        Task<SoftwareReworkRequestAttachment> Add(SoftwareReworkRequestAttachment attachment);
        /// <summary>
        /// Метод удаления файла заявки аннулирования учетной записи
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns></returns>
        Task Delete(SoftwareReworkRequestAttachment attachment);
        /// <summary>
        /// Метод получения списка прикрепленных файлов заявки на аннулирования учетной записи
        /// </summary>
        /// <returns>Возвращает список прикрепленных файлов заявки на аннулирования учетной записи</returns>
        Task<List<SoftwareReworkRequestAttachment>> GetAttachments();
    }
}
