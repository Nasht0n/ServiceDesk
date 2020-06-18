using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу разрешений доступа в системе
    /// </summary>
    public interface IPermissionRepository
    {
        /// <summary>
        /// Метод получения списка прав доступа в системе
        /// </summary>
        /// <returns>Возвращает список прав доступа в системе</returns>
        Task<List<Permission>> GetPermissions();
    }
}
