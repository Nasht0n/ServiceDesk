using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Requests
{
    /// <summary>
    /// Интерфейс доступа к заявке на отключение учетной записи
    /// </summary>
    public interface IAccountDisconnectRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на отключение учетной записи
        /// </summary>
        /// <param name="request">Запись заявки на отключение учетной записи</param>
        /// <returns>Возвращает объект заявки на отключение учетной записи</returns>
        Task<AccountDisconnectRequest> Add(AccountDisconnectRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на аннулирование учетной записи
        /// </summary>
        /// <param name="request">Запись заявки на аннулирование учетной записи</param>
        /// <returns>Возвращает объект заявки на аннулирование учетной записи</returns>
        Task<AccountDisconnectRequest> Update(AccountDisconnectRequest request);
        /// <summary>
        /// Метод удаления записи заявки на отключение учетной записи
        /// </summary>
        /// <param name="request">Запись заявки на отключение учетной записи</param>
        /// <returns></returns>
        Task Delete(AccountDisconnectRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на отключение учетной записи
        /// </summary>
        /// <returns>Возвращает список записей заявки на отключение учетной записи</returns>
        Task<List<AccountDisconnectRequest>> GetRequests();
    }
}
