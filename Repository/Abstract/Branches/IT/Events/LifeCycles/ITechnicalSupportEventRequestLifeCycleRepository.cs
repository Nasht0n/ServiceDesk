using Domain.Models.Requests.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract.Branches.IT.Events.LifeCycles
{
    /// <summary>
    /// Интерфейс доступа к хранилищу жизненного цикла заявки на техническое сопровождение мероприятия
    /// </summary>
    public interface ITechnicalSupportEventRequestLifeCycleRepository
    {
        /// <summary>
        /// Метод добавления записи жизненного цикла заявки на техническое сопровождение мероприятия
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на техническое сопровождение мероприятия</param>
        /// <returns>Возвращает объект жизненного цикла заявки на техническое сопровождение мероприятия</returns>
        Task<TechnicalSupportEventRequestLifeCycle> Add(TechnicalSupportEventRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод редактировния записи жизненного цикла заявки на техническое сопровождение мероприятия
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на техническое сопровождение мероприятия</param>
        /// <returns>Возвращает объект жизненного цикла заявки на техническое сопровождение мероприятия</returns>
        Task<TechnicalSupportEventRequestLifeCycle> Update(TechnicalSupportEventRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод удаления записи жизненного цикла заявки на техническое сопровождение мероприятия
        /// </summary>
        /// <param name="lifeCycle">Запись жизненного цикла заявки на техническое сопровождение мероприятия</param>
        /// <returns></returns>
        Task Delete(TechnicalSupportEventRequestLifeCycle lifeCycle);
        /// <summary>
        /// Метод получения списка записей жизненного цикла заявки на техническое сопровождение мероприятия
        /// </summary>
        /// <returns>Возвращает список записей жизненного цикла заявки на техническое сопровождение мероприятия</returns>
        Task<List<TechnicalSupportEventRequestLifeCycle>> GetLifeCycles();
    }
}
