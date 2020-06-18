using Domain.Models.Requests.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Events.Requests
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок на техническое сопровождение мероприятия
    /// </summary>
    public interface ITechnicalSupportEventRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на техническое сопровождение мероприятия
        /// </summary>
        /// <param name="request">Запись заявки на техническое сопровождение мероприятия</param>
        /// <returns>Возвращает объект заявки на техническое сопровождение мероприятия</returns>
        Task<TechnicalSupportEventRequest> Add(TechnicalSupportEventRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на техническое сопровождение мероприятия
        /// </summary>
        /// <param name="request">Запись заявки на техническое сопровождение мероприятия</param>
        /// <returns>Возвращает объект заявки на техническое сопровождение мероприятия</returns>
        Task<TechnicalSupportEventRequest> Update(TechnicalSupportEventRequest request);
        /// <summary>
        /// Метод удаления записи заявки на техническое сопровождение мероприятия
        /// </summary>
        /// <param name="request">Запись заявки на техническое сопровождение мероприятия</param>
        /// <returns></returns>
        Task Delete(TechnicalSupportEventRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на техническое сопровождение мероприятия
        /// </summary>
        /// <returns>Возвращает список записей заявки на техническое сопровождение мероприятия</returns>
        Task<List<TechnicalSupportEventRequest>> GetRequests();
    }
}
