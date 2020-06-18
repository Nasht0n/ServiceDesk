using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Software.Attachments
{
    /// <summary>
    /// Интерфейс доступа к хранилищу прикрепленных файлов заявка на разработку программного обеспечения
    /// </summary>
    public interface ISoftwareDevelopmentRequestAttachmentsRepository
    {
        /// <summary>
        /// Метод добавления файла к заявке на разработку программного обеспечения
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns>Объект прикрепленного файла к заявке на разработку программного обеспечения</returns>
        Task<SoftwareDevelopmentRequestAttachment> Add(SoftwareDevelopmentRequestAttachment attachment);
        /// <summary>
        /// Метод удаления файла заявки на разработку программного обеспечения
        /// </summary>
        /// <param name="attachment">Запись прикрепленного файла</param>
        /// <returns></returns>
        Task Delete(SoftwareDevelopmentRequestAttachment attachment);
        /// <summary>
        /// Метод получения списка прикрепленных файлов заявки на разработку программного обеспечения
        /// </summary>
        /// <returns>Возвращает список прикрепленных файлов заявки на разработку программного обеспечения</returns>
        Task<List<SoftwareDevelopmentRequestAttachment>> GetAttachments();
    }
}
