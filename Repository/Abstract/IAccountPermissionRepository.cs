using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс хранилища данных прав доступа учетной записи
    /// </summary>
    public interface IAccountPermissionRepository
    {
        /// <summary>
        /// Метод добавления разрешения права доступа для учетной записи пользователя
        /// </summary>
        /// <param name="accountPermission">Объект разрешения учетной записи</param>
        /// <returns>Возвращает объект разрешения учетной записи</returns>
        Task<AccountPermission> AddAccountPermission(AccountPermission accountPermission);
        /// <summary>
        /// Метод удаления разрешения права доступа для учетной записи пользователя
        /// </summary>
        /// <param name="accountPermission">Объект разрешения учетной записи</param>
        /// <returns></returns>
        Task DeleteAccountPermission(AccountPermission accountPermission);
        /// <summary>
        /// Метод получения списка разрешений прав доступа для учетных записей системы
        /// </summary>
        /// <returns></returns>
        Task<List<AccountPermission>> GetAccountPermissions();
    }
}
