using Domain.Models.Requests.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Events.Requests
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок на проведение видеосвязи
    /// </summary>
    public interface IVideoCommunicationRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на проведение видеосвязи
        /// </summary>
        /// <param name="request">Запись заявки на проведение видеосвязи</param>
        /// <returns>Возвращает объект заявки на проведение видеосвязи</returns>
        Task<VideoCommunicationRequest> Add(VideoCommunicationRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на проведение видеосвязи
        /// </summary>
        /// <param name="request">Запись заявки на проведение видеосвязи</param>
        /// <returns>Возвращает объект заявки на проведение видеосвязи</returns>
        Task<VideoCommunicationRequest> Update(VideoCommunicationRequest request);
        /// <summary>
        /// Метод удаления записи заявки на проведение видеосвязи
        /// </summary>
        /// <param name="request">Запись заявки на проведение видеосвязи</param>
        /// <returns></returns>
        Task Delete(VideoCommunicationRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на проведение видеосвязи
        /// </summary>
        /// <returns>Возвращает список записей заявки на проведение видеосвязи</returns>
        Task<List<VideoCommunicationRequest>> GetRequests();
    }
}
