using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Requests
{
    /// <summary>
    /// Интерфейс доступа к заявке об утере учетной записи
    /// </summary>
    public interface IAccountLossRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки об утере учетной записи
        /// </summary>
        /// <param name="request">Запись заявки об утере учетной записи</param>
        /// <returns>Возвращает объект заявки об утере учетной записи</returns>
        Task<AccountLossRequest> Add(AccountLossRequest request);
        /// <summary>
        /// Метод редактировния записи заявки об утере учетной записи
        /// </summary>
        /// <param name="request">Запись заявки об утере учетной записи</param>
        /// <returns>Возвращает объект заявки об утере учетной записи</returns>
        Task<AccountLossRequest> Update(AccountLossRequest request);
        /// <summary>
        /// Метод удаления записи заявки об утере учетной записи
        /// </summary>
        /// <param name="request">Запись заявки об утере учетной записи</param>
        /// <returns></returns>
        Task Delete(AccountLossRequest request);
        /// <summary>
        /// Метод получения списка записей заявки об утере учетной записи
        /// </summary>
        /// <returns>Возвращает список записей заявки об утере учетной записи</returns>
        Task<List<AccountLossRequest>> GetRequests();
    }
}
