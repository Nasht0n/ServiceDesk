using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на замену оборудования
    /// </summary>
    public interface IEquipmentReplaceRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на замену оборудования
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на замену оборудования</param>
        /// <returns>Возвращает объект жизненного цикла заявки на замену оборудования</returns>
        Task<EquipmentReplaceRequestLifeCycle> Add(EquipmentReplaceRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на замену оборудования
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на замену оборудования</param>
        /// <returns>Возвращает объект жизненного цикла заявки на замену оборудования</returns>
        Task<EquipmentReplaceRequestLifeCycle> Update(EquipmentReplaceRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на замену оборудования
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на замену оборудования</param>
        /// <returns></returns>
        Task Delete(EquipmentReplaceRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на замену оборудования
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на замену оборудования</returns>
        Task<List<EquipmentReplaceRequestLifeCycle>> GetLifeCycles();
    }
}
