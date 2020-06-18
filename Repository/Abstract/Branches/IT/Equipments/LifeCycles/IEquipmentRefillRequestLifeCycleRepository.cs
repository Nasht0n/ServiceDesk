using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на заправку техники
    /// </summary>
    public interface IEquipmentRefillRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на заправку техники
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на заправку техники</param>
        /// <returns>Возвращает объект жизненного цикла заявки на заправку техники</returns>
        Task<EquipmentRefillRequestLifeCycle> Add(EquipmentRefillRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на заправку техники
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на заправку техники</param>
        /// <returns>Возвращает объект жизненного цикла заявки на заправку техники</returns>
        Task<EquipmentRefillRequestLifeCycle> Update(EquipmentRefillRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на заправку техники
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на заправку техники</param>
        /// <returns></returns>
        Task Delete(EquipmentRefillRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на заправку техники
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на заправку техники</returns>
        Task<List<EquipmentRefillRequestLifeCycle>> GetLifeCycles();
    }
}
