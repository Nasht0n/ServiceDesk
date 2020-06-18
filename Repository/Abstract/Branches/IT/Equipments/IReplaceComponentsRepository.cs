using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments
{
    /// <summary>
    /// Интерфейс доступа к хранилищу заменяемого комплектующего
    /// </summary>
    public interface IReplaceComponentsRepository
    {
        /// <summary>
        /// Метод добавления записи заменяемого комплектующего
        /// </summary>
        /// <param name="request">Запись заменяемого комплектующего</param>
        /// <returns>Возвращает объект заменяемого комплектующего</returns>
        Task<ReplaceComponents> Add(ReplaceComponents components);
        /// <summary>
        /// Метод редактировния записи заменяемого комплектующего
        /// </summary>
        /// <param name="request">Запись заменяемого комплектующего</param>
        /// <returns>Возвращает объект заменяемого комплектующего</returns>
        Task<ReplaceComponents> Update(ReplaceComponents components);
        /// <summary>
        /// Метод удаления записи заменяемого комплектующего
        /// </summary>
        /// <param name="request">Запись заменяемого комплектующего</param>
        /// <returns></returns>
        Task Delete(ReplaceComponents components);
        /// <summary>
        /// Метод получения списка записей заменяемого комплектующего
        /// </summary>
        /// <returns>Возвращает список записей заменяемого комплектующего</returns>
        Task<List<ReplaceComponents>> GetComponents();
    }
}
