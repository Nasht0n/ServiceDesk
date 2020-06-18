using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на регистрацию учетной записи
    /// </summary>
    public interface IAccountRegistrationRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на регистрацию учетной записи
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на регистрацию учетной записи</param>
        /// <returns>Возвращает объект жизненного цикла заявки на регистрацию учетной записи</returns>
        Task<AccountRegistrationRequestLifeCycle> Add(AccountRegistrationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на регистрацию учетной записи
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на регистрацию учетной записи</param>
        /// <returns>Возвращает объект жизненного цикла заявки на регистрацию учетной записи</returns>
        Task<AccountRegistrationRequestLifeCycle> Update(AccountRegistrationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на регистрацию учетной записи
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на регистрацию учетной записи</param>
        /// <returns></returns>
        Task Delete(AccountRegistrationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на регистрацию учетной записи
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на регистрацию учетной записи</returns>
        Task<List<AccountRegistrationRequestLifeCycle>> GetLifeCycles();
    }
}
