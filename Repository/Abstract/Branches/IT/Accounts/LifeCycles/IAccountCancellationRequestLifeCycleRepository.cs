using Domain.Models.Requests.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Accounts.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на аннулирование учетной записи
    /// </summary>
    public interface IAccountCancellationRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на аннулирование учетной записи
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на аннулирование учетной записи</param>
        /// <returns>Возвращает объект жизненного цикла заявки на аннулирование учетной записи</returns>
        Task<AccountCancellationRequestLifeCycle> Add(AccountCancellationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на аннулирование учетной записи
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на аннулирование учетной записи</param>
        /// <returns>Возвращает объект жизненного цикла заявки на аннулирование учетной записи</returns>
        Task<AccountCancellationRequestLifeCycle> Update(AccountCancellationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на аннулирование учетной записи
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на аннулирование учетной записи</param>
        /// <returns></returns>
        Task Delete(AccountCancellationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на аннулирование учетной записи
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на аннулирование учетной записи</returns>
        Task<List<AccountCancellationRequestLifeCycle>> GetLifeCycles();
    }
}
