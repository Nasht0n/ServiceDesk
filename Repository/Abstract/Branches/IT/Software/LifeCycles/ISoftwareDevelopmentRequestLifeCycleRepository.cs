using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Software.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на разработку программного обеспечения
    /// </summary>
    public interface ISoftwareDevelopmentRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на разработку программного обеспечения
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на разработку программного обеспечения</param>
        /// <returns>Возвращает объект жизненного цикла заявки на разработку программного обеспечения</returns>
        Task<SoftwareDevelopmentRequestLifeCycle> Add(SoftwareDevelopmentRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на разработку программного обеспечения
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на разработку программного обеспечения</param>
        /// <returns>Возвращает объект жизненного цикла заявки на разработку программного обеспечения</returns>
        Task<SoftwareDevelopmentRequestLifeCycle> Update(SoftwareDevelopmentRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на разработку программного обеспечения
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на разработку программного обеспечения</param>
        /// <returns></returns>
        Task Delete(SoftwareDevelopmentRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на разработку программного обеспечения
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на разработку программного обеспечения</returns>
        Task<List<SoftwareDevelopmentRequestLifeCycle>> GetLifeCycles();
    }
}
