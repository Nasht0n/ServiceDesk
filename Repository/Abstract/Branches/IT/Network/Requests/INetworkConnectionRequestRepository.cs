using Domain.Models.Requests.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Network.Requests
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок на подключение оборудования к ЛВС
    /// </summary>
    public interface INetworkConnectionRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на подключение оборудования к ЛВС
        /// </summary>
        /// <param name="request">Запись заявки на подключение оборудования к ЛВС</param>
        /// <returns>Возвращает объект заявки на подключение оборудования к ЛВС</returns>
        Task<NetworkConnectionRequest> Add(NetworkConnectionRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на подключение оборудования к ЛВС
        /// </summary>
        /// <param name="request">Запись заявки на подключение оборудования к ЛВС</param>
        /// <returns>Возвращает объект заявки на подключение оборудования к ЛВС</returns>
        Task<NetworkConnectionRequest> Update(NetworkConnectionRequest request);
        /// <summary>
        /// Метод удаления записи заявки на подключение оборудования к ЛВС
        /// </summary>
        /// <param name="request">Запись заявки на подключение оборудования к ЛВС</param>
        /// <returns></returns>
        Task Delete(NetworkConnectionRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на подключение оборудования к ЛВС
        /// </summary>
        /// <returns>Возвращает список записей заявки на подключение оборудования к ЛВС</returns>
        Task<List<NetworkConnectionRequest>> GetRequests();
    }
}
