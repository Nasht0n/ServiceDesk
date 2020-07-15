using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу едениц измерений
    /// </summary>
    public interface IUnitRepository
    {
        /// <summary>
        /// Метод добавления еденицы измерения
        /// </summary>
        /// <param name="unit">Еденица измерения</param>
        /// <returns>Возвращает объект еденицы измерения</returns>
        Task<Unit> Add(Unit unit);
        /// <summary>
        /// Метод редактирования еденицы измерения
        /// </summary>
        /// <param name="unit">Еденица измерения</param>
        /// <returns>Возвращает объект еденицы измерения</returns>
        Task<Unit> Update(Unit unit);
        /// <summary>
        /// Метод удаления еденицы измерения
        /// </summary>
        /// <param name="unit">Еденица измерения</param>
        /// <returns></returns>
        Task Delete(Unit unit);
        /// <summary>
        /// Метод получения списка едениц измерения
        /// </summary>
        /// <returns>Возвращает список едениц измерения</returns>
        Task<List<Unit>> GetUnits();
    }
}
