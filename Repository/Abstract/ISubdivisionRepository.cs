using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу подразделений
    /// </summary>
    public interface ISubdivisionRepository
    {
        /// <summary>
        /// Метод добавления подразделения
        /// </summary>
        /// <param name="subdivision">Запись подразделения</param>
        /// <returns>Возвращает объект подразделения</returns>
        Task<Subdivision> AddSubdivision(Subdivision subdivision);
        /// <summary>
        /// Метод обновления подразделения
        /// </summary>
        /// <param name="subdivision">Объект подразделения</param>
        /// <returns>Возвращает отредактированный объект подразделения</returns>
        Task<Subdivision> UpdateSubdivision(Subdivision subdivision);
        /// <summary>
        /// Метод удаления подразделения
        /// </summary>
        /// <param name="subdivision">Объект подразделения</param>
        /// <returns></returns>
        Task DeleteSubdivision(Subdivision subdivision);
        /// <summary>
        /// Метод получения списка подразделений
        /// </summary>
        /// <returns>Возвращает список подразделений</returns>
        Task<List<Subdivision>> GetSubdivisions();
    }
}
