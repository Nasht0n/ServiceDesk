using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Requests
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заявок на аннулирование учетной записи
    /// </summary>
    public interface IAccountCancellationRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на аннулирование учетной записи
        /// </summary>
        /// <param name="request">Запись заявки на аннулирование учетной записи</param>
        /// <returns>Возвращает объект заявки на аннулирование учетной записи</returns>
        Task<AccountCancellationRequest> Add(AccountCancellationRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на аннулирование учетной записи
        /// </summary>
        /// <param name="request">Запись заявки на аннулирование учетной записи</param>
        /// <returns>Возвращает объект заявки на аннулирование учетной записи</returns>
        Task<AccountCancellationRequest> Update(AccountCancellationRequest request);
        /// <summary>
        /// Метод удаления записи заявки на аннулирование учетной записи
        /// </summary>
        /// <param name="request">Запись заявки на аннулирование учетной записи</param>
        /// <returns></returns>
        Task Delete(AccountCancellationRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на аннулирование учетной записи
        /// </summary>
        /// <returns>Возвращает список записей заявки на аннулирование учетной записи</returns>
        Task<List<AccountCancellationRequest>> GetRequests();
    }
}
