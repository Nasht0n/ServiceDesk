using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу учетных записей системы
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Метод добавления учетной записи
        /// </summary>
        /// <param name="account">Объект учетной записи</param>
        /// <returns></returns>
        Task<Account> AddAccount(Account account);
        /// <summary>
        /// Метод редактирования учетной записи
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Task<Account> UpdateAccount(Account account);
        /// <summary>
        /// Метод удаления учетной записи
        /// </summary>
        /// <param name="account">Объект учетной записи</param>
        /// <returns></returns>
        Task DeleteAccount(Account account);
        /// <summary>
        /// Метод получения списка учетных записей
        /// </summary>
        /// <returns>Возвращает список учетных записей</returns>
        Task<List<Account>> GetAccounts();
    }
}
