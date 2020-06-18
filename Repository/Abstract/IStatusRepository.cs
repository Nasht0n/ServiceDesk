using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу статусов заявок
    /// </summary>
    public interface IStatusRepository
    {
        /// <summary>
        /// Метод добавления статуса заявок
        /// </summary>
        /// <param name="status">Запись статуса заявок</param>
        /// <returns>Возвращает объект статуса заявок</returns>
        Task<Status> Add(Status status);
        /// <summary>
        /// Метод обновления статуса заявок
        /// </summary>
        /// <param name="status">Запись статуса заявок</param>
        /// <returns>Возвращает объект статус заявок</returns>
        Task<Status> Update(Status status);
        /// <summary>
        /// Метод удаления статуса заявок
        /// </summary>
        /// <param name="status">Запись статуса заявок</param>
        /// <returns></returns>
        Task Delete(Status status);
        /// <summary>
        /// Метод получения списка статусов заявок
        /// </summary>
        /// <returns>Возвращает список статусов заявок</returns>
        Task<List<Status>> GetStatuses();
    }
}
