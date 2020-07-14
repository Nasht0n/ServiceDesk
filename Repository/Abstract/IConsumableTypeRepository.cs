using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу типов расходных материалов
    /// </summary>
    public interface IConsumableTypeRepository
    {
        /// <summary>
        /// Метод добавления типа расходного материала
        /// </summary>
        /// <param name="type">Тип расходного материала</param>
        /// <returns>Возвращает объект расходного материала</returns>
        Task<ConsumableType> Add(ConsumableType type);
        /// <summary>
        /// Метод редактирования типа расходного материала
        /// </summary>
        /// <param name="type">Тип расходного материала</param>
        /// <returns>Возвращает объект расходного материала</returns>
        Task<ConsumableType> Update(ConsumableType type);
        /// <summary>
        /// Метод удаления типа расходного материала
        /// </summary>
        /// <param name="type">Тип расходного материала</param>
        /// <returns></returns>
        Task Delete(ConsumableType type);
        /// <summary>
        /// Метод получения списка типов расходного материала
        /// </summary>
        /// <returns>Возвращает список типов расходного материала</returns>
        Task<List<ConsumableType>> GetConsumableTypes();
    }
}
