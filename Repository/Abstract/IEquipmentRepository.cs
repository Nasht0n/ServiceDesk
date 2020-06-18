using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    /// <summary>
    /// Интерфейс доступа к хранилищу техники
    /// </summary>
    public interface IEquipmentRepository
    {
        /// <summary>
        /// Метод добавления техники
        /// </summary>
        /// <param name="equipment">Запись техники</param>
        /// <returns>Возвращает объект техники</returns>
        Task<Equipment> Add(Equipment equipment);
        /// <summary>
        /// Метод обновления технкии
        /// </summary>
        /// <param name="equipment">Запись техники</param>
        /// <returns>Возвращает объект техники (оборудования)</returns>
        Task<Equipment> Update(Equipment equipment);
        /// <summary>
        /// Метод удаления техники
        /// </summary>
        /// <param name="equipment">Запись техники</param>
        /// <returns></returns>
        Task Delete(Equipment equipment);
        /// <summary>
        /// Метод получения списка техники
        /// </summary>
        /// <returns>Возвращает список техники</returns>
        Task<List<Equipment>> GetEquipments();
    }
}
