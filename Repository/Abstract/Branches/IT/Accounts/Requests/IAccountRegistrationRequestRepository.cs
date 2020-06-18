using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.Requests
{
    /// <summary>
    /// Интерфейс доступа к заявке на регистрацию учетной записи
    /// </summary>
    public interface IAccountRegistrationRequestRepository
    {
        /// <summary>
        /// Метод добавления записи заявки на регистрацию учетной записи
        /// </summary>
        /// <param name="request">Запись заявки на регистрацию учетной записи</param>
        /// <returns>Возвращает объект заявки на регистрацию учетной записи</returns>
        Task<AccountRegistrationRequest> Add(AccountRegistrationRequest request);
        /// <summary>
        /// Метод редактировния записи заявки на регистрацию учетной записи
        /// </summary>
        /// <param name="request">Запись заявки на регистрацию учетной записи</param>
        /// <returns>Возвращает объект заявки на регистрацию учетной записи</returns>
        Task<AccountRegistrationRequest> Update(AccountRegistrationRequest request);
        /// <summary>
        /// Метод удаления записи заявки на регистрацию учетной записи
        /// </summary>
        /// <param name="request">Запись заявки на регистрацию учетной записи</param>
        /// <returns></returns>
        Task Delete(AccountRegistrationRequest request);
        /// <summary>
        /// Метод получения списка записей заявки на регистрацию учетной записи
        /// </summary>
        /// <returns>Возвращает список записей заявки на регистрацию учетной записи</returns>
        Task<List<AccountRegistrationRequest>> GetRequests();
    }
}
