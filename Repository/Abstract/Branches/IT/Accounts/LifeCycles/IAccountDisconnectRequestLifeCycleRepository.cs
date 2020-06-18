using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на отключение учетной записи
    /// </summary>
    public interface IAccountDisconnectRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на отключение учетной записи
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на отключение учетной записи</param>
        /// <returns>Возвращает объект жизненного цикла заявки на отключение учетной записи</returns>
        Task<AccountDisconnectRequestLifeCycle> Add(AccountDisconnectRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на отключение учетной записи
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на отключение учетной записи</param>
        /// <returns>Возвращает объект жизненного цикла заявки на отключение учетной записи</returns>
        Task<AccountDisconnectRequestLifeCycle> Update(AccountDisconnectRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на отключение учетной записи
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на отключение учетной записи</param>
        /// <returns></returns>
        Task Delete(AccountDisconnectRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на отключение учетной записи
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на отключение учетной записи</returns>
        Task<List<AccountDisconnectRequestLifeCycle>> GetLifeCycles();
    }
}
