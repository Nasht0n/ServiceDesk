using Domain.Models.Requests.Email;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Email.Requests
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок на увеличение объема почтового ящика
    /// </summary>
    public interface IEmailSizeIncreaseRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на увеличение объема почтового ящика
        /// </summary>
        /// <param name="request">Запись заявки на увеличение объема почтового ящика</param>
        /// <returns>Возвращает объект заявки на увеличение объема почтового ящика</returns>
        Task<EmailSizeIncreaseRequest> Add(EmailSizeIncreaseRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на увеличение объема почтового ящика
        /// </summary>
        /// <param name="request">Запись заявки на увеличение объема почтового ящика</param>
        /// <returns>Возвращает объект заявки на увеличение объема почтового ящика</returns>
        Task<EmailSizeIncreaseRequest> Update(EmailSizeIncreaseRequest request);
        /// <summary>
        /// Метод удаления записи заявки на увеличение объема почтового ящика
        /// </summary>
        /// <param name="request">Запись заявки на увеличение объема почтового ящика</param>
        /// <returns></returns>
        Task Delete(EmailSizeIncreaseRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на увеличение объема почтового ящика
        /// </summary>
        /// <returns>Возвращает список записей заявки на увеличение объема почтового ящика</returns>
        Task<List<EmailSizeIncreaseRequest>> GetRequests();
    }
}
