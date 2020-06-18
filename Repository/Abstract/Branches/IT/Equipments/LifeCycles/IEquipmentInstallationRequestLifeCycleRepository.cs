using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на установку оборудования
    /// </summary>
    public interface IEquipmentInstallationRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на установку оборудования
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на установку оборудования</param>
        /// <returns>Возвращает объект жизненного цикла заявки на установку оборудования</returns>
        Task<EquipmentInstallationRequestLifeCycle> Add(EquipmentInstallationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на установку оборудования
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на установку оборудования</param>
        /// <returns>Возвращает объект жизненного цикла заявки на установку оборудования</returns>
        Task<EquipmentInstallationRequestLifeCycle> Update(EquipmentInstallationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на установку оборудования
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на установку оборудования</param>
        /// <returns></returns>
        Task Delete(EquipmentInstallationRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на установку оборудования
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на установку оборудования</returns>
        Task<List<EquipmentInstallationRequestLifeCycle>> GetLifeCycles();
    }
}
