using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу видов комплектующего
    /// </summary>
    public interface IComponentRepository
    {
        /// <summary>
        /// Метод добавления вида комплектующего
        /// </summary>
        /// <param name="component">Запись вида комплектующего</param>
        /// <returns>Возвращает запись вида комплектующего</returns>
        Task<Component> Add(Component component);
        /// <summary>
        /// Метод обновления вида комплектующего
        /// </summary>
        /// <param name="component">Запись вида комплектующего</param>
        /// <returns>Возвращает запись вида комплектующего</returns>
        Task<Component> Update(Component component);
        /// <summary>
        /// Метод удаления вида комплектующего
        /// </summary>
        /// <param name="component">Запись вида комплектующего</param>
        /// <returns></returns>
        Task Delete(Component component);
        /// <summary>
        /// Метод получения списка видов комплектующего
        /// </summary>
        /// <returns>Возвращает список видов комплектующего</returns>
        Task<List<Component>> GetComponents();
    }
}
