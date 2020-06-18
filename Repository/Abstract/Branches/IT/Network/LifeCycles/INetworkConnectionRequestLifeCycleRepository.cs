using Domain.Models.Requests.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Network.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на подключение оборудования к ЛВС
    /// </summary>
    public interface INetworkConnectionRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на подключение оборудования к ЛВС
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на подключение оборудования к ЛВС</param>
        /// <returns>Возвращает объект жизненного цикла заявки на подключение оборудования к ЛВС</returns>
        Task<NetworkConnectionRequestLifeCycle> Add(NetworkConnectionRequestLifeCycle request);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на подключение оборудования к ЛВС
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на подключение оборудования к ЛВС</param>
        /// <returns>Возвращает объект жизненного цикла заявки на подключение оборудования к ЛВС</returns>
        Task<NetworkConnectionRequestLifeCycle> Update(NetworkConnectionRequestLifeCycle request);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на подключение оборудования к ЛВС
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на подключение оборудования к ЛВС</param>
        /// <returns></returns>
        Task Delete(NetworkConnectionRequestLifeCycle request);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на подключение оборудования к ЛВС
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на подключение оборудования к ЛВС</returns>
        Task<List<NetworkConnectionRequestLifeCycle>> GetRequests();
    }
}
