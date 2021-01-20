using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Software.Requests
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок о состоянии информации
    /// </summary>
    public interface IInformationStatusRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки о состоянии информации
        /// </summary>
        /// <param name="request">Запись заявки о состоянии информации</param>
        /// <returns>Возвращает объект заявки о состоянии информации</returns>
        Task<InformationStatusRequest> Add(InformationStatusRequest request);
        /// <summary>
        /// Метод редактировния записи заявки о состоянии информации
        /// </summary>
        /// <param name="request">Запись заявки о состоянии информации</param>
        /// <returns>Возвращает объект заявки о состоянии информации</returns>
        Task<InformationStatusRequest> Update(InformationStatusRequest request);
        /// <summary>
        /// Метод удаления записи заявки о состоянии информации
        /// </summary>
        /// <param name="request">Запись заявки о состоянии информации</param>
        /// <returns></returns>
        Task Delete(InformationStatusRequest request);
        /// <summary>
        /// Метод получения списка записей заявки о состоянии информации
        /// </summary>
        /// <returns>Возвращает список записей заявки о состоянии информации</returns>
        Task<List<InformationStatusRequest>> GetRequests();
    }
}
