using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу приоритетов заявки
    /// </summary>
    public interface IPriorityRepository
    {
        /// <summary>
        /// Метод добавления приоритета заявки
        /// </summary>
        /// <param name="priority">Запись приоритета заявки</param>
        /// <returns>Возвращает объект приоритета заявки</returns>
        Task<Priority> Add(Priority priority);
        /// <summary>
        /// Метод обновления приоритета заявки
        /// </summary>
        /// <param name="priority">Объект приоритета заявки</param>
        /// <returns>Возвращает отредактированный объект приоритета заявки</returns>
        Task<Priority> Update(Priority priority);
        /// <summary>
        /// Метод удаления приоритета заявки
        /// </summary>
        /// <param name="priority">Объект приоритета заявки</param>
        /// <returns></returns>
        Task Delete(Priority priority);
        /// <summary>
        /// Метод получения списка приоритетов заявки
        /// </summary>
        /// <returns>Возвращает список приоритетов заявки</returns>
        Task<List<Priority>> GetPriorities();        
    }
}
