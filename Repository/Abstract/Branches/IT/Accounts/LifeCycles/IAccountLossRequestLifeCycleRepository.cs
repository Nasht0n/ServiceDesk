using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки об утере учетной записи
    /// </summary>
    public interface IAccountLossRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки об утере учетной записи
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки об утере учетной записи</param>
        /// <returns>Возвращает объект жизненного цикла заявки об утере учетной записи</returns>
        Task<AccountLossRequestLifeCycle> Add(AccountLossRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки об утере учетной записи
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки об утере учетной записи</param>
        /// <returns>Возвращает объект жизненного цикла заявки об утере учетной записи</returns>
        Task<AccountLossRequestLifeCycle> Update(AccountLossRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки об утере учетной записи
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки об утере учетной записи</param>
        /// <returns></returns>
        Task Delete(AccountLossRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки об утере учетной записи
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки об утере учетной записи</returns>
        Task<List<AccountLossRequestLifeCycle>> GetLifeCycles();
    }
}
