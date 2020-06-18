using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу расходных материалов
    /// </summary>
    public interface IConsumableRepository
    {
        /// <summary>
        /// Метод добавления расходного материала
        /// </summary>
        /// <param name="consumable">Расходный материал</param>
        /// <returns>Возвращает объект расходного материала</returns>
        Task<Consumable> Add(Consumable consumable);
        /// <summary>
        /// Метод обновления записи расходного материала
        /// </summary>
        /// <param name="consumable">Расходный материал</param>
        /// <returns>Возвращает запись расходного материала</returns>
        Task<Consumable> Update(Consumable consumable);
        /// <summary>
        /// Метод удаления расходного материала
        /// </summary>
        /// <param name="consumable">Расходный материал</param>
        /// <returns></returns>
        Task Delete(Consumable consumable);
        /// <summary>
        /// Метод получения списка расходных материалов
        /// </summary>
        /// <returns>Возвращает список расходных материалов</returns>
        Task<List<Consumable>> GetConsumables();
    }
}
