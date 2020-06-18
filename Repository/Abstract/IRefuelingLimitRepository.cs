using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу лимитов заправки
    /// </summary>
    public interface IRefuelingLimitRepository
    {
        /// <summary>
        /// Метод добавления лимита заправки
        /// </summary>
        /// <param name="limit">Объект лимита заправки</param>
        /// <returns>Возвращает добавленный объект лимита заправки</returns>
        Task<RefuelingLimits> Add(RefuelingLimits limit);
        /// <summary>
        /// Метод удаления лимита заправки
        /// </summary>
        /// <param name="limit">Объект лимита заправки</param>
        /// <returns></returns>
        Task Delete(RefuelingLimits limit);
        /// <summary>
        /// Метод получения списка лимитов заправки
        /// </summary>
        /// <returns>Список лимитов заправки</returns>
        Task<List<RefuelingLimits>> GetLimits();
        /// <summary>
        /// Метод обновления лимита заправки
        /// </summary>
        /// <param name="limit">Объект лимита заправки</param>
        /// <returns>Возвращает отредактированный объект лимита заправки</returns>
        Task<RefuelingLimits> Update(RefuelingLimits limit);
    }
}
