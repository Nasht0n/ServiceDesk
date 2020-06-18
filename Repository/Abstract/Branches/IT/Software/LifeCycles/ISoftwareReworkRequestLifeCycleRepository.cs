using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Software.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на доработку программного обеспечения
    /// </summary>
    public interface ISoftwareReworkRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на доработку программного обеспечения
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на доработку программного обеспечения</param>
        /// <returns>Возвращает объект жизненного цикла заявки на доработку программного обеспечения</returns>
        Task<SoftwareReworkRequestLifeCycle> Add(SoftwareReworkRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на доработку программного обеспечения
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на доработку программного обеспечения</param>
        /// <returns>Возвращает объект жизненного цикла заявки на доработку программного обеспечения</returns>
        Task<SoftwareReworkRequestLifeCycle> Update(SoftwareReworkRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на доработку программного обеспечения
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на доработку программного обеспечения</param>
        /// <returns></returns>
        Task Delete(SoftwareReworkRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на доработку программного обеспечения
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на доработку программного обеспечения</returns>
        Task<List<SoftwareReworkRequestLifeCycle>> GetLifeCycles();
    }
}
