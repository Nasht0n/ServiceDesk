using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.LifeCycles
{
    /// <summary>
    /// Класс доступа к хранилищу жизненного цикла заявки на ремонт оборудования
    /// </summary>
    public interface IEquipmentRepairRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на ремонт оборудования
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на ремонт оборудования</param>
        /// <returns>Возвращает объект жизненного цикла заявки на ремонт оборудования</returns>
        Task<EquipmentRepairRequestLifeCycle> Add(EquipmentRepairRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на ремонт оборудования
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на ремонт оборудования</param>
        /// <returns>Возвращает объект жизненного цикла заявки на ремонт оборудования</returns>
        Task<EquipmentRepairRequestLifeCycle> Update(EquipmentRepairRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на ремонт оборудования
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на ремонт оборудования</param>
        /// <returns></returns>
        Task Delete(EquipmentRepairRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на ремонт оборудования
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на ремонт оборудования</returns>
        Task<List<EquipmentRepairRequestLifeCycle>> GetLifeCycles();
    }
}
