using Domain.Models.Requests.Equipment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Equipments.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на замену комплектующего
    /// </summary>
    public interface IComponentReplaceRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на замену комплектующего
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на замену комплектующего</param>
        /// <returns>Возвращает объект жизненного цикла заявки на замену комплектующего</returns>
        Task<ComponentReplaceRequestLifeCycle> Add(ComponentReplaceRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на замену комплектующего
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на замену комплектующего</param>
        /// <returns>Возвращает объект жизненного цикла заявки на замену комплектующего</returns>
        Task<ComponentReplaceRequestLifeCycle> Update(ComponentReplaceRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на замену комплектующего
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на замену комплектующего</param>
        /// <returns></returns>
        Task Delete(ComponentReplaceRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на замену комплектующего
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на замену комплектующего</returns>
        Task<List<ComponentReplaceRequestLifeCycle>> GetLifeCycles();
    }
}
