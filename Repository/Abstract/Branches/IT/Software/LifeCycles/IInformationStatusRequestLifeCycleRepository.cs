using Domain.Models.Requests.Software;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Software.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки о состоянии информации
    /// </summary>
    public interface IInformationStatusRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки о состоянии информации
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки о состоянии информации</param>
        /// <returns>Возвращает объект жизненного цикла заявки о состоянии информации</returns>
        Task<InformationStatusRequestLifeCycle> Add(InformationStatusRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки о состоянии информации
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки о состоянии информации</param>
        /// <returns>Возвращает объект жизненного цикла заявки о состоянии информации</returns>
        Task<InformationStatusRequestLifeCycle> Update(InformationStatusRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки о состоянии информации
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки о состоянии информации</param>
        /// <returns></returns>
        Task Delete(InformationStatusRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки о состоянии информации
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки о состоянии информации</returns>
        Task<List<InformationStatusRequestLifeCycle>> GetLifeCycles();
    }
}
